我们公司有一个Unity原生开发语言C#写的项目，目前已经在安卓测试过多次，上架IOS在考虑热更，所以对ILRuntim进行性能测试，在测试过程中已经按照官方文档进行了CLR绑定和生成Release的Dll，并且在非Editor环境下测试。

我的测试环境：ILRuntime 1.6.3 ，MuMu模拟器和华为手机

## 50万次的加法运算

ILRuntime使用全局变量：UnitTest_Performance50万 Elapsed time:1050ms, result = 445698416  ,Tick:10527445

ILRuntime使用局部变量：UnitTest_Performance50万 Elapsed time:534ms, result = 445698416  ,Tick:5436060

Unity原生代码：mono UnitTest_Performance50万 Elapsed time:1ms, result = 445698416  ,Tick:19900

xlua中lua：[10:42:43.8636]LUA: cost: 4.00ms

C#测试代码

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

Lua测试代码

```lua
local begin = os.clock()
local cnt = 0;
for i = 1, 500000 do
	cnt = cnt + i;
end
local diff =  os.clock() - begin;
print(string.format("cost:%.2f ms", diff*1000))
```

从测试结果可以看到在Lua做加法运算的性能会比ILRuntime中好一百倍左右，对于需要大量运算的确实如ILRuntime的文档所以不应该放热更代码中

### 为什么不测试热更调主工程？

在这个项目中，从热更调用主工程代码，相对比较少，大部分都是在热更工程中使用计算，比如对象管理，战斗部分，玩法逻辑。

从ILRuntime的文档中提到跨域调用会比Lua快很多

## 空Update也耗时

对于MonoBehaviour中的空Update，当执行上千次时，耗时在0.1ms，所以要去掉空内容的Update

## 建议

### 栈和堆差别非常大

上面局部变量和全局变量的耗时差别很大，是因为局部变量是存储在栈中，而全局变量是存储在堆中，一定要注意在进行遍历一个列表时，在方法内先使用local xx = 全局变量，这样对于性能的提升是非常有效的

### 逻辑运算问题会放大数百倍

如果项目计划使用ILRuntime热更，强烈建议在项目初期就接入，这样能及早发现逻辑代码效率问题，及早解决掉。

一定要仔细阅读官方的文档，避免踩到雷区，比如foreach会产生GC Allow，热更代码中避免频繁大量的计算和空函数调用，对于有很多的空Update也需要去掉

### 不要使用foreach

在每秒执行的update中使用for会比foreach性能好很多