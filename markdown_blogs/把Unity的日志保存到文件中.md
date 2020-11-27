## Unity的日志事件

Unity提供了两个API，回调函数的参数都是一样的，通过这个API可以在真机上把Debug.Log/LogWarning/LogError 日志输出到文件中保存，我建议使用Application.logMessageReceivedThreaded

```c#
Application.logMessageReceivedThreaded
Application.logMessageReceived
OnLogCallback(string condition, string stackTrace, LogType type)
```

**Application.logMessageReceived**

此事件仅在主线程上触发。如果你的处理程序需要访问限制到主线线程的Unity API的一部分，或者由于其他原因你的处理程序不是线程安全的，就使用它

**Application.logMessageReceivedThreaded**

无论消息是否在主线程上传入，此事件都将被触发。这意味着处理程序代码必须是线程安全的。它可以从不同的线程调用，也可以并行调用。确保仅从允许从主线程以外的线程调用的处理程序中访问Unity API

注意:不必同时订阅两个应用消息：logMessageReceived和 Application.logMessageReceivedThreaded。对于主线程上的消息，也将调用多线程变体。

看到[QFramework](https://www.bookstack.cn/read/QFramework/6dc7fa9ab0ef2ca2.md)中提到这一样一句话：

> 如果只是使用 Application.logMessageReceived 的时候,在真机上如果发生 Error 或者 Exception 时,收不到堆栈信息。但是使用了 Application.logMessageReceivedThreaded 就可以接收到堆栈信息了,不过在处理 Log 信息的时候要保证线程安全。

因为写入日志的实现方式我和他是不一样的，我是在主线程中写入日志的，而他是再开了一个线程来写入日志。所以我是没有遇到他这个问题。

### 参数解释

OnLogCallback(string condition, string stackTrace, LogType type)

condition：就是代码中主动打印的日志

stackTrace：堆栈信息。如果Project Setting中设置的堆栈为ScriptOnly，则除了程序出错，其它的Log是不会有堆栈信息的，而如果使用:Environment.StackTrace来代替stackTrace，则会有一串很长很长的堆栈。

目前我们的项目在Project Setting中也是设置的Script Only

## 查看stackTrace

我的测试环境如下：

unity2019.3.7 个人版 打包pc版

设置一：Project Settings中设置的StackTrace全部为ScriptOnly

设置二：Project Settings中设置的StackTrace全部为Full

打的是Mono包而非IL2Cpp，设置为.NET 4.x或 .NET Stand都尝试过，结果是一样。

### 堆栈设置为ScriptOnly

测试代码如下，在日志中不会打印调用堆栈，对于error也没有堆栈，只有真正的exception发生才会有出错堆栈

```c#
void OnClickBtn1()
{
    Debug.Log("test  log");
    Debug.LogWarning("test  log warn");
    Debug.LogError("test  log error");
    //text1是不存在的，特意让程序出错，查看输出堆栈
    text1.text = "text";
}
```

[2020-11-27 14:54:35][Log]test  log

[2020-11-27 14:54:35][Warning]test  log warn

[2020-11-27 14:54:35][Error]test  log error

[2020-11-27 14:54:35][Exception]NullReferenceException: Object reference not set to an instance of an object
TestLogStackTrace.OnClickBtn2 () (at <ff686622d7bd4bc5aa3439ea4fdaa75c>:0)
UnityEngine.Events.InvokableCall.Invoke () (at <73b499366e5241bda47e5da76897738b>:0)
UnityEngine.Events.UnityEvent.Invoke () (at <73b499366e5241bda47e5da76897738b>:0)
UnityEngine.UI.Button.Press () (at <f958a6d423f6417093b99af0cc19a97b>:0)
UnityEngine.UI.Button.OnPointerClick (UnityEngine.EventSystems.PointerEventData eventData) (at <f958a6d423f6417093b99af0cc19a97b>:0)
UnityEngine.EventSystems.ExecuteEvents.Execute (UnityEngine.EventSystems.IPointerClickHandler handler, UnityEngine.EventSystems.BaseEventData eventData) (at <f958a6d423f6417093b99af0cc19a97b>:0)
UnityEngine.EventSystems.ExecuteEvents.Execute[T] (UnityEngine.GameObject target, UnityEngine.EventSystems.BaseEventData eventData, UnityEngine.EventSystems.ExecuteEvents+EventFunction`1[T1] functor) (at <f958a6d423f6417093b99af0cc19a97b>:0)
UnityEngine.EventSystems.EventSystem:Update()

### 把堆栈打印出来

而在某些情况下，我们希望把函数的调用者打印出来，可以通过StackTrace

测试代码如下：

```c#
void OnClickBtn1()
{
    Debug.Log(this.name + "click stacktrace:\n" + new StackTrace(true) + "\n");
}
```

输出结果如下：

[2020-11-27 17:43:45]Canvasclick stacktrace:
  at TestLogStackTrace.OnClickBtn1 () [0x00000] in <3010e64894cc4fd9b62b8f33b1cc1f8a>:0 
  at UnityEngine.Events.InvokableCall.Invoke () [0x00000] in <73b499366e5241bda47e5da76897738b>:0 
  at UnityEngine.Events.UnityEvent.Invoke () [0x00000] in <73b499366e5241bda47e5da76897738b>:0 
  at UnityEngine.EventSystems.EventSystem.Update () [0x00000] in <3fe6533ed4534466954fc02559cdbfd7>:0 

### 堆栈设置为Full

设置为Full之后，在日志文件中，对于Debug.Log ~ Debug.LogError都会有非常非常长的一串Unity的调用堆栈

```powershell
[2020-11-27 14:58:47][Log]test  log
0x00007FFCA6DB060C (UnityPlayer) 
0x00007FFCA6DB3933 (UnityPlayer) 
0x00007FFCA6DA32CD (UnityPlayer) 
0x00007FFCA7646A9E (UnityPlayer) UnityMain
0x00007FFCA71B9011 (UnityPlayer) UnityMain
0x000001C7AAEDF6EE (Mono JIT Code) (wrapper managed-to-native) UnityEngine.DebugLogHandler:Internal_Log (UnityEngine.LogType,UnityEngine.LogOption,string,UnityEngine.Object)
0x000001C7AAEDF3FB (Mono JIT Code) UnityEngine.DebugLogHandler:LogFormat (UnityEngine.LogType,UnityEngine.Object,string,object[])
0x000001C7AAEDF0D0 (Mono JIT Code) UnityEngine.Logger:Log (UnityEngine.LogType,object)
0x000001C7AAEDEE4A (Mono JIT Code) UnityEngine.Debug:Log (object)
0x000001C7AAF2F693 (Mono JIT Code) TestLogStackTrace:OnClickBtn2 ()
0x000001C7AAF2F649 (Mono JIT Code) UnityEngine.Events.InvokableCall:Invoke ()
0x000001C7AAF2F39B (Mono JIT Code) UnityEngine.Events.UnityEvent:Invoke ()
0x000001C7AAF2F123 (Mono JIT Code) UnityEngine.UI.Button:Press ()
0x000001C7AAF2F063 (Mono JIT Code) UnityEngine.UI.Button:OnPointerClick (UnityEngine.EventSystems.PointerEventData)
0x000001C7AAF2F009 (Mono JIT Code) UnityEngine.EventSystems.ExecuteEvents:Execute (UnityEngine.EventSystems.IPointerClickHandler,UnityEngine.EventSystems.BaseEventData)
0x000001C7AAF2A8F2 (Mono JIT Code) UnityEngine.EventSystems.ExecuteEvents:Execute<T_REF> (UnityEngine.GameObject,UnityEngine.EventSystems.BaseEventData,UnityEngine.EventSystems.ExecuteEvents/EventFunction`1<T_REF>)
0x000001C7AAF2ED0B (Mono JIT Code) UnityEngine.EventSystems.StandaloneInputModule:ReleaseMouse (UnityEngine.EventSystems.PointerEventData,UnityEngine.GameObject)
0x000001C7AAF25773 (Mono JIT Code) UnityEngine.EventSystems.StandaloneInputModule:ProcessMousePress (UnityEngine.EventSystems.PointerInputModule/MouseButtonEventData)
0x000001C7AAEFFD73 (Mono JIT Code) UnityEngine.EventSystems.StandaloneInputModule:ProcessMouseEvent (int)
0x000001C7AAF0FF8B (Mono JIT Code) UnityEngine.EventSystems.StandaloneInputModule:ProcessMouseEvent ()
0x000001C7AAF1FEA3 (Mono JIT Code) UnityEngine.EventSystems.StandaloneInputModule:Process ()
0x000001C7AAF04AFF (Mono JIT Code) UnityEngine.EventSystems.EventSystem:Update ()
0x000001C7677FAA20 (Mono JIT Code) (wrapper runtime-invoke) object:runtime_invoke_void__this__ (object,intptr,intptr,intptr)
0x00007FFCAF2FCBA0 (mono-2.0-bdwgc) mono_get_runtime_build_info
0x00007FFCAF282112 (mono-2.0-bdwgc) mono_perfcounters_init
0x00007FFCAF28B10F (mono-2.0-bdwgc) mono_runtime_invoke
0x00007FFCA71554DD (UnityPlayer) UnityMain
0x00007FFCA71528B3 (UnityPlayer) UnityMain
0x00007FFCA713BBD3 (UnityPlayer) UnityMain
0x00007FFCA713BC8D (UnityPlayer) UnityMain
0x00007FFCA6ED1D30 (UnityPlayer) UnityMain
0x00007FFCA701A717 (UnityPlayer) UnityMain
0x00007FFCA701A7B3 (UnityPlayer) UnityMain
0x00007FFCA701CBBB (UnityPlayer) UnityMain
0x00007FFCA6DD7E5E (UnityPlayer) 
0x00007FFCA6DD6BBA (UnityPlayer) 
0x00007FFCA6DDAA7C (UnityPlayer) 
0x00007FFCA6DDE56B (UnityPlayer) UnityMain
0x00007FF6FC6211F2 (UGUIDemo) 
0x00007FFD26047974 (KERNEL32) BaseThreadInitThunk
0x00007FFD2694A0B1 (ntdll) RtlUserThreadStart
```

### 测试结果文件

结果文件我上传在 [我的github](https://github.com/zhaoqingqing/blog_samplecode/tree/master/technical-research/Unity%E6%97%A5%E5%BF%97%E5%A0%86%E6%A0%88) 