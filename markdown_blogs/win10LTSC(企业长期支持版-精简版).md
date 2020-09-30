### 我的环境

安装版本：win10企业版 LTSC 1809 内部版本号：17763.316 安装补丁后的内部版本号：117763.1457

安装日期：2020-3-30

###  系统特性

1. 无edge
2. 无小娜语音助手
3. 无Microsoft Store(应用商店)
4. 无预装的UWP应用
5. 补丁更新很长



###  硬件配置

电脑型号	技嘉 H110M-DS2V 台式电脑  (扫描时间：2020年03月31日)
操作系统	Windows 10 64位 ( DirectX 12 )
	
处理器	英特尔 Core i5-6500 @ 3.20GHz 四核
主板	技嘉 H110M-DS2V-CF ( 100 Series/C230 Series 芯片组 Family - A143 )
内存	8 GB ( 金士顿 DDR4 2400MHz )
主硬盘	西数 WDC WD10EZEX-08WN4A0 ( 1 TB / 7200 转/分 )
显卡	英特尔 HD Graphics 530 ( 128 MB / 技嘉 )
显示器	戴尔 DELD0A2 DELL SE2416HM ( 24 英寸  )
声卡	瑞昱 ALC887 @ 英特尔 High Definition Audio 控制器
网卡	瑞昱 RTL8168/8111/8112 Gigabit Ethernet Controller / 技嘉

另一台电脑安装Win10 企业版 增加的配置，内存增加8G，增加了 1050TI显卡



### 使用体验

初步使用三天的感受的确比win10专业版流畅很多

使用半年之后，低配置机器安装LTSC 比高配置的机器还要更加流畅，且不需要定时关机。



### 存在问题

在非win自带的资源管理器下点击右键响应很慢，比如在Total Commander和firefox双击下载文件时，弹出操作菜单非常慢。使用过几天之后，就恢复正常了。



每次运行不带数字签名或从网络下载的exe文件时，都会弹出“ 打开文件安全警告，有个勾勾，打开此文件前总是询问”，解决办法：http://www.pc6.com/infoview/Article_64403.html

### LTSC安装MicrosoftStore

方法：https://github.com/kkkgo/LTSC-Add-MicrosoftStore

### LTSC  安装计算器和闹钟(UWP)

WIN10LTSC版非常受欢迎，但计算器却是旧版的，那如何在LTSC上安装UWP版本计算器和闹钟且无需安装微软应用商店呢？

方法：

1. 下载计算器，解压出来得APPX和AppxBundle文件放到某个目录下，比如我放在：D:\qing\appx
2. 管理员身份运行windows powershell ，分别输入以下命令
3. 安装成功后，在开始菜单就可以找到它了

```powershell
add-appxpackage D:\qing\appx\*.appx
add-appxpackage D:\qing\appx\*.AppxBundle
```



如果安装appx失败，请在设置- 输入开发者  - 开发者选项 - 选择旁加载应用，默认选项为：Microsoft Stone应用

打开开发者选项图文教程：https://zhuanlan.zhihu.com/p/83303028

### 命令解释

Add-AppxPackage

用途：安装一个appx程序包
语法：Add-AppxPackage [–DependencyPath <依赖的包路径>]
举例：Add-AppxPackage D:\AppxSource\MyAppx.appx

Get-AppxPackageManifest

用途：获取应用程序包的详细信息
举例：Get-AppxPackageManifest -Package Microsoft.WindowsAlarms

Remove-AppxPackage

用途：卸载一个appx程序包。
语法：Remove-AppxPackage <包名>
举例：Remove-AppxPackage Microsoft.WindowsAlarms

### add-appxpackage 不可用

提示 ` add-appxpackage 不是内部或外部命令,也不是可运行的程序` 直接使用CMD输入命令就会提示不可用，那么请使用powershell运行此命令

### appx安装后无法正常使用

闹钟应用安装后，运行程序，程序停在启动画面过1分钟之后出现闪退，安装文件如下：

Microsoft.UI.Xaml.2.0_2.1810.18003.0_x64__8wekyb3d8bbwe.Appx
Microsoft.VCLibs.140.00_14.0.26706.0_x64__8wekyb3d8bbwe.Appx
Microsoft.WindowsAlarms_2018.1120.2044.0_neutral___8wekyb3d8bbwe.AppxBundle