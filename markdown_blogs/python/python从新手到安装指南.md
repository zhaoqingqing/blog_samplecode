在python领域笔者是从官方文档自学入门，本文适用于windows 操作系统，基于Inter和amd的CPU(涵盖市面80%的电脑)

## 下载和安装python

对于window操作系统的初学者，在浏览器输入 [python官网下载页面](https://www.python.org/downloads/windows/)，请下载这个文件 [Windows x86-64 executable installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2-amd64.exe)

本文写于2020-4-26，目前官网最新版本3.8.2上述下载链接正是指向于新release版本。

### 安装python

官网安装文档：[在Windows上使用 Python](https://docs.python.org/zh-cn/3/using/windows.html)

如果你是新手，使用你安装QQ/微信的经验，双击下载文件，点击下一步 - 下一步 - OK完成安装。

### 安装成功

安装成功后，按下Win+R，输入cmd，在控制台中输入python，看到python版本号，则安装成功，示例如下

```powershell
(c) 2019 Microsoft Corporation。保留所有权利。

C:\Users\qing>python
Python 3.8.2 (tags/v3.8.2:7b3ab59, Feb 25 2020, 23:03:10) [MSC v.1916 64 bit (AMD64)] on win32
Type "help", "copyright", "credits" or "license" for more information.
>>>```
```



### python官网各版本对比

在下载列表中，还提供了其它下载选项，我把官网信息翻译过来。

1. embeddable zip file 嵌入式版本，可以集成到其它应用或语言中

2. executable installer 可执行文件(*.exe)，也就是我们最常用的QQ/微信方式安装

3. web-based installer 联网在线完成安装

   ​      

| Version                                                      | Operating System | Description             | File Size |
| :----------------------------------------------------------- | :--------------- | :---------------------- | :-------- |
| [Gzipped source tarball](https://www.python.org/ftp/python/3.8.2/Python-3.8.2.tgz) | Source release   |                         | 24007411  |
| [XZ compressed source tarball](https://www.python.org/ftp/python/3.8.2/Python-3.8.2.tar.xz) | Source release   |                         | 17869888  |
| [macOS 64-bit installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2-macosx10.9.pkg) | Mac OS X         | for OS X 10.9 and later | 30023420  |
| [Windows help file](https://www.python.org/ftp/python/3.8.2/python382.chm) | Windows          |                         | 8507261   |
| [Windows x86-64 embeddable zip file](https://www.python.org/ftp/python/3.8.2/python-3.8.2-embed-amd64.zip) | Windows          | for AMD64/EM64T/x64     | 8017771   |
| [Windows x86-64 executable installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2-amd64.exe) | Windows          | for AMD64/EM64T/x64     | 27586384  |
| [Windows x86-64 web-based installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2-amd64-webinstall.exe) | Windows          | for AMD64/EM64T/x64     | 1363760   |
| [Windows x86 embeddable zip file](https://www.python.org/ftp/python/3.8.2/python-3.8.2-embed-win32.zip) | Windows          |                         | 7147713   |
| [Windows x86 executable installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2.exe) | Windows          |                         | 26481424  |
| [Windows x86 web-based installer](https://www.python.org/ftp/python/3.8.2/python-3.8.2-webinstall.exe) | Windows          |                         | 1325416   |



如果你和我一样对CPU也感兴趣，那么应该注意到表格中有AMD64和EM64T这两个关键词，贴一下维基百科中关于CPU架构的内容

> **x86-64**（ 又称**x64**，即英文词**64**-bit e**x**tended，64位拓展 的简写）是[x86](https://zh.wikipedia.org/wiki/X86)[架构](https://zh.wikipedia.org/wiki/指令集架構)的[64位](https://zh.wikipedia.org/wiki/64位)拓展，[向后兼容](https://zh.wikipedia.org/wiki/向後相容)于[16位](https://zh.wikipedia.org/wiki/16位)及[32位](https://zh.wikipedia.org/wiki/32位)的x86架构。x64于1999年由[AMD](https://zh.wikipedia.org/wiki/AMD)设计，AMD首次公开64位集以扩展给x86，称为“**AMD64**”。其后也为[英特尔](https://zh.wikipedia.org/wiki/英特爾)所采用，现时英特尔称之为“**Intel 64**”，在之前曾使用过“Clackamas Technology” (CT)、“IA-32e”及“EM64T”。
>
> [苹果公司](https://zh.wikipedia.org/wiki/蘋果公司)和[RPM包管理员](https://zh.wikipedia.org/wiki/RPM套件管理員)以“x86-64”或“x86_64”称呼此64位架构。[甲骨文公司](https://zh.wikipedia.org/wiki/甲骨文公司)及[Microsoft](https://zh.wikipedia.org/wiki/Microsoft)称之为“x64”。[BSD](https://zh.wikipedia.org/wiki/BSD)家族及其他[Linux发行版](https://zh.wikipedia.org/wiki/Linux發行版)则使用“amd64”，32位版本则称为“i386”（或 i486/586/686），[Arch Linux](https://zh.wikipedia.org/wiki/Arch_Linux)用x86_64称呼此64位架构。

出处：[x86-64](https://zh.wikipedia.org/wiki/X86-64)

​     

## 选择python2还是python3

python3不兼容python 2，但python2也添加了一些python3的功能，如果你是像我一样的从新手到入门，想用python来处理数据、提高工作效率，我强烈建议学习python3。假设你是公司项目需要用到pyton，那么根据你们公司旧项目的python代码来选择版本。

python 3.x 系列，比如3.5, 3.6在同一个月更新两个不同的版本，

而且2.7 也是一直有更新，是为了提供对旧项目的维护支持。

​      

## 安装多个版本的python

参考这篇：《[安装多个版本的python环境](https://www.cnblogs.com/weew12/p/10583046.html)》，注意事项：在安装时，勾选把python安装目录添加到Path中，安装多版本后需要对python.exe和pythonw.exe进行重命名，这样在CMD可以使用不同版本的python

pycharm中选择对应版本的python，参考：《[在pycharm中切换python版本的方法](https://blog.csdn.net/sgfmby1994/article/details/77876873)》

## 验证安装的python是64还是32位

一般来说，在命令行中输入python就会打印出python的版本，如果你还想进一步确认，使用以下代码

```python
import sys, platform
print(platform.architecture())

input("Press <enter>")
```





​      

## python开发工具

python开发工具我推荐 jetbrains 家的 [pycharm](https://www.jetbrains.com/pycharm/download/) 

pycharm提供了免费开源的社区版本，如果有付费能力的请购买专业版。如果是学生或教师可申请免费使用。

