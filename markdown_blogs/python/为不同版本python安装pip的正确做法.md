想学习Python3，但是暂时又离不开Python2。在Windows上如何让它们共存呢？



目前国内网站经常会让大家把其中一个python.exe改个名字（嗯，我也这样讲过，在此纠正一下），这样区分开两个可执行文件的名字，但是这样做有一个重大的隐患，就是修改了名字的那个python对应的pip将无法使用。



## 官方的解法是什么？



事实上这个问题几年以前Python社区就给出了官方解决方案，只不过国内一直没有注意到罢了。

我们在安装Python3（>=3.3）时，Python的安装包实际上在系统中安装了一个启动器py.exe，默认放置在文件夹C:\Windows\下面。这个启动器允许我们指定使用Python2还是Python3来运行代码（当然前提是你已经成功安装了Python2和Python3）。



如果你有一个Python文件叫 hello.py，那么你可以这样用Python2运行它

> py -2 hello.py



类似的，如果你想用Python3运行它，就这样

> py -3 hello.py

每次运行都要加入参数-2/-3还是比较麻烦，所以py.exe这个启动器允许你在代码中加入说明，表明这个文件应该是由python2解释运行，还是由python3解释运行。说明的方法是在代码文件的最开始加入一行

> #! python2

或者

> #! python3



分别表示该代码文件使用Python2或者Python3解释运行。这样，运行的时候你的命令就可以简化为

> py hello.py

## 使用pip



当Python2和Python3同时存在于windows上时，它们对应的pip都叫pip.exe，所以不能够直接使用 pip install 命令来安装软件包。而是要使用启动器py.exe来指定pip的版本。命令如下：



> py -2 -m pip install XXXX



-2 还是表示使用 Python2，-m pip 表示运行 pip 模块，也就是运行pip命令了。如果是为Python3安装软件，那么命令类似的变成



> py -3 -m pip install XXXX

## #! python2 和 # coding: utf-8 哪个写在前面？



对于Python2用户还有另外一个困惑，Python2要在代码文件顶部增加一行说明，才能够在代码中使用中文。如果指明使用的Python版本也需要在文件顶部增加一行，那哪一行应该放在第一行呢？



\#! python2 需要放在第一行，编码说明可以放在第二行。所以文件开头应该类似于：

> ```text
> #! python2
> # coding: utf-8
> ```



有了这些技巧，Python2和Python3就可以愉快地在一起玩耍了～



原文链接：https://www.zhihu.com/question/21653286/answer/95532074
