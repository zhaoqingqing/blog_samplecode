## Hdg Remote Debug 远程调试

游戏运行在手机上，可以通过pc端的unity来随时修改当前场景中GameObject的变量，从而改变手机上运行时的表现。比如，我可以勾掉下图中的“Enabled”，那这个object就被立即隐藏了；或者改变"Local Position”将物体平移。

[Unity的商店中有展示图片和视频演示](https://www.assetstore.unity3d.com/en/#!/content/61863)

可参考这篇文章：[Hdg Remote Debug 远程调试，解决移动端问题的工具简介](https://zhuanlan.zhihu.com/p/30110756)

![img](https://pic1.zhimg.com/v2-b7735d3f380fd7dcd403a14146f9ccd8_r.jpg)

​      

## 手机上实时打印Unity日志

使用此工具，不管在手机或者Unity Editor中，你都可以很容易地检查/查看游戏输出的日志，而不需要回到项目和做任何测试跟踪问题!(开源免费)，也无需通过adb来查看日志文件

详情查看我之前的文章：[便捷的方式在手机上查看Unity3D的Console Log(调试信息 日志)](https://www.cnblogs.com/zhaoqingqing/p/5794009.html)

​      

## ADB连接Unity

ADB 通过USB连接时，在Unity中输入 127.0.0.1，不要输入端口号

1. IP填写127.0.0.1
2. adb forward 端口号选用55000 ~ 55511范围，或者4600 （5.x ~ 2017）
3. 4.X版本，引擎代码中写死了常量55000

具体详细细节查看：[Unity3D 秘籍之 为何你无法使用ADB USB Profiling Android Player](https://zhuanlan.zhihu.com/p/30247546)

​      

## 调试Unity.exe

通过IDA 调试 Unity.exe

IDA是一款交互式反汇编器

IDA官网：https://www.hex-rays.com/products/ida/

[IDA使用简易教程](https://www.xuenixiang.com/thread-99-1-1.html)

​     

## Windows下编辑安卓Host

在开发调试阶段，会使用ip绑定域名的方式，这里讲一下windows下便捷有效的修改安卓上的host

推荐下载 [Hosts Editor](https://apkpure.com/hosts-editor/com.nilhcem.hostseditor) ，国内的朋友可在这里下载 [Hosts Editor v1.3](http://www.pc6.com/az/115764.html)

![Hosts Editor v1.3](http://8.pic.pc6.com/thumb/up/2014-7/20147149256885980_600_0.jpg)

​     

## 手机上查看APK的包名

在windows上可以下载 [Apk Helper](http://xiazai.zol.com.cn/detail/45/443215.shtml)，把apk拖动进来，就可查看到包名，比如com.xxx.sgame

对于手机上已安装的app，安装这个App [Package Names Viewer](https://play.google.com/store/apps/details?id=com.csdroid.pkg&hl=en_US)  就可以在手机上查看包名，国内的朋友可以在这儿下载 [包名查看器(Package Names Viewer) v2.1.2083 安卓版](https://www.cr173.com/soft/710834.html)  

![img](https://pic.cr173.com/up/2018-3/15214214177798582.jpg)

​     

## 本机windows和安卓模拟器文件互传

通过adb推送和拉取，可以参考我仓库下`blog_samplecode\workflow-tools\debug(调试工具)\`的bat文件

```powershell
::从手机上拉取hosts文件到本地进行备份
"%adb%" pull /system/etc/hosts %~dp0/hosts.bak

::把本地修改的hosts文件推送到手机上
"%adb%" push  %~dp0/hosts.bak/system/etc/hosts
```



​      

## APK包名修改(制作分身)

## QuickEdit

用来查看日志，显示行号，文件内查找，多标签页，比安卓自带的html编辑器好用