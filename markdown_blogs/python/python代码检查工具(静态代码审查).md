## python静态代码检查

我们知道python是一门脚本语言，不像C#/Java等编译型语言可以在编译阶段就报出代码错误，脚本语言往往需要在运行期执行到这段代码时才会抛出代码错误。

那么在实际商业项目中使用python开发，我们是怎样做静态代码检查的呢？

首先在我们项目组推荐使用vscode做为python开发工具，所以我介绍下我们在vscode中是怎样做代码静态审查的，减少运行期的py脚本错误。

1. 安装vscode插件：save and run，下载地址：[Save and Run - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=wk-j.save-and-run)
2. 通过pip install pyflakes 这个模块，安装后就有pyflakes.exe
3. 在vscode中配置文件(settings.json)中增加这几行配置

```json
	"saveAndRun": {
        "commands": [
            {
                "match":"\\.py$",
                "isAsync":true,
                "cmd":"python C:\\Python27\\Scripts\\pyflakes.exe ${file}"
            }
        ]
	},
```

4. 在vscode中编写完py脚本，在保存时就会提示你当前文件是否有脚本错误了。

<br/>

## 验证一下

### 语法报错

代码缩进在python中是语法，如果在纯文本中编辑代码或复制粘贴的代码，很大概率的问题缩进不对从而在运行时报错，通过上面的设置后在从保存py文件时就会报错出来。



<br/>

### python用法报错

比如这个py文件中有一处错误，在保存py时就会提示你脚本有错误，这是因为global变量不能在初始化时赋值。

```shell
e:\Code\python_study\true-false逻辑控制符.py:9:17: invalid syntax
global log_func = 1
                ^
```


<br/>


## 其它插件

可选插件：[Pylance - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-python.vscode-pylance)
