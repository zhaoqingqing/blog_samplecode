基于ILRuntime 1.6.3版本，在ILRuntime中提供测试用例，建议在下载ILRuntime之后先跑一遍官方的测试用例，对比自己使用ILRuntime的性能和官方数据是否一致

## 测试工具

### 测试工具预览

![image-20200820102813380](https://img2020.cnblogs.com/blog/363476/202008/363476-20200831092335540-1083032960.png)

### 测试用例使用方法

1. 双击从git拉取ILRuntime目录下的ILRuntime.sln
2. 用VS或Rider打开后，对项目TestCases生成TestCases.dll
3. 运行ILRuntimeTest项目会弹出上图的窗口，在LoadAssembly中加载之前生成的TestCases.dll
4. 点击生成CLR绑定和适配器，如果无修改代码则只需要生成一次
5. 从列表中选择需要运行的单元测试（RunSelect），可以选择RunAll运行所有用例

上图中两个按钮对应ILRuntime在Unity的菜单如下：

Binding： 通过自动分析热更DLL生成CLR绑定

CrossBind Gen： 生成跨域继承适配器

## 测试内容

整个测试用例包含这些内容，支持的C#语法，支持的C#特性

### C#语法测试

用来测试ILRuntime中支持的C#语法，如果不支持的，会输出not support

涵盖的C#语法内容有：

| struct    | interface     | Reflection              | Array    |
| --------- | ------------- | ----------------------- | -------- |
| class     | override      | Inheritance             | RefOut   |
| enum      | Delegate      | AsyncAwait              | JsonTest |
| try catch | GenericMethod | ActivatorCreateInstance | ......   |

更多的测试用例可以查看下面的测试用例.txt

### 性能测试

用例中包含的性能部分并不算多，主要是运算符操作，代码在Test01.cs

TestCases.Test01.UnitTest_Performance2
TestCases.Test01.UnitTest_Performance
TestCases.Test01.UnitTest_Performance3
TestCases.Test01.UnitTest_Performance4

### 所有测试用例

我把官方的所有测试用例保存为一份txt，[点击查看](https://github.com/zhaoqingqing/blog_samplecode/tree/master/technical-research/ILRuntime)

注：对于sealed class，txt和用例中显示的是/，比如：TestCases.StaticTest/NormalClass.Create

通过反射获取所有的测试用例，代码如下：

```c#
var types = _app.LoadedTypes.Values.ToList();
foreach (var type in types)
{
	var ilType = type as ILType;
	if (ilType == null)
		continue;
	var methods = ilType.GetMethods();
	foreach (var methodInfo in methods)
	{
		string fullName = ilType.FullName;
		//目前只支持无参数，无返回值测试
		if (methodInfo.ParameterCount == 0 && methodInfo.IsStatic && ((ILRuntime.CLR.Method.ILMethod)methodInfo).Definition.IsPublic)
		{
			var testUnit = new StaticTestUnit();
			testUnit.Init(_app, fullName, methodInfo.Name);
			_testUnitList.Add(testUnit);
		}
	}
}
```