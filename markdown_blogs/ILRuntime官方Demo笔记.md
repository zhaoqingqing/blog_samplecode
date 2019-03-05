### 调用/执行 热更中的方法

调用热更代码中方法，写在AppDomain中，记录一下主要几个方法：

AppDomain.LoadAssembly 加载热更dll

执行热更代码的方法，有两种方式：

> 1. appdomain.Invoke("HotFix_Project.InstanceClass", "StaticFunTest", null, null);

> 2. 预先获得IMethod，可以减低每次调用查找方法耗用的时间，代码如下：

```c#
//预先获得IMethod，可以减低每次调用查找方法耗用的时间
IType type = appdomain.LoadedTypes["HotFix_Project.InstanceClass"];
//根据方法名称和参数个数获取方法
IMethod method = type.GetMethod("StaticFunTest", 0);

appdomain.Invoke(method, null, null);
```



### 监听主工程的委托

在热更工程中监听主工程的事件，由主工程触发。

如果非Action或Func，则需要在主工程中写适配器，所以建议使用系统自带的Action和Func。



### 继承主工程，实现主工程接口

因为跨域继承必须要注册适配器。 如果是热更DLL里面继承热更里面的类型，不需要任何注册。



### 适配器代码怎么写

Demo中有三个适配器示例，都继承自CrossBindingAdaptor，适配器中有内部类，继承或实现接口的方法。

```c#
public class MonoBehaviourAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType {get { return typeof(MonoBehaviour); } }

    public override Type AdaptorType {get { return typeof(Adaptor); } }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);
    }
    //为了完整实现MonoBehaviour的所有特性，这个Adapter还得扩展，这里只抛砖引玉，只实现了最常用的Awake, Start和Update
    public class Adaptor : MonoBehaviour, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;
        public Adaptor()
        {
        }
        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }
        public ILTypeInstance ILInstance { get { return instance; } set { instance = value; } }
        public ILRuntime.Runtime.Enviorment.AppDomain AppDomain { get { return appdomain; } set { appdomain = value; } }
        public void Awake() {}
        void Start(){}
        void Update(){ }
        public override string ToString(){ }
    }
}
```



### CLR重定向/热补丁

CLRRedirectionDemo，需要**在AppDomain中注册 RegisterCLRMethodRedirection**

在热更工程中调用主工程的代码时会重定向新的实现，新手可以从修改CLR生成的绑定代码开始。

例子是修改Debug.Log方法，在热更中打印的日志也能显示堆栈信息。



### 生成适配代码

类似于slua/tolua/xlua一样， 把在热更工程会用到的类添加到列表中，然后生成适配代码。

ILRuntime提供一个智能分析在热更工程使用的代码。



### 在热更工程使用协程

官方例子是调用主工程的方法来启动协程，我测试热更工程也可以调用MonoBehaviour的方法开启协程。

热更工程代码如下：

```c#
public static void RunTest()
{
	Debug.Log("热更工程中开启协程");
	CoroutineDemo.Instance.StartCoroutine(Coroutine());
}

static System.Collections.IEnumerator Coroutine()
{
	Debug.Log("开始协程,t=" + Time.time);
	yield return new WaitForSeconds(3);
	Debug.Log("等待了3秒,t=" + Time.time);
}
```



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



### 我的小结

可以把热更工程的VS项目(**HotFix_Project.csproj**)添加到Unity生成的解决方案中(**ILRuntimeDemo.sln**)，在开发期不用两个工程切换。

由于Unity 2018和Unity5的目录结构调整，**Library\UnityAssemblies\ **在Unity2018目录没有 

所以我在热更工程引用 Unity_2018_2_7f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll



**热更工程最常做的事情**

根据我们以往的项目使用Lua做为热更脚本为例，我们在热更工程做的最多的事情：

- 在热更工程中调用主工程的方法，或监听主工程的事件，监听Unity组件触发的事件。

- 热更工程调用主工程接口加载资源

- 热更工程处理UI代码逻辑

- 读取配置，对配置解析

- 热更工程中处理网络的回调

- 热更工程基本处理所有的业务逻辑


### 为什么要写适配器

因为ILRuntime可以理解为蓝大写的C#虚拟机，这个虚拟机要在运行时和Unity的脚本进行交互。

由于IOS的AOT限制，在运行时ILRuntime中是不知道Unity中的类型，所以需要我们在主工程写适配器让ILRuntime知道如何调用在Unity的代码，或当Unity的事件触发时让ILRuntime能够监听到。
