## python和pythonw

在Windows系统搭建好Python的环境后，进入Python的安装目录，大家会发现目录中有python.exe和pythonw.exe两个程序。如下图所示：

![image-20210312140234311](https://img2020.cnblogs.com/blog/363476/202103/363476-20210312140842861-334825856.png)

它们到底有什么区别和联系呢？

概括说明一下：

python.exe在运行程序的时候，会弹出一个黑色的控制台窗口（也叫命令行窗口、DOS/CMD窗口）；

pythonw.exe是无窗口的Python可执行程序，意思是在运行程序的时候，没有窗口，代码在后台执行。



.py和.pyw文件的区别也来源于python.exe和pythonw.exe的区别：

安装视窗版 Python 时，扩展名为 .py 的文件被默认为用 python.exe 运行的文件，而 .pyw文件则被默认为用 pythonw.exe 运行。

## pyw

.pyw格式是被设计用来运行开发的纯图形界面程序的，纯图形界面程序的用户不需要看到控制台窗口。在开发纯图形界面程序的时候，可以暂时把 .pyw 改成 .py ，运行时能调出控制台窗口，方便看到所有错误信息。

## pyc

至于.pyc文件，是Python解释器运行程序的过程中产生的字节码文件（也就是中间文件）。[Python什么情况下产生pyc文件？](https://www.zhihu.com/question/30296617)

## pyo

在pyc的基础上，去掉了assert和docstring

python3.5之后，无.pyo文件



## 编译器基础

.py经过编译，生成.pyc和.pyo,使用-O和-OO参数



## py文件执行后不马上关闭窗口

这里还要解释一个问题，如果.py文件直接用python.exe打开，文件被执行完成之后，视窗会立即关闭，如果想让视窗停留，给大家提供几个方法：

1. 可以在程序中import time模块，加入超长睡眠语句，如time.sleep(1800)，如果你不手动关闭视窗，视窗将会停留30min；

2. 可以调用sys和os模块，使用命令行语句pause，示例：`import os os.system("pause")`
3. 在脚本的最后加入一行 input("请按任意键继续")，这样会等待输入任意字符后才会关闭窗口



