使用Mkdocs构建你的项目文档

## 环境搭建

### 安装必需软件

作者是在windows下安装的，如果是linux或mac用户，官网有更详细的安装说明。

**windows 10 x64**

当然还有广大的windows 7/8  用户，也是适用的。





**python** 3.4 x86版本(必备依赖)

 下载地址：https://www.python.org/downloads/release/python-344rc1/





**pip(pytone包管理器)**

下载地址：https://pypi.python.org/pypi/pip

下载文件并解压到某个文件夹下，并使用CMD进入到解压后的文件夹目录

执行安装命令：

```powershell
cd C:\Python34\pip-9.0.1
C:\Python34\pip-9.0.1>python setup.py install
```





**安装mkdocs**(把markdown转成静态html)

```powershell
pip install mkdocs
```




###  端口被占用

开启MkDocs的服务器，报以下错：`[WinError 10013] 以一种访问权限不允许的方式做了一个访问套接字的尝试。`

原因是默认的8000端口被占用，在官网文档中找到修改端口的方法：

https://markdown-docs-zh.readthedocs.io/zh_CN/latest/user-guide/configuration/

例如：我修改端口号为8001

```powershell
:: Run on port 8001, accessible over the local network.(http://127.0.0.1:8001/) , if 8000 port is used by other.
mkdocs serve --dev-addr=0.0.0.0:8001
```



安装部分参考文章：http://www.cnblogs.com/yuanzm/p/4089856.html





## 编辑站点

使用markdown格式编写文档，并在**mkdocs.yml** 中组织目录结构

关于markdown的知识，可以参考我的博客：[Markdown(MD)写作](http://www.cnblogs.com/zhaoqingqing/p/4905329.html)

mkdocs.yml的配置信息，请参考：https://markdown-docs-zh.readthedocs.io/zh_CN/latest/#_10





## 生成站点

生成静态的html，执行以下命令会创建一个site目录，并把生成后的静态html放在site目录。你可以对这些静态html进行版本控制。

```
mkdocs build
```

PS.如果你是托管在github上，那么使用gh-deploy也许更适合你。





## 发布站点

如果你的网站是托管在github在，那么事情会变的很简单

示例：默认发布到**gh-pages**分支，并在生成静态html时，清理不存在的文件

```powershell
mkdocs gh-deploy --clean
```

deploy文档：http://www.mkdocs.org/user-guide/deploying-your-docs/





建议在开发阶段使用`mkdocs serve`

发布阶段使用 `mkdocs gh-deploy`

MkDocs中文文档：https://markdown-docs-zh.readthedocs.io/zh_CN/latest/#mkdocs