## 遇到问题和需求

我的电脑环境：先安装py2再安装py3，平时我工作中是使用python2，如何保证两个版本共存且让代码来选择要使用的版本。

### 遇到问题

在cmd中输入python，进入的是py2的环境，但是通过pip install模块是安装到了python3目录下

### 需求

工作中使用pytho2，在学习python新特性时，有个便捷的方法可以切换到python3。希望可以通过双击py文件来执行，而且可以区分不同的版本来执行

## 解决方案

### 安装python3时的环境变量

在安装python3时**不要勾选**添加安装目录到环境变量中，下面这几个都不要添加到环境变量的path中

1. C:\Python38

2. C:\Python38\Scripts


同时不要把这几个目录添加到环境变量的path中

1. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\

2. C:\Users\zhaoqingqing01\AppData\Local\Programs\Python\Python38\Scripts\



### py脚本规范

在py脚本的第一行指定python的版本，记住要双击运行python脚本，而不要通过在cmd中调用 python xx.py来执行，因为python3没有添加到环境变量，在cmd中会以python2来执行

#! python2

#! python3

不要修改改python3目录下的python.exe的名字，否则脚本中指定的python3版本会找不到python.exe

加上这行之后对于只安装python3的环境也是不会出错的。

### 参考资料

参考资料：[python2 和 python 3和多版本如何共存_KM (netease.com)](https://km.netease.com/article/223505)

## py.exe

在安装python3.8.10时会有一个选项py launcher，这个py launcher是什么呢？install global "py" launcher to make it easier to start python

这个py.exe程序安装到了C:\Windows\py.exe

> 注意：只有python3才有py.exe

- 在C:\Windows下面; 还有一个pyw.exe 是窗口版本
- py除了可以`py -2 xxx.py`, 还可以`py -3.5 xxx.py`
- 官方认为, py文件的默认打开方式应该是py.exe

### 通过py.exe来指定python版本

示例：

```shell
C:\Windows\System32>py -3
Python 3.8.10 (tags/v3.8.10:3d8993a, May  3 2021, 11:48:03) [MSC v.1928 64 bit (AMD64)] on win32
Type "help", "copyright", "credits" or "license" for more information.
>>>
```

```shell
C:\Users\zhaoqingqing01>py -2
Python 2.7.18 (v2.7.18:8d21aa21f2, Apr 20 2020, 13:19:08) [MSC v.1500 32 bit (Intel)] on win32
Type "help", "copyright", "credits" or "license" for more information.
>>>
```



## pip.exe

安装目录下这三个pip的MD5都是一样的，说明是三个相同的文件

![image-20210908101523089](https://img2020.cnblogs.com/blog/363476/202109/363476-20210908111257436-651403112.png)

正确的方法为py2或py3单独安装库，参考文章：《[为不同版本python安装pip的正确做法 - 赵青青 - 博客园 (cnblogs.com)](https://www.cnblogs.com/zhaoqingqing/p/13875377.html)》

> py -2 -m pip install XXXX

> py -3 -m pip install XXXX

## #! python3 失效不识别

在我安装python2 x64版本之后，#! python3 这条指令就失效了，打印出来的sys.version为python2 x64

测试代码：

```python
#! python3
# coding=utf-8

import sys
import os
print(sys.version)
os.system('pause')
#输出结果：2.7 (r27:82525, Jul  4 2010, 07:43:08) [MSC v.1500 64 bit (AMD64)]
```

然后我把python2 x64的版本卸载后，.py文件的打开方式就丢失了，所以可以认为是它修改了.py的打开方式。

- 官方认为, py文件的默认打开方式应该是py.exe，完整路径：C:\Windows\py.exe

把py文件的打开方式修改为py.exe后一切都正常了，我是同时安装了python2和python3，然后查看py.exe的版本号是3.x

## 是否需要python.exe才能识别#!python2和#!python3？

是否需要把python.exe放在C:\Windows\下才能正常识别这两个指令#!python2和#!python3？

> 结论：不需要。但是要把.py文件的打开方式修改为C:\Windows\py.exe。这样在双击py就可以正确识别是使用python2还是python3来执行

这个exe的源码如下(编译为32位的C程序)：

```c
int main(int argc, char *argv[])
{
	std::string s = "py ";
	for (int i = 1; i < argc; ++i)
	{
		s += " ";
		s += argv[i];
	}
	printf(s.c_str());
	printf("\n");
	system(s.c_str());
    return 0;
}
```

