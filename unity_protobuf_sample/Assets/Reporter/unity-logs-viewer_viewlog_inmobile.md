---
title: 在手机上查看Unity3D Console输出的Log
---

## Logs Viewer

### 功能描述

Using this tool you can easily check your editor console logs inside the game itself! No need to go back to the project and do any tests to track the problems!

使用此工具，不管在手机或者Unity Editor中，你都可以很容易地检查/查看游戏输出的日志，而不需要回到项目和做任何测试跟踪问题!



### 开启方法

All what you have to do is to make a circle gesture using your mouse (click and drag) or your finger (touch and drag) on the mobile screen to show all these logs!

那要怎样显示此日志呢？在PC/MAC等桌面平台，你需要使用鼠标按住并画圈圈，在Mobile平台上，你需要使用手指画圈圈就可以显示日志了



### 设置步骤

To setup log viewer do the following

1. create reporter from menu (Reporter->Create) at first scene your game start .
2. then set the ” Scrip execution order ” in (Edit -> Project Settings ) of Reporter.cs to be the highest.

设置步骤
1. 在游戏的主场景(首次启动的Scene)，点击菜单栏 **Reporter** —— **Create**，将会在场景中创建一个**Reporter**的Gameobject上绑定了**Reporter**和**ReporterMessageReceiver**脚本
2. 点击 **Edit** —— **Project Settings** ——**Scrip Execution Order**，在打开的MonoManager中，点击+号,添加Reporter




### 下载地址

AssetStore: [https://www.assetstore.unity3d.com/en/#!/content/12047]( https://www.assetstore.unity3d.com/en/#!/content/12047)

GitHub: [https://github.com/aliessmael/Unity-Logs-Viewer/]( https://github.com/aliessmael/Unity-Logs-Viewer/)

详细的功能文档：导入资源后在 `Reporter/Documentation/index.html`

https://github.com/zhaoqingqing/blog_samplecode/tree/master/unity_protobuf_sample/Assets/Reporter

## 改进或建议

本文基于1.6版本 (2016-06-13发布)

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



### 使用AssetBundle加载场景



### 扩展资料

[http://www.maosongliang.com/archives/175](http://www.maosongliang.com/archives/175)

