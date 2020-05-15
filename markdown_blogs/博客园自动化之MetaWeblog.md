## MetaWeblog API

接上篇《博客园自动化之XML-RPC》，这里了解一下MetaWeblog API。

MetaWeblog API（MWA）是一个编程接口，允许外部程序获取和设置weblog帖子的文本和属性。它建立在流行的XML-RPC通信协议之上，在许多流行的编程环境中都可以使用实现。

在2003年之际，很多的博客平台开始支持MetaWeblog API，允许第三方编辑器和内容管理器对博客进行编辑管理。

在现在，比如MWeb,Windows Live Writer的文章发布都是以这个API为基础的！

而这个API，就是多个博客同步的关键所在！

**名词解释**

MWeb for Mac, iPad and iPhone 专业的 Markdown 写作、记笔记、静态博客生成软件

Windows Live Writer 这款写作软件已经很熟悉了，我之间文章都是通过他写作的，只可惜微软不再更新，而且不支持markdown

## 实现工具

python实现cnblog metaweblog api

也有使用typescript实现metaweblog接口的，比如 [WriteCnblog](https://github.com/kotcmm/writecnblog) 是一款VSCode的插件，支持在VSCode中把文章发布到博客园

## 遇到问题

我在python中使用XML-RPC，通过**getRecentPosts**获取最近发布文章时，解析出错，报

> xml.parsers.expat.ExpatError: reference to invalid character number: line 1501, column 112

通过调试没找到出错原因，但使用这篇《[使用metaweblog API实现通用博客发布 之 API测试](https://www.cnblogs.com/robert-9/p/11428982.html)》提供的python脚本则是正常的。

使用排除法定位到问题为：当getRecentPosts获取的文章大于等于10，则会出现字符出错，而使用调试工具或olw获取最近发布文章数量可达100篇，博客园的博问也有提到最大可获取数量为100，而在我的环境中超过9则会出现字符出错。





## MetaWeblog API调试

我用的调试工具为 [精易编程助手](http://soft.125.la/) 附带的一个工具 精易网页调试助手

调试工具来源于这篇文章《[MetaWebLog API — 一个多平台文章同步的思路](https://www.cnblogs.com/ljysblog/p/12336878.html)》

API调试代码参考这篇文章《[XML-RPC 简单理解与博客园的MetaWeblog协议](https://www.cnblogs.com/caipeiyu/p/5354341.html)》，需要注意的是显示的编码使用UTF-8就不会出现中文乱码