

Visual Studio Tools for Unity 从vs2017开始就不提供单独的安装包下载，需要通过vs安装程序在线安装。

### vs2017离线安装vs tools for unity

那么如何离线安装vs tools for unity呢？

1. 找一台已经过此扩展的机器，拷贝 **Visual Studio Tools for Unity 文件夹**
2. 也可以从其它vs 2017版本已安装过此扩展的目录下拷贝，比如我是从专业版扩展拷贝到企业版，也是生效的。
3. 把文件夹拷贝到vs的目录下（见下面），重启vs，就可以生效。

### 扩展安装后的路径

企业版vs2017的路径

```bash
C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\Visual Studio Tools for Unity
```



专业版vs2017 的路径

```bash
C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\Microsoft\Visual Studio Tools for Unity
```

### 拷贝到此路径下

企业版vs2017的路径

```bash
C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\
```



专业版vs2017 的路径

```bash
C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\Microsoft\
```



### 我的实践

我是把vs2017专业版安装的扩展拷贝 vs2017企业版目录下，是可以正常和unity进行调试的。

我在 vs 2017 企业版 15.9.10 和 unity 2018.3.6 下调试正常。

PS. 最近在内网开发，所以无法在线安装和更新扩展



### 安装多版本的vs2017

我在同一台机器上，同时安装了 vs2017专业版 和vs 2017 企业版，使用一个星期后，一切运行正常。

我的安装方法是正常安装，无需做过多的操作，两个版本共存。

我先安装专业版使用几个月之后，vs2017专业版经常出现无法断点调试问题，就再次安装vs2017企业版。