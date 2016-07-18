#region Copyright (c) 2015 KEngine / Kelly <http://github.com/mr-kelly>, All rights reserved.

// KEngine - Toolset and framework for Unity3D
// ===================================
//
// Date:     2015/12/03
// Author:  Kelly
// Email: 23110388@qq.com
// Github: https://github.com/mr-kelly/KEngine
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3.0 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library.

#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.Editor;

namespace CSharpMethodInjector
{
    /// <summary>
    /// 向C#代码块插入文字
    /// </summary>
    public class MethodInjector
    {
        public delegate string CSharpMethodInjectorDelegate(
            string className,
            string methodName, string returnType, string[] parameters, string[] outParams);

        private CSharpMethodInjectorDelegate _afterInsert;
        private CSharpMethodInjectorDelegate _beforeInsert;
        private string[] _defineSymbols;

        private MethodInjector() {}
        public MethodInjector(CSharpMethodInjectorDelegate afterInsert, CSharpMethodInjectorDelegate beforeInsert = null, string[] defineSymbols = null)
        {
            _afterInsert = afterInsert;
            _beforeInsert = beforeInsert;
            _defineSymbols = defineSymbols;
        }

        /// <summary>
        /// 代码注入！ GOGOGO
        /// </summary>
        /// <param name="srcFilePath"></param>
        /// <param name="outputFilePath"></param>
        public void Inject(string srcFilePath, string outputFilePath)
        {
            UTF8Encoding utf8 = new UTF8Encoding(false);

            var predefineSymbolsSb = new StringBuilder();
            if (_defineSymbols != null)
            {
                foreach (var symbol in _defineSymbols)
                {
                    predefineSymbolsSb.AppendFormat("#define {0}\n", symbol);    
                }

            }

            var code = File.ReadAllText(srcFilePath, Encoding.UTF8);
            code = predefineSymbolsSb.ToString() + code;  // 加入宏

            var document = new StringBuilderDocument(code);
            var formattingOptions = FormattingOptionsFactory.CreateAllman();
            var options = new TextEditorOptions();

            using (var script = new DocumentScript(document, formattingOptions, options))
            {
                CSharpParser parser = new CSharpParser();
                SyntaxTree syntaxTree = parser.Parse(code, srcFilePath);
                foreach (var classDec in syntaxTree.Descendants.OfType<TypeDeclaration>())
                {
                    if (classDec.ClassType == ClassType.Class || classDec.ClassType == ClassType.Struct)
                    {
                        var className = classDec.Name;
                        foreach (var method in classDec.Children.OfType<MethodDeclaration>())
                        {
                            var returnType = method.ReturnType.ToString();
                            if (returnType.Contains("IEnumerator") || returnType.Contains("IEnumerable"))  // 暂不支持yield!
                                continue;

                            var methodSegment = script.GetSegment(method);
                            var methodOffset = methodSegment.Offset;  // 方法偏移

                            var paramsTypes = method.Parameters;//method.Children.OfType<ParameterDeclaration>();// typeName
                            var paramsTypesStrs = new List<string>(); // 参数
                            if (!method.HasModifier(Modifiers.Static))
                                paramsTypesStrs.Add("this"); // 非静态方法，加this

                            var paramsOutStrs = new List<string>(); // out 的参数
                            foreach (var paramsType in paramsTypes)
                            {
                                paramsTypesStrs.Add(paramsType.Name);
                                if (paramsType.ParameterModifier == ParameterModifier.Out)
                                {
                                    // out 的参数
                                    paramsOutStrs.Add(string.Format("{0} = default({1});", paramsType.Name, paramsType.Type));
                                }
                            }

                            if (_beforeInsert != null)
                            {
                                var insertBeforeText = _beforeInsert(className, method.Name, returnType,
                                    paramsTypesStrs.ToArray(), paramsOutStrs.ToArray());
                                if (!string.IsNullOrEmpty(insertBeforeText))
                                    script.InsertText(methodOffset, insertBeforeText);
                            }

                            foreach (var blockStatement in method.Descendants.OfType<BlockStatement>())
                            {
                                int insertOffset;
                                if (blockStatement.Statements.Count == 0) // 空函数
                                {
                                    var segment = script.GetSegment(blockStatement);
                                    insertOffset = segment.Offset + 1; // 越过"/"
                                }
                                else
                                {
                                    var firstChildStatement = blockStatement.Statements.First();
                                    var segment = script.GetSegment(firstChildStatement);
                                    insertOffset = segment.Offset;
                                }
                                script.InsertText(insertOffset, _afterInsert(className, method.Name, returnType, paramsTypesStrs.ToArray(), paramsOutStrs.ToArray()));
                                break; // 仅对第一个方法包体(BlockStatement), 其它不是方法进行处理
                            }
                        }
                    }
                }

            }
            var resultText = document.Text;

            resultText = resultText.Substring(predefineSymbolsSb.Length); // 移除宏定义
            File.WriteAllText(outputFilePath, resultText, utf8);
        }
    }
}