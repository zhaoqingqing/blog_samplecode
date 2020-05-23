## 包管理器

关键字pip，以windows为例，安装完python3.8 之后已经帮你安装好了pip，在cmd中输入pip，如果出现pip的用法示例，则说明pip安装成功了

如果是python 2.7的版本或者其它python未安装pip，可以在网上找找安装pip

## pip安装包失败

如果你像我一样在pip安装包时，出现失败，则按照提示在后面添加 --user

```powershell
ERROR: Could not install packages due to an EnvironmentError: [WinError 5] 拒绝访问。: 'c:\\program files\\python38\\Lib\\site-packages\\certifi'
Consider using the `--user` option or check the permissions.
```

把 pip install requests 修改为：pip install requests --user

## pip版本升级

> python -m pip install --upgrade pip

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