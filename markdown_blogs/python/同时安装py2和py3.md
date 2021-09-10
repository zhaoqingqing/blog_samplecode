## 遇到问题和需求

我的电脑环境：先安装py2再安装py3

问题

在cmd中输入python，进入的是py2的环境，但是通过pip install模块是安装到了python3目录下

## py.exe

在安装python3.8.10时会有一个选项py launcher，选项解释：install global "py" launcher to make it easier to start python

这个py.ex程序安装到了C:\Windows\py.exe

## 环境变量

记录**不要勾选**添加安装目录到环境变量中，以下这几个都不要添加到环境变量中

1. C:\Python38

2. C:\Python38\Scripts


同时还有这几个目录也不要添加到环境变量中

1. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\

2. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\Scripts\


## pip.exe

安装目录下这三个pip的MD5都是一样的，说明是三个相同的文件

![image-20210908101523089](https://img2020.cnblogs.com/blog/363476/202109/363476-20210908111257436-651403112.png)

正确的方法为py2或py3安装库

## py脚本规范

在py脚本的第一行指定python的版本，如下所示：

#! python2

#! python3

## 参考资料

参考资料：[python2 和 python 3和多版本如何共存_KM (netease.com)](https://km.netease.com/article/223505)

