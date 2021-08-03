## 包管理器

关键字pip，以windows为例，安装完python3.8 之后已经帮你安装好了pip，在cmd中输入pip，如果出现pip的用法示例，则说明pip安装成功了

如果是python 2.7的版本或者其它python未安装pip，可以在网上找找安装pip

### 安装包

```powershell
pip install mkdocs
```

### 批量安装pip包

实现一次pip安装所有环境

1. 列出本机安装的所有pip列表： pip list

2. 在cmd中导出本机安装的所有包，将列表保存在C:\Users\qing\requirements.txt中

> pip freeze >requirements.txt



安装所有包： pip install -r requirements.txt


### 安装历史版本

包名字后面加上==版本号

```
pip install mkdocs==1.0.4
```

### pip安装本地包

安装下载后的whl包文件，进入到whl文件所在路径，执行这条命令

```powershell
pip install file_name.whl
```

### 卸载包

```powershell
pip uninstall [options] <package>
```

## pip严重失败

如果在电脑上同时安装了python2和python3，使用pip时可能会遇到这个报错

```
Fatal error in launcher: Unable to create process using '"'
```

如果这条指令还是无法安装`python -m pip install –upgrade pip`，可以在控制面板 - 程序和功能 - 找到python - 右键  - 更改，选择 Repail ，对python进行重装 

## pip安装包失败

如果你像我一样在pip安装包时，出现失败，则按照提示在后面添加 --user

```powershell
ERROR: Could not install packages due to an EnvironmentError: [WinError 5] 拒绝访问。: 'c:\\program files\\python38\\Lib\\site-packages\\certifi'
Consider using the `--user` option or check the permissions.
```

把 pip install requests 修改为：pip install requests --user

如果提示中包含：`拒绝访问 c:\program files\python38\` ，还可以使用的解决办法为：

1. 打开报错中提示的目录，比如我的 c:\program files\ 

2. 鼠标右击python38这个目录，点击 属性 ，

3. 首先切换到  **安全** 这个大标题下面，选中当前登陆的用户，然后再点击编辑

4. 给当前用户勾选“完全控制”，再点击确定就大功告成。

参考：[windows下pip安装python模块时报错总结](https://www.cnblogs.com/liaojiafa/p/5100550.html)

## pip无法连接

原因：在win10下使用了代理服务器，但代理软件未开启，或无法访问，需要取消它。

解决办法：设置 - 代理服务器设置，取消代理服务器

```
C:\Users\qing>pip install mkdocs
Collecting mkdocs
  WARNING: Retrying (Retry(total=4, connect=None, read=None, redirect=None, status=None)) after connection broken by 'ProxyError('Cannot connect to proxy.', NewConnectionError('<pip._vendor.urllib3.connection.VerifiedHTTPSConnection object at 0x0000021C34102D60>: Failed to establish a new connection: [WinError 10061] 由于目标计算机积极拒绝，无法连接。'))': /simple/mkdocs/
```

## pip国内源

阿里云镜像：https://mirrors.aliyun.com/pypi/simple/

清华大学镜像：https://pypi.tuna.tsinghua.edu.cn/simple/

腾讯镜像：https://mirrors.cloud.tencent.com/pypi/simple

豆瓣镜像：https://pypi.doubanio.com/simple/

中科大镜像：https://mirrors.tuna.tsinghua.edu.cn/pypi/web/simple/

全局设置方法

```bash
pip config set global.index-url https://mirrors.aliyun.com/pypi/simple
```

单次设置源方法

```bash
pip install markdown -i https://mirrors.aliyun.com/pypi/simple
```

查看当前的使用的源：打开这个目录下的文件：C:\Users\qing\AppData\Roaming\pip\pip.ini

## pip版本升级

> python -m pip install --upgrade pip



## pip查看包的版本

会列出全部已安装的pip，从里面找到你要的pkg的版本号

> pip list

## python常用第三方模块

### requests

我们已经讲解了Python内置的urllib模块，用于访问网络资源。但是，它用起来比较麻烦，而且，缺少很多实用的高级功能。

更好的方案是使用requests。它是一个Python第三方库，处理URL资源特别方便。

> ```
>  pip install requests
> ```

验证

```python
import requests
r = requests.get('https://www.cnblogs.com/')
print(r.status_code)
```



### chardet

字符串编码一直是令人非常头疼的问题，尤其是我们在处理一些不规范的第三方网页的时候。虽然Python提供了Unicode表示的`str`和`bytes`两种数据类型，并且可以通过`encode()`和`decode()`方法转换，但是，在不知道编码的情况下，对`bytes`做`decode()`不好做。

对于未知编码的`bytes`，要把它转换成`str`，需要先“猜测”编码。猜测的方式是先收集各种编码的特征字符，根据特征字符判断，就能有很大概率“猜对”。

当然，我们肯定不能从头自己写这个检测编码的功能，这样做费时费力。chardet这个第三方库正好就派上了用场。用它来检测编码，简单易用。

> ```
> pip install chardet
> ```

### pillow

PIL：Python Imaging Library，已经是Python平台事实上的图像处理标准库了。PIL功能非常强大，但API却非常简单易用。

由于PIL仅支持到Python 2.7，加上年久失修，于是一群志愿者在PIL的基础上创建了兼容的版本，名字叫[Pillow](https://github.com/python-pillow/Pillow)，支持最新Python 3.x，又加入了许多新特性，因此，我们可以直接安装使用Pillow。

> ```bash
> pip install pillow
> ```

## pip模块已安装但pycharm提示找不到

原因是安装了多个版本的python，而pycharm中使用的非当前的python版本。

解决办法：在pycharam中修改解释器为pip对应的python

1. 点击File - Setting 找到 Project Interpreter
2. 先删除原来的解释器，并删除本地的venv目录
3. 添加新的python版本，点确定之后，会reload出来安装的模块

![image-20200903095353199](https://img2020.cnblogs.com/blog/363476/202009/363476-20200903095523573-121339055.png)

