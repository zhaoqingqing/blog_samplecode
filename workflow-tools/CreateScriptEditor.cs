using System.IO;
using UnityEditor;
using UnityEngine;


/// <summary>
/// 作者：赵青青 (569032731@qq.com)
/// 时间：2020/9/14 17:05
/// 说明：在Unity Editor中创建C#文件时自动替换#CreateTime#为当前系统时间
/// 使用方法：把此脚本放在Editor目录下，并配合81-C# Script-NewBehaviourScript.cs.txt
/// </summary>
public class CreateScriptEditor : UnityEditor.AssetModificationProcessor
{
    private static void OnWillCreateAsset(string assetPath)
    {
        assetPath = assetPath.Replace(".meta", string.Empty);

        if (assetPath.EndsWith(".cs"))
        {
            string allText = File.ReadAllText(assetPath);
            var fileName = Path.GetFileName(assetPath);
            var strTime = System.DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            //Debug.Log(System.DateTime.Now.ToString());

            allText = allText.Replace("#CreateTime#", strTime);
            File.WriteAllText(assetPath, allText);
            Debug.Log(string.Format("Create {0} In {1}", fileName, strTime));
        }
    }
}