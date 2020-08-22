## 50万次的基础运算

IL使用全局变量：UnitTest_Performance50万 Elapsed time:1050ms, result = 445698416  ,Tick:10527445

IL使用局部变量：UnitTest_Performance50万 Elapsed time:759ms, result = 445698416  ,Tick:7630735

Unity原生代码：mono UnitTest_Performance50万 Elapsed time:1ms, result = 445698416  ,Tick:19900

xlua中lua：[10:42:43.8636]LUA: cost:41.81 ms, 4.00

测试代码

```c#
 public static void UnitTest_Performance3()
{
	var before = DateTime.Now.Ticks;
	System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
	sw.Start();
	int cnt = 0;
	for (int i = 0; i < 500000; i++)
	{
		cnt += i;
	}
	sw.Stop();
	var tick_diff = DateTime.Now.Ticks - before;
	Debug.Log(string.Format("UnitTest_Performance50万 Elapsed time:{0:0}ms, result = {1}  ,Tick:{2}", sw.ElapsedMilliseconds, cnt,tick_diff));
}
```

## 建议

### 栈和堆差别非常大

从上面的运算可知，局部变量是存储在栈中的，而全局变量是存储在堆中，一定要注意在进行大量访问同一个一个对象是，先使用local xx = 全局变量

### 逻辑代码问题会放大数百倍

如果项目计划使用ILRuntime热更，强烈建议在项目初期就接入，这样能及早发现逻辑代码效率问题，及早解决掉。

一定要仔细阅读官方的文档，避免踩到雷区，比如foreach会产生GC Allow，热更代码中避免频繁大量的计算和空函数调用