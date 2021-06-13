python打印的日志颜色都是一个颜色，普通日志、error、warn都是一个颜色，而使用过Unity3D引擎/Android Studio都知道每个级别日志的颜色都是不一样的，在Python中可以做到吗？

## Logging

官网：https://docs.python.org/zh-cn/3.8/howto/logging.html#advanced-logging-tutorial

参考资料

[python 标准库 logging](https://segmentfault.com/a/1190000008426434)

[Python: Logging模块实例详解](https://www.jianshu.com/p/29cb6a535e2d)

 [Python + logging 输出到屏幕，将log日志写入文件](https://www.cnblogs.com/nancyzhu/p/8551506.html)

## Pycharm

在pycharm中以debug方式执行python会提示这个信息：
```powershell
Python Debugger Extension Available
		Cython extension speeds up Python debugging
		Install How does it work
```
意思是:是否需要安装一个C编写的库来给python调试时加速

点击安装时，提示 Compile Cython Extensions Error

```powershell
Non-zero exit code (1): 
error: Microsoft Visual C++ 14.0 is required. Get it with "Microsoft Visual C++ Build Tools": https://visualstudio.microsoft.com/downloads/
```

Microsoft Visual C++ Build Tools 可以通过VS来安装，单独安装也有4个G

下载地址：https://wiki.python.org/moin/WindowsCompilers