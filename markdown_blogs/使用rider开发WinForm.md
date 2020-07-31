Rider2019.1开始支持Winform的设计器，我安装的是2019.2。

目前我工作中的C#主力IDE已经从visual studio换成Rider了，如果是开发Unity可见这篇《[使用rider做为unity的代码编辑器](https://www.cnblogs.com/zhaoqingqing/p/11649150.html)[使用rider做为unity的代码编辑器](https://www.cnblogs.com/zhaoqingqing/p/11649150.html)》

## 遇到问题

.NET Framework 3.5 出错

我在Rider中新建Winform程序，当.NET Framwrok设置为3.5时，无法打开设计器，出现下面错误，也无法Build，而把.NET Framework 选为4.7就正常了，可能是因为我本机安装了.NET 4.7的开发包，见我的这篇《[Win10安装.Net Framework4.7及更高版本](https://www.cnblogs.com/zhaoqingqing/p/12291279.html)》

```powershell
  Microsoft.Common.CurrentVersion.targets(3046, 5): [MSB3091] 任务失败，因为未找到“resgen.exe”，或未安装正确的 Microsoft Windows SDK。任务正在注册表项 HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SDKs\Windows\v8.0A\WinSDK-NetFx35Tools-x86 的 InstallationFolder 值中所指定位置下的“bin”子目录中查找“resgen.exe”。通过执行下列操作之一可以解决此问题: 1) 安装 Microsoft Windows SDK。2) 安装 Visual Studio 2010。 3) 手动向正确的位置设置上面的注册表项。4) 将正确的位置传入任务的“ToolPath”参数中。
```



