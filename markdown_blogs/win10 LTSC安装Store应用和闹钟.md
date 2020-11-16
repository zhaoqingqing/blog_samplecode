因为LTSC上没有store，所以想在ltsc系统上安装uwp应用，则有两个方法

1. 安装microsoft store，从store上安装uwp应用
2. 下载uwp文件到本地，在本地离线安装

## LTSC安装Microsoft Store

安装store方法：https://github.com/kkkgo/LTSC-Add-MicrosoftStore

安装store后，从store上安装需要的uwp应用

百度上找到的一大堆教程都不如这个靠谱。



## LTSC  安装计算器和闹钟

这里介绍离线安装uwp应用，而不通过store，对于安装其它uwp应用操作也是一样的。

方法：

1. 下载计算器，解压出来得APPX和AppxBundle文件放到某个目录下，比如我放在：D:\qing\appx
2. 按win+x，选择管理员身份运行 windows powershell ，分别输入以下命令
3. 安装成功后，在开始菜单就可以找到它了

```powershell
add-appxpackage D:\qing\appx\*.appx
add-appxpackage D:\qing\appx\*.AppxBundle
```



如果安装appx失败，请在：设置- 输入"开发者"  ，找到 开发者选项 - 选择旁加载应用，修改默认选项为：Microsoft Stone应用

打开开发者选项的图文教程：https://zhuanlan.zhihu.com/p/83303028

## 命令解释

### Add-AppxPackage

用途：安装一个appx程序包
语法：Add-AppxPackage [–DependencyPath <依赖的包路径>]
举例：Add-AppxPackage D:\AppxSource\MyAppx.appx

### Get-AppxPackageManifest

用途：获取应用程序包的详细信息
举例：Get-AppxPackageManifest -Package Microsoft.WindowsAlarms

### Remove-AppxPackage

用途：卸载一个appx程序包。
语法：Remove-AppxPackage <包名>
举例：Remove-AppxPackage Microsoft.WindowsAlarms

## 遇到问题

### add-appxpackage 不可用

在cmd中输入命令，提示 ` add-appxpackage 不是内部或外部命令,也不是可运行的程序` 不要使用CMD而是使用powershell运行此命令

### appx安装后无法正常使用

闹钟应用安装后，运行程序，程序停在启动画面过1分钟之后出现闪退，安装文件如下：

Microsoft.UI.Xaml.2.0_2.1810.18003.0_x64__8wekyb3d8bbwe.Appx
Microsoft.VCLibs.140.00_14.0.26706.0_x64__8wekyb3d8bbwe.Appx
Microsoft.WindowsAlarms_2018.1120.2044.0_neutral___8wekyb3d8bbwe.AppxBundle

可能原因是公司的网络禁止访问微软的网站，这个域名下的都无法访问 https://www.microsoft.com/