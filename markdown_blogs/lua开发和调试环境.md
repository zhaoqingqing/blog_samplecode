## Lua开发环境搭建

Lua官网提供源码下载需要自己编译，Lua官网：https://www.lua.org/ftp/

lua for windows.exe(占二十多MB那个) 目前在网络上没有找到 5.3的版本，只有旧的5.1版本

以lua5.3以例，在windows上仅需要最简单的三个文件

luac.exe
lua53.dll
lua.exe

把这三个文件放在d:\lua53，把这个目录配置到环境变量下，在此目录下新建一个hello.lua，CD到这个目录，使用lua hello.lua就可以运行lua文件

```lua
D:\lua53> lua .\hello.lua
```

配置环境变量后，可以直接在命令行中输入lua，然后输入lua代码进行运行

```powershell
C:\Users\qing>lua
Lua 5.3.4  Copyright (C) 1994-2017 Lua.org, PUC-Rio
> print("this from lua")
this from lua
>
```

自动配置lua到环境变量脚本：https://github.com/zhaoqingqing/blog_samplecode/tree/master/workflow-tools



当然如果你需要使用一些第三方库，或者像我一样需要使用IDEA对Lua进行调试，建议安装lua for windows，而不仅仅是上述三个文件

Lua版本发布时间表，更多版本的发布时间可见lua官网

- Lua5.4 在2020-6-18发布
- Lua5.3在2018-7-10发布

### 编译lua源代码

从lua官网下载到lua源代码之后，使用CMD命令进入到lua源码目录，使用如下命令进行编译

> 命令：cl *.c

注：cl是微软提供的C语言编译器

如果电脑已经安装了visual studio的话，就已经有些程序了。

## 导入第三方库

在纯lua开发中导入第三方库，以json为例，安装Lua For Windows之后require成功且能正常使用，如果没有安装则会require失败，原因是lua的运行环境中找不到对应的库



## Lua Debug调试

在Unity中进行调试可以使用EmmyLua的新版本

在IDEA中对于纯Lua代码进行调试，需要安装Lua For Windows，如果要调试单个lua文件的话，需要新建一个Run/Debug Configurations，指定要调试的lua文件，并且勾选Allow paraller run

![image-20200723210028347](E:\Code\blog_samplecode\blog_images\image-20200723210028347.png)



## 新版本的EmmyLua

在2019年EmmyLua进行了新版本的开发，升级EmmyLua版本之后也是可以进行调试。

如果遇到lua中文件无法查找引用和跳转问题，可以重新安装EmmyLua插件

在Lua中提示Unity的API，可以使用新的方法，见EmmyLua群的教程。

我之前的博客中方法是针对以前EmmyLua的版本，目前需要以EmmyLua群的教程为准。

《[在Lua中提示UnityEngine.dll的方法](https://www.cnblogs.com/zhaoqingqing/p/8296753.html)》

《[在Unity中对Lua进行调试](https://www.cnblogs.com/zhaoqingqing/p/9121991.html)》