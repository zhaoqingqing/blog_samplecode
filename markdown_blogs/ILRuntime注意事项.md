### 在Profiler中查看ILRuntime代码调用堆栈

跨域继承 卡顿 这个有什么办法解决吗，那块profiler 里面就没有 用watch看是逻辑是正常的 唯一区别就是跨域继承了

初始化ilruntime的时候加这个可以在profiler里看见

```c#
#if UNITY_EDITOR
        appdomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
#endif
```



### ILRuntime工程报错

在ProjectSetting - Other Settings 中勾选 allow unsafe code