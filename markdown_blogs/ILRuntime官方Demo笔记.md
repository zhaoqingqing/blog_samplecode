### 热更工程最常做的事情

以使用Lua做为热更脚本为例，在热更工程做的最多的事情举例。

在热更工程中调用主程的方法，或监听主程的事件，监听Unity组件的默认事件。

热更工程中加载资源

热更工程中对UI进行处理

读取配置，对配置解析

热更工程中处理网络的回调



目前经历的项目中，绝大多数逻辑都是在热更代码写的，而看ILRuntime和XLua的例子，似乎是建议在主工程中调用热更代码，比如修复逻辑问题或执行具体的逻辑。



### 监听主工程的委托



在热更工程中监听主工程的事件

如果非Action或Func，则需要在主工程中写适配器





### 对主工程的值类型做绑定

那些需要做绑定？Unity的常用值类型，比如：Vector3，Vector2

这项操作会提升性能，减少额外的CPU开销和GC Alloc。

方法：

```c#
AppDomain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
```



Demo 做了十万次运算，打印日志如下：

```c#
Value: a=(100001.0, 100002.0, 100003.0),dot=0, time = 750ms
Value: a=(100001.0, 100002.0, 100003.0),dot=0, time = 1911ms

Value: a=(-0.4, -0.8, -1.7, -5.1),dot=-124.7494, time = 604ms
Value: a=(-0.4, -0.8, -1.7, -5.1),dot=-124.7494, time = 1550ms

Value: a=(100001.0, 100002.0),dot=0, time = 710ms
Value: a=(100001.0, 100002.0),dot=0, time = 1902ms
```





### AppDomain 常用方法

LoadAssembly

调用热更中的方法 appdomain.Invoke("HotFix_Project.TestCLRBinding", "RunTest", null, null);



> 预先获得IMethod，可以减低每次调用查找方法耗用的时间 LoadedTypes

```c#
//预先获得IMethod，可以减低每次调用查找方法耗用的时间
IType type = appdomain.LoadedTypes["HotFix_Project.InstanceClass"];
//根据方法名称和参数个数获取方法
IMethod method = type.GetMethod("StaticFunTest", 0);

appdomain.Invoke(method, null, null);
```

