### 问题描述

使用VS打开项目工程时，提示未安装.net framework4.7，但在**启用或关闭windows功能**里已经勾选了.net framework 4.7的全部功能。

直接从网上下载.net framework 4.7的离线安装包，会提示已安装更高版本。

>  这台计算机中已经安装了 .NET Framework 4.7 或版本更高的更新

我的环境： window 10 x64  vs 2017 pro

​      

### 提示已安装更高版本解决办法

此时需要下载开发包，而不是普通的安装包

**下载地址一**

在下面网站下载：

1. https://www.microsoft.com/en-us/download/details.aspx?id=55168

2. [Download .NET Framework 4.7.2 | Free official downloads (microsoft.com)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)

下载到的两个文件如下：

> NDP47-DevPack-KB3186612-ENU.exe 84.4MB
>
> NDP47-DevPack-KB3186612-CHS.exe 13.3MB

​      

认准：Developer pack 非runtime

**下载地址二**

下载安装.net framework的开发版或者说开发包。

开发版地址：https://www.microsoft.com/net/download/visual-studio-sdks
选择自己需要的版本点击 **Developer Pack** 进行下载，下载后正常安装即可，装完后重启即可

​      

> 特别说明：双击安装程序的标题为
>
> Microsoft .NET Framework4.7开发人员工具包

​      

### 查看已安装的.Net Framework版本

1. 点击 开始 - Windows系统 - 控制面板

2. 在打开的控制面板窗口中点击“程序和功能”

3. 可以看到安装的.Net Framework的版本号，如果新安装的需要重启

   ​      


### 查看WIN10系统 自带的.net 版本

查看WIN10 自带的.net 版本：https://blog.walterlv.com/post/embeded-dotnet-version-in-all-windows.html

| Windows 10 名称                 | Windows 版本      | 开发代号 | 自带的 .NET Framework 版本 |
| :------------------------------ | :---------------- | -------- | -------------------------- |
| 预览中                          | 预览中            | 20H1     | —                          |
| November 2019 Update            | 10.0.18363 (1909) | 19H2     | .NET Framework 4.8         |
| Windows 10 May 2019 Update      | 10.0.18362 (1903) | 19H1     | .NET Framework 4.8         |
| Windows 10 October 2018 Update  | 10.0.17176 (1809) | RS5      | .NET Framework 4.7.2       |
| Windows 10 April 2018 Update    | 10.0.17134 (1803) | RS4      | .NET Framework 4.7.2       |
| Windows 10 Fall Creators Update | 10.0.16299 (1709) | RS3      | .NET Framework 4.7.1       |
| Windows 10 Creators Update      | 10.0.15063 (1703) | RS2      | .NET Framework 4.7         |
| Windows 10 Anniversary Update   | 10.0.14393 (1607) | RS1      | .NET Framework 4.6.2       |
| Windows 10 November Update      | 10.0.15063 (1511) | TH2      | .NET Framework 4.6.1       |
| Windows 10                      | 10.0.10240 (1507) | TH1      | .NET Framework 4.6         |