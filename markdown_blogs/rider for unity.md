使用Rider做的编写Unity代码的IDE，记录一些与VS不相同的笔记

从进程中来看，Rider中包含了一个Resharper



转到定义快捷为Ctrl +B

文件会自动保存，这样在写完代码后，Unity就会自动编译，可以在设置中禁用自动保存

禁用拼写检查  搜索 Typo

可以为不同语言禁用 ReSpeller



**禁用自动保存**

rider默认会开启自动保存功能，如果想关闭它的话，就把这2个地方点掉。

打开Systemsetting - Synchronize

Synchronize files on frame or editor tab activation -> 编辑时自动保存
Save files on frame deactivation -> 切换到其它窗口自动保存



之前使用过两年的IDEA编写Lua，记录下Rider与IDEA的区别(这两款编辑器都出自同一家公司)

折叠代码块的插件

对于一个超级大的文件，里面有N个Class，在查找时无法在某个Class范围内搜索



汉化包

[Rider 2019.2 汉化包](https://blog.csdn.net/pingfangx/article/details/97928905)



Rider插件平台：https://plugins.jetbrains.com/rider



使用Rider开发.Net程序，比如web项目或者前端项目：https://www.cnblogs.com/Leo_wl/p/8467901.html



### Rider比VS的优点

1. 调试Unity更加方便，在我使用Unity 2018.4.7+vs2017 专业版/企业版，经常出现无法断点的问题，尤其对于使用**partial**关键词的文件（一个类拆分在多个文件中）
2. 安装包没有VS大，Rider2019.1约500MB，而VS2017接近20GB。
3. 对于习惯使用Resharper来说，Rider的快捷键和使用体验是一致的，文件跳转和查找引用更加方便。
4. 个人感觉Rider相对没有VS那么卡顿