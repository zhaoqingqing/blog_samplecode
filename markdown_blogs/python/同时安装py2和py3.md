## 遇到问题和需求

我的电脑环境：先安装py2再安装py3，平时我工作中是使用python2

### 遇到问题

在cmd中输入python，进入的是py2的环境，但是通过pip install模块是安装到了python3目录下

### 需求

工作中使用pytho2，在学习python新特性时，有个便捷的方法可以切换到python3



## 安装python3时的环境变量

在安装python3时**不要勾选**添加安装目录到环境变量中，下面这几个都不要添加到环境变量的path中

1. C:\Python38

2. C:\Python38\Scripts


同时还有这几个目录也不要添加到环境变量的path中

1. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\

2. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\Scripts\

## py.exe

在安装python3.8.10时会有一个选项py launcher，这个py launcher是什么呢？install global "py" launcher to make it easier to start python

这个py.exe程序安装到了C:\Windows\py.exe

> 注意：只有python3才有py.exe

## pip.exe

安装目录下这三个pip的MD5都是一样的，说明是三个相同的文件

![image-20210908101523089](https://img2020.cnblogs.com/blog/363476/202109/363476-20210908111257436-651403112.png)

正确的方法为py2或py3安装库

## 双击执行的py脚本规范

在py脚本的第一行指定python的版本，记住要双击运行python脚本，而不要通过在cmd中调用 python xx.py来执行，因为python3没有添加到环境变量，在cmd中会以python2来执行

#! python2

#! python3

不要去改python3目录下的python.exe的命名，否则脚本中指定的python3版本会找不到python.exe

这个语法对于只有python3的环境是不会出错的。

## 参考资料

参考资料：[python2 和 python 3和多版本如何共存_KM (netease.com)](https://km.netease.com/article/223505)

