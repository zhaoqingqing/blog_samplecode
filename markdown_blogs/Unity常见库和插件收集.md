## string 0gc字符串拼接

用于.NET Core及Unity的零分配字符串生成器。

### 国人开源的zstring

这是一款国人开源的zstring，可用在Unity3D中，我的测试环境：Unity2019.3.4f1

地址：https://github.com/871041532/zstring

经测试这个是真的0gc，短字符串处理，会比原生string慢一些

gc分配值：string >ZString >zstring

执行耗时：zstring >ZString >string

易用性：string>zstring>ZString

### 测试代码

```c#
void Update()
{
	Profiler.BeginSample("zstring=============concat");
	ZString.Concat("abc", 1);
	Profiler.EndSample();
	
	Profiler.BeginSample("string=============concat");
	string.Concat("abc", 1);
	Profiler.EndSample();
	
	Profiler.BeginSample("cn-zstring=============concat");
	using (zstring.Block())
	{
		zstring.Concat("abc",1);
	}
	Profiler.EndSample();
	
	Profiler.BeginSample("zstring=============format");
	ZString.Format("hello,{0}",1111);
	Profiler.EndSample();
	
	Profiler.BeginSample("string=============format");
	string.Format("hello,{0}",1111);
	Profiler.EndSample();
	
	Profiler.BeginSample("cn-zstring=============format");
	using (zstring.Block())
	{
		zstring.Format("hello ,{0}",1111);
	}
	Profiler.EndSample();
}
```



### CySharp的ZString

https://github.com/Cysharp

### ZString和string gc对比

| Method         | Allocated(B) | Mean(ns) |      |      |      | Mean(ns) |
| -------------- | ------------ | -------- | ---- | ---- | ---- | -------- |
| StringPlus     | 224          | 126.66   |      |      |      | 126.66   |
| ZStringConcat  | 56           | 96.95    |      |      |      | 96.95    |
| StringFormat   | 128          | 158.21   |      |      |      | 158.21   |
| ZStringFormat  | 56           | 185.36   |      |      |      | 185.36   |
| StringBuilder  | 296          | 144.2    |      |      |      | 144.2    |
| ZStringBuilder | 56           | 131.68   |      |      |      | 131.68   |

## Unity-Logs-Viewer

使用此工具，您可以轻松检查游戏内置的编辑器控制台日志！无需返回项目或进行其他测试来跟踪问题！

https://github.com/aliessmael/Unity-Logs-Viewer/

## Particle Effect For UGUI

此插件为Unity 2018.2+中的uGUI提供了一个渲染粒子效果的组件。粒子渲染是可屏蔽和可排序的，在没有Camera，RenderTexture或Canvas的情况下。

UGUI的流行库：https://github.com/mob-sakai

https://github.com/mob-sakai/ParticleEffectForUGUI

## UnityLibrary

此处免费收集有用的脚本，摘要和着色器。

我们从外部资源（例如Unity社区）（论坛，答案）中收集了大多数脚本，并且自己编写了一些脚本。

地址：https://github.com/UnityCommunity/UnityLibrary

## BestHttp

看到有项目组在使用这款插件