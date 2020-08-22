基于ILRuntime 1.6.3版本

## 测试工具

### 测试工具预览

![image-20200820102813380](E:\Code\blog_samplecode\blog_images\image-20200820102813380.png)

1. 在VS或Rider中生成TestCases.dll
2. 加载TestCases.dll
3. 生成CLR绑定和适配器，如果无修改代码则只需要生成一次
4. 选择需要运行的单元测试（RunSelect）

这两个按钮对应ILRuntime中的菜单如下：

Binding： 通过自动分析热更DLL生成CLR绑定

CrossBind Gen： 生成跨域继承适配器

## 测试内容

性能测试


### 接口测试

这部分主要测试在ILRuntime中支持的C#语法内容，如果不支持的，会输出not support

涵盖的C#语法内容有：

struct

class

array

try catch

更多的测试用例可以查看下面提到的测试用例.txt

向量测试

### 所有测试用例

对于sealed class，用例中显示的是/，比如：TestCases.StaticTest/NormalClass.Create

我列出了测试用例中所有方法，保存了一份txt，点击查看

获取所有的测试用例代码如下：

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