## 前言

公司配备了两台电脑，两台电脑都是安装的win10系统，一台是磁盘占用高，另一台是内存可用低。

具体情况如下：

一台外网机 8g内存，安装win10 专业版，开机一天后经常出现内存不够用，但其实都没有打开任何软件。

另一台内网开发机器，16内存，win10专业版系统，常常会出现磁盘占用特别高，这两台电脑都未安装SSD硬盘。

两台电脑安装的win10版本都是1809 企业版 LTSC

注：本文的方法或多或少可以提供一些帮助，当然最简单的直接方法就是加装SSD硬盘和加装内存条。

​      

## 相同进程多

比如下面几种类型的进程有非常多

- SearchUI

- svchost.exe 有二十多个进程

svchost是不同的服务的进程，都放在svchost上启动，所以svchost进程特别多是正常的。

另一个很多进程的就是Miscrosoft开头的，经尝试卸载掉：Windows Software Development Kit - Windows 10.0.17763.132，然后重启内存占用从78%降到30%

​      

## 卸载最近安装的程序和补丁

如果是最近一段才出现的，而先前不会，则通过来判断是那部分软件出问题了，卸载最近安装和不用软件，包括最近安装的补丁更新，然后重启电脑

​     

## 强制禁用服务

按WIN+R，输入CMD，打开命令行，(经测试在power shell下无效)，输入这个命令就可以禁用

```powershell
sc config "服务名称" start= disabled
```

sc命令中＝号后面都有一个空格，＝号前面没有空格

如果出现：[SC] OpenService 失败 5:，因为权限不够，要以管理员身份运行

按下Win+s，输入CMD，右键选择以管理员身份运行。

## 16G以上关闭虚拟内存

**在16G内存的机器上关闭虚拟内存后，低于16G不建议关闭**

(注：如果物理内存在8G或8G以下不建议使用本方案!)

win8/8.1默认开启虚拟内存，他会把部分应用的内存转储到硬盘中，避免物理内存不够用的情况。中低端的电脑开启虚拟内存，可以提高运行效率。不过，在物理内存充沛的情况下，用虚拟内存不仅没有效果，反而会有硬盘占用率高的“副作用”，以下是关闭方法：

1、右击“计算机”选择属性，打开之后选择“高级系统设置”

2、点击“性能”中的设置按钮;

3、选择“高级”，点击虚拟内存中的“更改”，将“自动管理驱动器的分页文件大小”对勾去掉，点击下面的“无分页文件”，点击“设置”并“确定”即可。

​      

### realtek声卡驱动过旧

截止2020-2-26，声卡驱动最新版本是(2019-9-24) R2.8.2 
我下了个驱动精灵扫描了一下，让我更新声卡驱动。更新完毕后，声卡驱动是2014年的版本。明显不符合win10，我就去realtek官网找最新驱动安上重启，然后困扰多年的问题终于解决了。。。

如果你设备管理器有realtek high definition audio，情况和我一样，那十有八九都是这个设备驱动出问题。

在这里下载最新驱动：https://www.realtek.com/en/component/zoo/category/pc-audio-codecs-high-definition-audio-codecs-software

进去点击第二个High Definition Audio Codecs (Software)勾选协议然后点击next如果你电脑是win10 64位，直接下载表格中第二个文件进行安装

上述网址无法打开的，可以百度搜索：realtek high definition audio driver win 10 下载

https://oemdrivers.com/sound-realtek-audio%20driver-windows-64-bit

​      

## 关闭不需要的服务

不建议关闭索引（Windows Search）对于C盘这样的系统盘来说，也可以关闭内容索引来提高索引性能（具体方法：右击“我的电脑”→“目标驱动器”→“属性”，取消“”复选框后确定即可），以上这些都能让索引服务跑得更快。在控制面板中可以修改索引选项，，注意：关闭索引后win+s无法搜索到已添加的索引


1. **SuperFetch**超级预读服务主要是为企业应用与大型协作软件而设计的，个人用户没有必要开启。
2. 关闭Ipv6
3. 关闭 HomeGroupProvider ， HomeGroupListener
4. 关闭自动维护计划任务
5. 关闭Windows Defender
    在搜索栏输入gpedit.msc打开组策略编辑器，定位到“计算机配置-管理模板-Windows组建-Windows Defender-扫描”中的“指定每周的不同天运行计划扫描”配置为“已启用”根据帮助中的内容选择设置。或直接在Windows Defender设置内在管理选项中将其关闭。
6. 更新驱动 http://tieba.baidu.com/p/4359125660?pn=1
7. 停止 Diagnostics Tracking Service 服务
8. 停止**Connected User Experiences and Telemetry**

### SgrmBroker

服务名称：SgrmBroker 显示名称：System Guard 运行时监视器代理 内存占用：101mb

修改方法：

注册表中找到：计算机\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SgrmBroker

DelayedAutoStart从1改成3

Start从2改成3

### sysMain

服务名称：sysMain ，显示名称：服务主机 sysMain ，内存占用：98MB

在服务中找到，并禁用

## 内存压缩

右键点击菜单->Windows PowerShell(管理员)->并运行该命令
> Disable-MMAgent -mc

并重新启动。这将禁用压缩(可以解决内存占用过多问题)。如果没有用，请以admin身份再次运行powershell并运行该
> Enable-MMAgent -mc
> 命令恢复压缩内存。



注：在我的电脑上关闭后未解决问题

​            

## BIOS设置SATA

**安装SSD后， 在主板的BIOS进行设置，在SATA中设置默认IDE为AHCI**

> **怎么查看SATA硬盘是否处于AHCI开启状态?** 
>
> 1. 右键我的电脑 - 管理 - 打开设备管理器
> 2. 定位到 IDE ATA/ATAPI控制器，展开可以看到当前的状态，类似文字为：Intel XXX SATA CHCI Controller

​      

下面说一下这两种不同的磁盘模式区别

**SATA/AHCI驱动** Intel RST(Rapid Storage Technology)即英特尔快速存储技术，早期的版本称Intel Matrix Storage Manager（简称IMSM）。该程序整合了磁盘管理程序控制台及SATA、AHCI、RAID驱动程序，主要用于Intel芯片组的磁盘管理、应用支持、状态查看等应用

**AHCI**
高级主机控制器接口 （ 英文 ： Advanced Host Controller Interface ， 缩写 ： AHCI ），是一种由 英特尔 制定的技术标准，它允许软件与 SATA 存储设备沟通的硬件机制，可让SATA存储设备激活高级SATA功能，例如 原生指令队列 及 热插拔

**SATA**
串行ATA （ Serial ATA: Serial Advanced Technology Attachment ）是 串列SCSI （SAS: Serial Attached SCSI）的孪生兄弟

​      

## 其它资料

- SSD软件

  > SSD优化软件ssdfresh

- 普通硬盘是否有必要4K对齐？

  > 4k对齐有一定性能提升： http://bbs.zol.co m.cn/diybbs/d34036_246.html

- SSD优化

  > 让SSD速度飞起来 固态硬盘优化技巧大全  http://www.pc841.com/Win10/201504-45226_7.html
  >
  > 三星SSD固态硬盘优化神器 Magician 评测  http://pcedu.pconline.com.cn/337/3370826_all.html#content_page_2

  

     

更多win10磁盘占用100%请参考： http://www.windows10.pro/win10-usage-of-your-disk-100/
http://www.cnblogs.com/liweis/p/5179420.html