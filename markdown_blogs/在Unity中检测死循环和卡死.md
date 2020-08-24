当游戏在手机/模拟器上卡死，logcat没有日志输出，也没有卡死堆栈信息或者bugly也没有捕获到异常，你是否很焦急？本文介绍一下我们项目中检测Unity卡死的方法，也许适合你使用。

## 实现原理

在绝大多数情况下我们可以认为Unity是单线程的，基于这点我们在Unity的系统函数FixedUpdate中统计游戏运行期间的总帧数，如果Unity没有卡死，那么TotalFrame是会一直累加的，如果在某一段时间内TotalFrame都不会变化了，则可以认为Unity已经卡死了

既然Unity的主线程已经卡死了，我们就需要用另一个线程用来定时检查unity主线程中的TotalFrame是否不会变化了

### 示例代码

```c#
using System;
using System.Threading;
using UnityEngine;

namespace KEngine
{
    /// <summary>
    /// 开另外一个线程检测unity是否被卡死
    /// </summary>
    public static class UnityThreadDetect
    {
        public static Thread _MainThread = System.Threading.Thread.CurrentThread;//获取unity线程
        private static int check_interval = 3000;//检测间隔

        public static void Start()
        {
            new Thread(CheckMainThread).Start();
        }
        
        static void CheckMainThread()
        {
            long frame = 0;
            while(!AppEngine.IsApplicationQuit)
            {
                frame = AppEngine.TotalFrame;
                Thread.Sleep(check_interval);
                if (frame == AppEngine.TotalFrame)
                {
                    Log.LogToFile("unity thread dead,ThreadState:{0}",_MainThread.ThreadState);
                    if (AppEngine.IsApplicationFocus)
                    {
                        //todo report error
                    }
                }
            }
        }
    }
}
```

### 捕获卡死的方法名

在我们的游戏中一般出现卡死的情况都是在定时器里面，我们的定时器是通过在Unity的Update驱动定时器列表，当卡死时可以打印出定时器中正在执行的函数就可以定位到卡死的函数了。

同时在Unity的Update进行派发多个事件，比如PreUpdate，Update，以便出问题更容易定位到卡在那儿

​     

## 举例说明问题

下面举例我们遇到的出现卡死的问题

### 死循环

下面这个死循环在Unity中会卡死，而在.NET中不会，.NET中当i超过byte的最大值255时i会从0开始

```c#
public static void TesBadCode()
{
	byte i = 0;  
	while (true)
	{
		i++;
	}
}
```

目前我们遇到的绝大多数情况都是逻辑代码中写了`where(true) do xxx `然后里面某些情况不会break，导致循环永远退不出来

### 屏蔽了事件系统

在某些系统中屏蔽掉了UGUI的事件系统，导致无法接受用户输入，这个问题不应该归类为Unity卡死，但用户反馈来看就是卡死了，无法操作。



## 扩展

### 递归调用

递归调用，会报stack overflow，不会让unity卡死

为什么无限循环递归调用不会卡死Unity？

这是因为每个方法的`方法调用栈容量`是有限的，当超出之后就会跳出报stack overflow，不会让应用程序卡死

```c#
public static void TesBadCode()
{
	while (true)
	{
		TesBadCode();
	}
}
```