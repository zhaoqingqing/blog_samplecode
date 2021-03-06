## 同质化的压缩软件

提及 Windows 平台的压缩软件，大家往往想起老牌的 WinRAR、开源免费的 7-Zip、国产的快压、好压、360 压缩之类，甚至还有时代的眼泪 WinZip。一直以来，压缩软件因为作为十分基础的工具软件、同类产品同质化而很少被注意到，只要没有重大的缺陷，大家往往会就着现在在用的继续用下去。

​     

## 压缩软件变迁路

和不少人一样，我曾经历过从 WinRAR 到 7-Zip 的叛逃。WinRAR 自早年打败了 WinZip 便成为「装机必备」走进了千家万户的 PC，其易用性和功能齐全自然不言而喻。然而 $29 的授权价格在当年却不是千家万户皆能接受的范围，大多中国用户或随着 Ghost XP 的常用软件一键安装包被附赠上一份盗版 WinRAR，或装上试用版后任由「评估版本」的提示次次弹出不予理睬。

几年前，7-Zip 以免费开源的特点被众人发现。7-Zip 尽管免费，功能上相比 WinRAR 却差不多少，加之 7-Zip 默认的固实压缩使得压缩率相比 WinRAR 默认的非固实压缩要低许多，相当一大批不满于使用盗版 WinRAR 的用户开始转向 7-Zip 阵营。尽管几年后的今天 WinRAR 的中国代理商软众世界推出了免费＋广告的中文个人版，但相比前几年大批大批的 7-Zip 迁移浪潮却已经晚了许久。

本以为压缩软件的迁移之路终于到此为止，直到两年前在知乎被推荐了 Bandizip。

​      

## Bandizip 为何物

[Bandizip](https://www.bandisoft.com/bandizip/cn/) 是一款来自韩国的开发商 Bandisoft 开发的 Windows 平台压缩软件（有 macOS 版本，但是收费且功能过于简陋，故不推荐），该开发商更加鼎鼎有名的产品是他们的 Bandicam 录屏软件。不过与收费的 Bandicam 不同的是，Bandizip 是一款完全免费的可商用软件。

![](https://img2018.cnblogs.com/blog/363476/202002/363476-20200208170951868-967722071.png)

​      
### 下载地址

你可以 [前往官网](https://www.bandisoft.com/bandizip/) 免费下载 Bandizip。
      

## 为什么推荐 Bandizip

作为一款压缩软件，在 WinRAR 的领头下，压缩软件的界面、功能往往大同小异，不少人推荐 Bandizip 的原因仅仅是免费且较 7-Zip 好看，但我觉得推荐 Bandizip 的原因绝非只有这点。不客气地说，这可能是你的最后一款 Windows 压缩软件。

Bandizip 之所以出色，一系列的细节功能功不可没。

​      

### 智慧的「自动解压」命令

无论你过去使用什么压缩软件，大概都会遇到过这样的情形：

*下载了一个压缩包，随手丢在了桌面，右击压缩包选择「解压到当前目录」，然后桌面被一堆文件夹、文件铺满了。*

 发生这种状况，无非是因为压缩包内**直接**压缩了多个文件（夹），然而若每次都选择「解压到 "…\"」，又会常常遇到双层文件夹包装。虽说不是什么十分大不了的事情，但我过去总被常常交替出现的两种压缩目录层级逼到抓狂。 

幸运的是，Bandizip 解决了这个问题。在多个使用场景下，Bandizip 均对两种压缩目录层级做出了特别的改进：

- 打开压缩包时，若遇到首级目录只有单一文件夹的压缩包，Bandizip 会自动显示文件夹内内容；

- 在右击上下文菜单中，Bandizip 提供的「自动解压」命令会根据该压缩包目录层级自动选择「直接解压」或「解压至以压缩包文件夹命名的新文件夹中」；

- 在「选择解压路径」对话框中，「解压到选定文件夹下的『目标』文件夹」勾选框会根据当前压缩包目录层级自动勾选／取消勾选；

  https://cdn.sspai.com/attachment/origin/2016/08/14/342351.gif?imageView2/2/w/1120/q/90/interlace/1/ignore-error/1

 这个功能大概是我最喜欢 Bandizip 的地方了。 

​    

### 内建「图片预览」快速查看

Bandizip 内建一个缩略图浏览器，方便快速查找压缩包内图片内容。

 若你是个漫画党，使用 Bandizip 和 Bandisoft 自家的 [Honeyview 蜂蜜浏览器](https://www.bandisoft.com/honeyview/cn/)无缝配合更加方便，在 Bandizip 直接双击压缩包内的图片即可调用 Honeyview 打开，甚至可以替代不少漫画阅读器了。 

​        

### 「快速拖放」解放临时文件夹

若你习惯于直接将压缩包内文件「拖出来」来进行解压操作，那你大概常常会在压缩软件的解压进度条走完后遇到又一个进度条：将操作文件从临时文件夹复制到目标拖放目录。

Bandizip 在**解压大文件时**会使用「快速拖放」功能，「快速拖放」功能使你的文件被直接解压到目标拖放目录，而非从临时文件夹处中转。既不需要你改变操作习惯，同时有效减少你的等待时间。

​      

### 用「代码页」和乱码说再见

若常常需要与 Mac 用户交换文件，或是购买一些国外的数字商品（如我购买的日本同人志），常常会遇见压缩包打开是一片一片的乱码文件名的状况。

编码问题一直是造成乱码的元凶，然而 Bandizip 的「代码页」选项让这一切都不再是问题。

​      

## 一些微小的总结

可以看到，Bandizip 的一系列细节功能都做得十分用心，我十分乐见有这样一款压缩软件，将不少用户曾经注意到或未注意到的痛点逐一找出并解决，而不是空吹「自主」「首创」云云。基于此，Bandizip 可以说是我最喜欢的 Windows 软件之一。

你可以 [前往官网](https://www.bandisoft.com/bandizip/) 免费下载 Bandizip。

​      

本文摘自： https://sspai.com/post/35358 