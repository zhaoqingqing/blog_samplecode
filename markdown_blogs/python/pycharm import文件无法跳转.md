## 出现问题

在pycharm中import文件，点击文件中的方法无法跳转到对应的文件。且import 那里会是灰色，有红色波浪线，代码可以正常运行，结果也是正确的。

## 已做的尝试

添加了`__init__.py`，也尝试过在`__init.py`中加入 from xx import *，也是无效

项目的根目录已设置为Sources Root，Settings - File - File Type中`__init.py`也是python脚本类型

目前使用的pycharm是2019.1，后面尝试升级版本是否能够解决。



[Pycharm无法识别__init__里import的包，ctrl时无法跳转](https://blog.csdn.net/u013010889/article/details/107206608)

## 最终解决办法

打开路径下的一级路径设置mark as sources root，

比如我的代码结构如下：

```
code
	-client
	-server
	-common
```

我用pycharam打开code目录，那么需要设置client，server,common，而不是code这个目录
