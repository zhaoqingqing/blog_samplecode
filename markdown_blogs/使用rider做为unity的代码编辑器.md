使用Rider做的编写Unity代码的IDE，记录一些与VS不相同的笔记

安装和设置方法：

我使用Rider 2019.1 + Unity3D 2018.3.4，在安装完Rider之后，在Unity中选择Rider做为脚本编辑器，然后在Unity中双击代码就可以跳转到Rider中，Rider会自动在Unity工程中导入调试的dll。

> 更新于2020-4-21 ，使用Rider 2019.2 + Unity3D 2019.3.7f1 无需再导入调试dll到Unity中，需要在Rider中取消勾选自动导入(具体选项名字在Unity中会以日志输出)

## Rider的使用笔记

1. 从进程中来看，Rider中包含了一个Resharper

2. 转到定义快捷为Ctrl +B

3. 文件会自动保存，这样在写完代码后，Unity就会自动编译，可以在设置中禁用自动保存

4. 禁用拼写检查  搜索 Typo

5. 可以为不同语言禁用 ReSpeller

Rider编写纯C#程序时，要先Build，再执行 run/debug。

关于Rider和Resharper的关系可查看中的Rider部分：https://github.com/JetBrains/resharper-unity



## Rider禁用自动保存

rider默认会开启自动保存功能，如果想关闭它的话，就把这2个地方点掉。

打开设置， 外观&行为 - Systemsetting - Synchronize

Synchronize files on frame or editor tab activation -> 编辑时自动保存
Save files on frame deactivation -> 切换到其它窗口自动保存



## 对比的软件版本

在windows系统下比较

VS 2017企业版/专业版

Rider 2019.1/2019.2

IDEA 2018.4



## Rider比VS的优点

1. 调试Unity更加方便，在我使用Unity 2018.4.7+vs2017 专业版/企业版，经常出现无法断点的问题，尤其对于使用**partial**关键词的文件（一个类拆分在多个文件中）
2. 安装包没有VS大，Rider2019.1约500MB，而VS2017接近20GB。
3. 对于习惯使用Resharper来说，Rider的快捷键和使用体验是一致的，文件跳转和查找引用更加方便。
4. 个人感觉Rider相对没有VS那么卡顿，在路径中查找非常快速
5. 对于C#类中方法的提示，Rider鼠标移上去有方法提示，而实测vs2017和vs2019都没有，比如List.Add，Dictionary.Add
6. 对于某些过时的UnityAPI或有更加好的代码写法，会有很友好的黄色提示，在每个文件的右侧都有warings和suggestions帮助优化代码。
7. Rider中集成了unity support插件无须安装
8. 集成对shader的部分语法支持

Rider对于Unity的支持介绍：https://www.jetbrains.com/zh-cn/dotnet/promo/unity/

使用vs和rider开发unity的对比：https://www.jetbrains.com/rider/compare/unity-rider-vs-visual-studio/

Rider官方和vs的对比文章：https://www.jetbrains.com/rider/compare/rider-vs-visual-studio/



## Rider和IDEA的区别

之前使用IDEA编写Lua用了两年，记录下Rider与IDEA的区别(这两款编辑器都出自同一家公司)

1. 折叠代码块的插件，似乎IDEA更好用

2. 对于一个超级大的文件，里面有N个Class，在查找时无法在某个Class范围内搜索



## Rider的自定义

### 修改单行字符的长度

**使用情景：**当使用快捷键格式化代码时，如果一行代码的长度(字符个数)太多，编辑器会自动换行。同时在编辑器的右侧会有一条坚立分隔线，超过这条线的在格式化时会自动换行

**修改方法：**Settings - Editor - Code Style - C#(可以换成其它语言) - Line Break and Wrapping - Hard wrap at 修改这个值就可以(默认是120可以修改成180，在1920x1280的分辨率下180会比满屏一行长一些)。从字段的描述来看，它是超过X个字符就会换行。



### 避免每次修改代码都进行编译

**遇到问题：**每当在Rider中按下Ctrl+S保存代码时，就会感觉Rider卡卡的，因为此时Rider正在和Unity同步，让Unity编译代码

**修改方法：** Settings - Languages&Frameworks - Unity Engine - 取消勾选 Automatically refresh assets in Unity



### Rider和ILRuntime集成

 Rider 生成dll 方法，点击 Build  - Build Solution 就可以生成出dll

在Project中切换到Solution视图，右键热更新project -  Properties，修改编译事件，和VS的编译选项类似

用Rider调试ILRuntime目前还没有好方法，ILRuntime官方只提供了VS的扩展插件，社区还没人开发Rider调试插件

​      

## 复制Rider的智能提示

在代码中的警告信息，或者可以优化的写法，Rider会显示黄色波浪线，鼠标移上去，会显示警告的信息，那要怎样复制这些提示文字呢？

鼠标移到波浪线代码上，按下Alt键+用鼠标点击提示文字，如果有很多的文字可以按下Ctrl+F1显示提示的全部内容。



## Rider常见提示

第一次用Rider打开项目时会提示，这是代码命名规范化的提示，一般的有驼峰法命名

> rider detects naming conventions in opend soultions and updates setting accordingly



## 其它

汉化包：[Rider 2019.2 汉化包](https://blog.csdn.net/pingfangx/article/details/97928905) 从2020版本开始，官方提供了中文语言包，在插件商店中搜索Chinese就可以找到。

Rider插件平台：https://plugins.jetbrains.com/rider

使用Rider开发.Net程序，比如web项目或者前端项目：https://www.cnblogs.com/Leo_wl/p/8467901.html
