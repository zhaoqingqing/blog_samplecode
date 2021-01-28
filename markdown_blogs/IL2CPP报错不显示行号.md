目前我们在Unity2018.4.15中使用IL2CPP出的安卓包，报错是不会显示行号

Mono+Debug才会显示行号

Mono+Release也不会显示具体的行号

可参考这篇文章《[unity接入bugly无法显示C#错误行号](https://blog.csdn.net/wanzi215/article/details/104225703)》，实际就算未接入bugly也会无法显示错误行号

unity官方说正在开发release+l2cpp版提供明确出错行号的功能,预计会在unity2020的某个版本里发布，论坛链接：

https://forum.unity.com/threads/file-and-line-numbers-in-stack-trace.367958/

报错堆栈不显示行号

```powershell
[ERRO] 09:37:33'680(21:37:33)(33837,275) TaskPanel.OnClosePanel error:Object reference not set to an instance of an object.,  at ObjectAppear.InitAppear (UnityEngine.GameObject go) [0x00000] in <00000000000000000000000000000000>:0 
  at ObjectAppear.Init (UnityEngine.GameObject go, Entity.ObjData objData, ObjBehaviour master, System.Boolean visible, System.Boolean isInUI, System.Boolean foceHeightQuality, System.Boolean sampleShow) [0x00000] in <00000000000000000000000000000000>:0 
  at ObjBehaviour.CheckAppearVisible2 () [0x00000] in <00000000000000000000000000000000>:0 
  at ObjBehaviour.OnChangeAppearData () [0x00000] in <00000000000000000000000000000000>:0 
  at NpcControl.EndTalk () [0x00000] in <00000000000000000000000000000000>:0 
  at TaskPanel.OnClosePanel () [0x00000] in <00000000000000000000000000000000>:0 
  at MyPanel.afterHide (System.Boolean doDistroy, System.Boolean clearResource) [0x00000] in <00000000000000000000000000000000>:0 
  at MyPanel.immediatelyClose () [0x00000] in <00000000000000000000000000000000>:0 
  at MyPanel.OnLeaveScene () [0x00000] in <00000000000000000000000000000000>:0 
  at SceneControl.LeaveLastScene (ISceneBehavior new_behaviour) [0x00000] in <00000000000000000000000000000000>:0 
  at SceneControl+<DoEnterScene>d__52.MoveNext () [0x00000] in <00000000000000000000000000000000>:0 
  at MyTask+TaskUnit.Update () [0x00000] in <00000000000000000000000000000000>:0 
  at MyTask.Update () [0x00000] in <00000000000000000000000000000000>:0 
  at MyTask.UpdateAll (System.Int32 time) [0x00000] in <00000000000000000000000000000000>:0 
  at App.FireUpdate () [0x00000] in <00000000000000000000000000000000>:0, stackTrance:, tmplog:

```

## 两者对比

从个人在项目中尝试和得知的一些信息，稍微总结一下：

### MONO的好处：

1. 久经考验
2. 出包速度快
3. 包体略小
4. 支持安卓上dll动态载入程序集热更新（IL2CPP完全不支持，但可以通过hook so的方式来实现）

### IL2CPP的好处：

1. 没有堆内存只涨不降的问题（据说某些大厂内部有质量验收标准，这一条会有很大优势）
2. C#侧的**计算密集型算法**性能暴增N倍（我们项目的同地图寻路、自动建筑位置规划等算法的速度都有3倍以上提升）
3. lua热更无任何问题，反射调用还是导出式调用都很完美支持（应该不能算优点，但确实在我的预料之外）

说一下IL2CPP的问题吧：

1. 构建时间长好多，安卓NDK的windows版工具链怎么就能性能这么低呢！（AMD 16核32线程撕裂者走起，NDK编译时完美支持并行化的，核多了编译慢也不是事儿了）
2. IL2CPP后，如果仅编译ARMv7的版本，部分模拟器无法启动游戏，或者是mumu模拟器运行非常慢，比如加载资源会比正常的慢4倍左右，因为模拟器的架构是x86。用FAT（ARMv7 + x86）就可以了，而且模拟器上运行也非常流畅了，当然包又大了20多MB

## 项目经验

关于代码占用的大小(以我们一个纯C#开发的RPG游戏为例)，出mono包，所有代码Assembly-CSharp.dll大小为11.2MB，而il2cpp则libil2cpp.so原始大小为102MB，打包在包体内的压缩后大小是25MB，我看王者荣耀安卓版的libil2cpp也是102MB

我们2019年立项的项目，正式包是使用IL2CPP出包

mono模式已经不可能支持64位了，面向未来，IL2CPP是唯一的选项，Unity现在已经做得很好了

也可参考UWA论坛上其它朋友的对比： [Mono和IL2CPP选哪个更合适？](https://answer.uwa4d.com/question/5abdea21425802635474fbb4)