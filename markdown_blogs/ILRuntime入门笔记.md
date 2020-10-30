### 基础知识

官方文档：https://ourpalm.github.io/ILRuntime/ ，离线文件目录：ILRuntime\docs\source\src\v1\guide\

官方Unity3D热更例子工程：https://github.com/Ourpalm/ILRuntimeU3D/

ILRuntime肯定可以做到IOS的热更。

本文中的名词解释：

**域** : 应用程序的上下文，可以理解为使用热更之后，在游戏中存在两个域，一个是游戏主程序，另一个是热更域。

**CLR**: Unity脚本(C#)的公共运行库，公共运行环境

**Assembly-CSharp.dll**: Unity脚本(C#)的编译成的dll，非特殊目录下的脚本都放在这个dll下。安卓下可通过反射获取方法和变量。

**dll**： 指热更工程生成的dll，和Unity主工程是两个不同的dll。
<br />

### ILRuntime基本原理

<img  src="https://img2018.cnblogs.com/blog/363476/201901/363476-20190115203700346-1102207440.png"  style="zoom:100%"/>

### ILRuntime热更流程

<img  src="https://img2018.cnblogs.com/blog/363476/201901/363476-20190115203610033-2029654249.png"  style="zoom:100%"/>


### ILRuntime主要限制

<img  src="https://img2018.cnblogs.com/blog/363476/201901/363476-20190115203759436-1704888922.png"  style="zoom:100%"/>


### ILRuntime启动调试

1. ILRuntime建议全局只创建一个AppDomain，在函数入口添加代码启动调试服务

```c#
appdomain.DebugService.StartDebugService(56000)
```

2. 运行主工程(Unity工程)

3. 在热更的VS工程中 点击 - 调试 - 附加到ILRuntime调试，注意使用一样的端口

- 如果使用VS2015的话需要`Visual Studio 2015 Update3`以上版本

<br />

### 线上项目和资料

掌趣很多项目都是使用ILRuntime开发，并上线运营，比如：真红之刃，境·界 灵压对决，全民奇迹2，龙族世界，热血足球

初音未来:梦幻歌姬 使用补丁方式：https://github.com/wuxiongbin/XIL

本文流程图摘自：ILRuntime的QQ群的《ILRuntime热更框架.docx》(by a 704757217)

[Unity实现c#热更新方案探究(三)](https://zhuanlan.zhihu.com/p/37375372)

