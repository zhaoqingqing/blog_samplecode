## git rename后查看之前的记录

对于某个文件进行rename之后，使用show log命令查看之前的修改记录都会丢失，通过命令行方式进行mv之后，在tortoisegit中查看记录还是丢失的

```shell
git mv 从博客园下载已发布的文章.bat 博客园-下载已发布文章.bat
git commit -m "rename"
git push
```

解决办法：

今天在tortoisegit中无意中找到办法，对于重命名的文件，在日志信息界面中，选中有更名文件点右键有个选项"显示重命名或复制前日志"，就可以查看到rename之前的所有日志。

![image-20200903200825922](https://img2020.cnblogs.com/blog/363476/202009/363476-20200903203819985-389827545.png)

在totorisegit中无法对某个文件进行目录移动而保留之前的提交记录，比如从A文件夹移动到B文件夹中

以上两项操作都会使用.git目录越来越大



## git还原某个错误的push

有一次操作出错，导致把分支所有的提交都push到master中了，主要是这两个分支的代码差别还是非常大的

我的操作方法：

在tortoise中显示日志，还原到某个版本，然后重新push

目前这个操作还有点蒙，经过几番操作才正确撤消我的push



## tortoisegit同步分支的某个提交到master

1. 把master拉取到最新
2. show log - 在log中选择已提交的分支，并选中要的那条提交记录
3. 右键选择  **摘取此提交**，进行合并
4. 在本地右键-同步，就可以把这个提交同步到master远程

Cherry Pick this Commint翻译为中文：摘取此提交

注意：不要使用右键的合并功能，它差不像tortoisesvn那样可以合并某个提交，而是要使用上述方法

需要图文的可以查看这篇《[合并单个commit到指定分支上——tortoisegit cherry pick 的使用](https://www.jianshu.com/p/a7f0a6e0bf8c)》



## 修改文件日期为git的提交日期

出于我有一个需求，当我在家里的电脑上从git同步我的博客md文件时，新文件的日期是我拉取那天的日期，而当我想按日期排序文件时，很多文件并不能按我在git提交的时间来排序。

通过google查找到某些命令，这条在windows下对于英文命名的文件是可以查询到的，而对于中文命名的文件则会显示乱码，且不会显示日期。

```sh
git ls-tree -r --name-only HEAD | ForEach-Object { "$(git log -1 --format="%ai" -- "$_")`t$_" }
```

于是我就尝试从下面这几个方向解决我的问题

### .NET 操作git

可使用的库：LibGit2Sharp

参考资料：

- https://c.lanmit.com/bianchengkaifa/net/10681.html
-  [C#/.NET 使用 git 命令行来操作 git 仓库](https://blog.walterlv.com/post/run-commands-using-csharp.html)


写了一些测试代码后放弃了，因为用.net来操作git比较麻烦

### git 命令行

- git的命令行：[GIT 获取文件最初创建及最新修改日期](https://github.com/Dream4ever/Knowledge-Base/issues/69)
- 从tortoisegit拿到log信息然后解析字符串，此方法理论可行，目前我通过python脚本解决了我的问题

在我的电脑上，打开的git命令行是使用这个工具mingw

[![image](https://img2020.cnblogs.com/blog/363476/202009/363476-20200903203820327-1330129616.png)](file:///C:/Users/qing/AppData/Local/Temp/OpenLiveWriter674401182/supfiles40FD0489/image[2].png)

mingw是Minimalist [GNU ](https://baike.baidu.com/item/GNU)for Windows的缩写，允许控制台模式的程序使用微软的标准C运行时（C Runtime）库（[MSVCRT.DLL](https://baike.baidu.com/item/MSVCRT.DLL)），又可以调用windows的API

GNU是一个自由的操作系统，其内容软件完全以GPL方式发布。这个操作系统是GNU计划的主要目标，名称来自GNU's Not Unix!的递归缩写，因为GNU的设计类似Unix，但它不包含具著作权的Unix代码。GNU的创始人，理查德·马修·斯托曼，将GNU视为“达成社会目的技术方法”。

### python脚本

目前我是使用gitpython操作git，安装命令： pip install gitpython

我测试此方法不能直接拿来使用：[通过Python获取最后一次提交Git存储库文件的时间？](https://www.thinbug.com/q/13104495)

最后自己手写python脚本来解决这个问题，开源地址： [修改文件日期为git提交时间.py](https://github.com/zhaoqingqing/blog_samplecode/blob/master/build-tools/%E4%BF%AE%E6%94%B9%E6%96%87%E4%BB%B6%E6%97%A5%E6%9C%9F%E4%B8%BAgit%E6%8F%90%E4%BA%A4%E6%97%B6%E9%97%B4.py)

