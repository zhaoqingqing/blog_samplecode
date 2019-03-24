我的VS 版本：visual studio 2017 专业版(15.9.7)  windwos 操作系统

### vs中同一个文件开两个窗口同时编辑

解决办法：在编辑器中，打开你要分屏的文件，点击菜单栏的 **窗口** - **新建窗口** ，这样会多出来一个副本文件，在选项卡 **右键** - **新建垂直选项卡组** 即可。



### 代码片段

代码片段用于在输入代码时，进行智能提示，比如在输入 for 按两次tab，进行自动补全

VS自带的代码片段管理器 ：工具 - 代码片段管理器 ，类似于xml的描述文件(*.snippet 文件)



相比起来VA的代码片段管理器则更容易编辑：[VA助手(Visual Assist X) 笔记](https://www.cnblogs.com/zhaoqingqing/p/3750622.html)

其它扩展：Snippet Editor



### 新建文件模版

示例：每次新建文件，在文件头添加如下信息

```c#
    /// <summary>
    /// 作者：赵青青 (https://www.cnblogs.com/zhaoqingqing)
    /// 时间：2019/3/24 18:42:34
    /// 说明：
    /// </summary>
```



### VS如何插入带时间的自定义注释

目前查到的方法是给VS装上宏插件。

参考：https://blog.csdn.net/menghuangxiao/article/details/77245688