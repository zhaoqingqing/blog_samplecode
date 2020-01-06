使用VS打开项目工程时，提示未安装.net framework4.7，但在**启用或关闭windows功能**里是已经勾选了.net framework 4.7的全部功能。

直接从网上下载.net framework 4.7的离线安装包，会提示已安装更高版本。

>  这台计算机中已经安装了 .NET Framework 4.7 或版本更高的更新

我的环境： window 10 x64  vs 2017 pro

### 提示已安装更高版本解决办法

此时需要下载开发包，而不是普通的安装包

下载安装.net framework的开发版或者说开发包。开发版地址https://www.microsoft.com/net/download/visual-studio-sdks
选择自己需要的版本点击Developer Pack 进行下载，下载后正常安装即可，装完后重启即可

或者在这个网站下载：https://www.microsoft.com/en-us/download/details.aspx?id=55168

下载到的两个文件如下：

> NDP47-DevPack-KB3186612-ENU.exe 84.4MB
>
> NDP47-DevPack-KB3186612-CHS.exe 13.3MB

双击安装程序的标题为：

>  Microsoft .NET Framework4.7开发人员工具包



### 查看已安装的.Net Framework版本

1. 点击 开始 - Windows系统 - 控制面板

2. 在打开的控制面板窗口中点击“程序和功能”

3. 可以看到安装的.Net Framework的版本号，如果新安装的需要重启

   


### 查看WIN10系统 自带的.net 版本

查看WIN10 自带的.net 版本：https://blog.walterlv.com/post/embeded-dotnet-version-in-all-windows.html