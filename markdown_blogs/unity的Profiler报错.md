以Unity2019及之前的版本为例，profiler的报错只有在打开profiler窗口之后，才会在日志窗口出现

profiler报错日志：Non matching Profiler.EndSample (BeginSample and EndSample count must match)

中文解释：Profiler.EndSample找不到匹配项， Profiler的两个标签需要成对的出现

出错原因：

在Profiler.EndSample前没有Profiler.BeginSample ，如果仅仅写Profiler.BeginSample而不写Profiler.EndSample是不会出现这个报错的

```c#
//这是正确的Profiler代码
void Test(){
	Profiler.BeginSample("xxx")
     //这是一段逻辑代码
	Profiler.EndSample();
}

//无结束标签不会报错
void Test(){
	Profiler.BeginSample("xxx");
}

//只有结束标签会报错
void Test(){
	Profiler.EndSample();
}
```



如果Profiler.BeginSample和Profiler.EndSample不在同一帧执行，中间多了yield return null，也会出现这个报错

```c#
IEnumerator Test()
{
	Profiler.BeginSample("xxx");
	yield return null;
	Profiler.EndSample();
}
```

