在我之前中博客中有篇关于win 10的入门文章：[Win10 使用笔记](https://www.cnblogs.com/zhaoqingqing/p/6934891.html)，本篇写于三年后的2020年，记录近年我在win 10上常用软件和使用习惯。

## 微软常用运行库合集

微软官网：[最新支持的 Visual C++ 下载](https://support.microsoft.com/zh-cn/help/2977003/the-latest-supported-visual-c-downloads)

下载地址：[[Windows]微软常用运行库合集 2020.04.10](https://www.52pojie.cn/thread-1153336-1-1.html)

这些运行库是采用 Microsoft Visual Studio 20XX 编写的软件必须使用的公用 DLL 运行库，相当于程序的字典文件。
某些网上和论坛的部分精简软件没有附带这些公用 DLL，所以安装这些运行库是系统安装后第一件要做的事情。
某些程序在 64 位系统下运行任然需要 32 位版本的运行库，因为程序是 32 位程序，需要使用 32 位运行库，典型的例子比如 QQ。

包含以下内容

Visual c++ 运行库 ，缺少会出现错误提示：“配置不正确”或其他错误；没有找到 Msvcp100.DLL



## Dism ++

[Dism++，也许是最强的实用工具系统维护工具](https://www.chuyu.me/)

下载地址：https://github.com/Chuyu-Team/Dism-Multi-language/releases/

## 应用类软件

> [Snipaste](https://zh.snipaste.com/download.html)

截图/贴图软件



> [微软极品工具箱-Sysinternals Suite](https://www.cnblogs.com/zhaoqingqing/p/5641934.html)

极品工具箱中最常用使用 Process Explorer



## 对win10系统进行瘦身

Win10 系统自带了一些官方的内置应用，如人脉、Groove、消息、天气、地图等，有时还会自动安装推荐的应用程序和游戏到电脑上，而其中很多应用我们并不需要。

下面就介绍下如何卸载 Win10 的自带应用，并且彻底禁止 Win10 自动安装推荐应用的方法。

### 禁止 Win10 自动安装推荐应用

------

使用 Dism++ 的系统优化功能来禁止。绿色软件，下载并解压 [Dism++](https://link.zhihu.com/?target=https%3A//www.chuyu.me/zh-Hans/)，双击运行 Dism++.exe。

系统优化 -> 开始菜单以及Windows体验，如下图，禁止所有建议推广和应用自动安装设置。

![img](https://pic4.zhimg.com/80/v2-a77699461dd551f97c73713ddf688fdb_720w.jpg)

更多优化设置：[使用 Dism++ 全方位优化我们的电脑](https://zhuanlan.zhihu.com/p/37664732)

### 卸载 Win10 自带应用

大部分自带应用都可在 “设置 -> 应用 -> 应用和功能” 中直接点击 “卸载” 按钮卸载，但也有些应用无法卸载。

直接使用专业的卸载工具 [Geek Uninstaller](https://link.zhihu.com/?target=https%3A//geekuninstaller.com/)，绿色软件，解压即用。

点击 查看 -> Windows Store Apps，右键选择应用卸载。

## 低配电脑安装WIN10

我所说的低配电脑指，内存<=8G，没有SSD或系统不是安装在SSD，总体来说硬件配置较低的电脑，但也想体验WIN10系统，我个人建议如下：

安装WIN10 LTSC版本的操作系统

安装释放内存软件 [Mem Reduct](https://www.henrypp.org/product/memreduct) ，或 [飞扬时空汉化版本](http://blog.sina.com.cn/s/blog_89a729a40102xh09.html)

使用火绒代替 windows defender

使用Dism++进行系统优化和设置

卸载win10自带应用，安装2年前旧版本的软件



## PowerToys

下载地址：https://github.com/microsoft/PowerToys/releases

**注：要求win10 1803（build17134）及更新的版本**

**Windows 10 PowerToys 小工具**[合集](https://www.iplaysoft.com/tag/%E5%90%88%E9%9B%86)首批上线的实用程序有 **FancyZones** (增强型窗口管理器) 和[键盘](https://www.iplaysoft.com/tag/%E9%94%AE%E7%9B%98)党最爱的 **Windows Key Shortcut Guide** (Windows 键快捷键指南) 这两款。安装好 PowerToys 之后即可选择启用 / 设置它们。

根据微软官方的预告，后面 PowerToys 还将陆续上线“[批量](https://www.iplaysoft.com/tag/%E6%89%B9%E9%87%8F)文件改名工具”、“[GIF](https://www.iplaysoft.com/tag/gif) 动画录制器”、“进程结束工具”、“最大化窗口到新桌面 (类似 [macOS](https://www.iplaysoft.com/os/mac-platform))”等工具，大家可以期待一下

