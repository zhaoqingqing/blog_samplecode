## git rename后查看之前的记录

对于某个文件进行rename之后，使用show log命令查看之前的修改记录都会丢失

通过命令行方式进行mv之后，在tortoisegit中查看记录还是丢失的

```
git mv 从博客园下载已发布的文章.bat 博客园-下载已发布文章.bat
git commit -m "rename"
git push
```

解决办法：今天在tortoisegit中无意中找到办法，对于重命名的文件，在日志信息界面中，选中有更名文件点右键有个选项"显示重命名或复制前日志"，就可以查看到rename之前的所有日志。

![image-20200903200825922](https://img2020.cnblogs.com/blog/363476/202009/363476-20200903203819985-389827545.png)

在totorisegit中无法对某个文件进行目录移动而保留之前的提交记录，比如从A文件夹移动到B文件夹中

以上两项操作都会使用.git目录越来越大



## TODO待处理

### git还原某个错误的push

有一次操作出错，导致把分支所有的提交都push到master中了，主要是这两个分支的代码差别还是非常大的

我的操作方法：

在tortoise中显示日志，还原到某个版本，然后重新push

目前这个操作还有点蒙，经过几番操作才正确撤消我的push

### git从分支推送某个提交到master

在tortoisegit的日志信息中，可以选择这个操作

## git在windows下命令行的使用

在我的电脑上，打开的git命令行是使用这个工具mingw

[![image](https://img2020.cnblogs.com/blog/363476/202009/363476-20200903203820327-1330129616.png)](file:///C:/Users/qing/AppData/Local/Temp/OpenLiveWriter674401182/supfiles40FD0489/image[2].png)

### mingw

mingw是Minimalist [GNU ](https://baike.baidu.com/item/GNU)for Windows的缩写，允许控制台模式的程序使用微软的标准C运行时（C Runtime）库（[MSVCRT.DLL](https://baike.baidu.com/item/MSVCRT.DLL)），又可以调用windows的API

GNU是一个自由的操作系统，其内容软件完全以GPL方式发布。这个操作系统是GNU计划的主要目标，名称来自GNU's Not Unix!的递归缩写，因为GNU的设计类似Unix，但它不包含具著作权的Unix代码。GNU的创始人，理查德·马修·斯托曼，将GNU视为“达成社会目的技术方法”。

 git for windows

Git for Windows是用于windows平台下的仓库（另有github for windows）

官网：https://git-for-windows.github.io/

### TortoiseGit

github图形化客户端，包含多国语言包。

官网：https://tortoisegit.org/download/



## 修改文件的日期为git提交日期

出于我有一个需求，当我在家里的电脑上从git同步我的博客md文件时，新文件的日期是我拉取那天的日期，而当我想按日期排序文件时，很多文件并不能按我在git提交的时间来排序。

通过google查找到某些命令，这条在windows下对于英文命名的文件是可以查询到的，而对于中文命名的文件则会显示乱码，且不会显示日期。

```powershell
git ls-tree -r --name-only HEAD | ForEach-Object { "$(git log -1 --format="%ai" -- "$_")`t$_" }
```

于是我就尝试从下面这几个方向解决我的问题

### .NET 操作git

使用库：LibGit2Sharp

参考：https://c.lanmit.com/bianchengkaifa/net/10681.html

 [C#/.NET 使用 git 命令行来操作 git 仓库](https://blog.walterlv.com/post/run-commands-using-csharp.html)

### python脚本

gitpython，目前我正在使用这个库来操作git，安装库的命令： pip install gitpython

我验证过此库不能直接拿来使用： [使用原始创建/修改时间戳检出旧文件](https://www.it-swarm.dev/zh/git/%E4%BD%BF%E7%94%A8%E5%8E%9F%E5%A7%8B%E5%88%9B%E5%BB%BA%E4%BF%AE%E6%94%B9%E6%97%B6%E9%97%B4%E6%88%B3%E6%A3%80%E5%87%BA%E6%97%A7%E6%96%87%E4%BB%B6/968337954/)

[通过Python获取最后一次提交Git存储库文件的时间？](https://www.thinbug.com/q/13104495)



### linux脚本

[GIT 获取文件最初创建及最新修改日期](https://github.com/Dream4ever/Knowledge-Base/issues/69)

### tortoisegit 命令行

此方法理论上可行，需要去解析字符串，目前我通过python脚本解决了我的问题

### 最终方案

我编写的脚本，下载地址： [修改文件日期为git提交时间.py](https://github.com/zhaoqingqing/blog_samplecode/blob/master/build-tools/%E4%BF%AE%E6%94%B9%E6%96%87%E4%BB%B6%E6%97%A5%E6%9C%9F%E4%B8%BAgit%E6%8F%90%E4%BA%A4%E6%97%B6%E9%97%B4.py)

