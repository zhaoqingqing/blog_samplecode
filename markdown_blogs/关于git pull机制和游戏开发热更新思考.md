### 前言

今天由于网速很慢，在git pull更新时我观看了git pull的日志，让我联想到和我现在从事的游戏开发中的热更热有一定的相似性，把思绪记录下来。

​      

### git pull 日志

使用tortoisegit更新本地仓库时打印的日志如下：

```bash
git.exe pull --progress -v --no-rebase "origin"

POST git-upload-pack (982 bytes)
remote: Enumerating objects: 79, done.
remote: Counting objects: 100% (79/79), done.
remote: Compressing objects: 100% (46/46), done.
remote: Total 74 (delta 40), reused 62 (delta 28), pack-reused 0
From https://github.com/zhaoqingqing/blog_samplecode
07d975b..44772ac  master     -> origin/master
Updating 07d975b..44772ac
Fast-forward
   这里是具体更新内容...
   内容结束....
成功 (10094 ms @ 2020/3/16 9:09:58)
```

​      

### git pull 日志分析

这段一行一行的从字面上解释日志，并加上我的理解

> POST git-upload-pack (982 bytes)

向github网站发送请求信息，这里会上传本地.git目录下保存的本地仓库数据，供远程分析

​							

> remote: Enumerating objects: 79, done.

遍历此次需要的文件数量



>  remote: Counting objects: 100% (79/79), done.

统计此次需要更新的文件对象信息



> remote: Compressing objects: 100% (46/46), done.

压缩此次需要更新的文件为一个压缩包



> remote: Total 74 (delta 40), reused 62 (delta 28), pack-reused 0

总量74（有变化的40个），未使用的62（有变化的28个）



开始从github下载更新



> 成功 (10094 ms @ 2020/3/16 9:09:58)

如果长期未更新，或所要更新的仓库的分支越多和仓库体积越大时，每次更新所耗时也越长。

​      

### 游戏开发的热更新方法

此次看到torisegit更新的内容，让我想起游戏里下载更新，在我所开发的游戏中热更新有以下几种方法：

启动游戏 ——> 对比版本号，下载需要更新的差异zip包

启动游戏 ——> 对比资源列表，本地对比出差异文件列表，开始从差异列表中下载文件

​      

### git pull机制剖析和游戏热更新的对比

从上面分析tortoisegit的更新日志来看，它的更新机制有区别于上述我所使用的热更新方法

—————————机制剖析 start———————————

我分析git每次更新前，都会通过对比本地.git目录的记录和远程的最新版本进行对比，

然后得出差异文件，

在github网站动态生成一个此次需要更新文件的临时zip

下载更新文件到本地

下载到本地之后，同时更新.git目录的记录

—————————机制剖析 end———————————

本地的.git目录中保存了本地的文件记录，用于在更新时进行文件对比

​      

### .git目录分析

每次更新时，.git目录最常变化的文件和目录有：objects目录和这三个文件index，ORIG_HEAD，FETCH_HEAD

> objects 目录下保存所有的本地对象，下载更新时，会修改此目录的具体文件

> index文件  类似于文件列表，里面记录着本地所有的文件列表和一些其它信息

> ORIG_HEAD 服务器版本号（服务器当前被拉取分支的版本号）

> FETCH_HEAD 本地每个分支的版本号

.git目录下所有的文件列表如下：

```bash
hooks\
info\
logs\
objects\
refs\
ORIG_HEAD
FETCH_HEAD
index
COMMIT_EDITMSG
tortoisegit.data
tortoisegit.index
config
HEAD
packed-refs
description
```

