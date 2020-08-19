## Logs Viewer

### 功能描述

Using this tool you can easily check your editor console logs inside the game itself! No need to go back to the project and do any tests to track the problems!

使用此工具，不管在手机或者Unity Editor中，你都可以很容易地检查/查看游戏输出的日志，而不需要回到项目和做任何测试跟踪问题!(开源免费)

### 功能预览
在手机上也可以很方便地查看日志，无须打开log文件
![](http://images2015.cnblogs.com/blog/363476/201608/363476-20160821234231183-1276911599.png)


![](http://images2015.cnblogs.com/blog/363476/201608/363476-20160821234038198-669809906.png)

### 开启方法

All what you have to do is to make a circle gesture using your mouse (click and drag) or your finger (touch and drag) on the mobile screen to show all these logs!

那要怎样显示此日志呢？在PC/MAC等桌面平台，你需要使用鼠标按住并画圈圈，在Mobile平台上，你需要使用手指画圈圈就可以显示日志了



### 设置步骤

To setup log viewer do the following

1. create reporter from menu (Reporter->Create) at first scene your game start .
2. then set the ” Scrip execution order ” in (Edit -> Project Settings ) of Reporter.cs to be the highest.

设置步骤
1. 在游戏的主场景(首次启动的Scene)，点击菜单栏 **Reporter** — **Create**，将会在场景中创建一个**Reporter**的Gameobject上绑定了**Reporter**和**ReporterMessageReceiver**脚本
2. 点击 **Edit** — **Project Settings** —**Scrip Execution Order**，在打开的MonoManager中，点击+号,添加Reporter




### 开源免费

AssetStore: [https://www.assetstore.unity3d.com/en/#!/content/12047]( https://www.assetstore.unity3d.com/en/#!/content/12047)

GitHub: [https://github.com/aliessmael/Unity-Logs-Viewer/]( https://github.com/aliessmael/Unity-Logs-Viewer/)

插件自带的文档：导入资源后在 `Reporter/Documentation/index.html`

或参考：https://github.com/zhaoqingqing/blog_samplecode/tree/master/unity_protobuf_sample/Assets/Reporter

### 版本纪录



### Version 1.8

    - Add Copy to clipboard.
    - Merge Fix for Unity 2019.
    - Fix ReporterModificationProcessor is annoying.
    - Fix waste ram.

### Version 1.7

    - Add Save logs button( thanks for Ahmed Shbli ).
    - Fix deprecated code for new unity.
    - Fix Warnings.
    - Fix loading scene from asset bundle error.



## 改进或建议

本文基于插件的1.6版本 (2016-06-13发布)，Unity 5.3.4f1 运行正常。

### 修改开启圈数

在**Reporter** 属性面板，修改 **Num of Circle to Sh** 的数值为其它，默认为1



### 开启时禁用NGUI的输入

如果想在开启日志窗口时，禁用NGUI的Input，可以使用添加以下。在ReporterMessageReceiver.cs

```csharp
void OnHideReporter()
	{
        //TO DO : resume your game
        //NOTE if use ngui enable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = true;
        //    UICamera.eventHandler.useTouch = true;
        //}
    }

    void OnShowReporter()
	{
        //TO DO : pause your game and disable its GUI
        //NOTE if use ngui disable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = false;
        //    UICamera.eventHandler.useTouch = false;
        //}
    }
```



### 其它注意事项
[亮兄此文中提到](http://www.maosongliang.com/archives/175)，如果场景是使用Assetbundle加载的话会出现异常，他的处理方式是把用到 string[] scenes ;的地方进行了屏蔽(注释)


我并没有详细测试使用ab场景的情况，我是通过判空来避免异常的出现，查看我的修改：https://github.com/zhaoqingqing/blog_samplecode/commit/f0eb5045cd9aa1bda7efe257647e885f6367ed14


### 竖屏显示问题

在竖屏下，默认顶部的按钮显示的不完整，但实际上，顶部栏是可以滑动的。

并且在Setting(设置)中是可以放大和缩小字体的。