以vscode为例

在我们项目组使用：save and run + pyflakes (pip install )

可选插件：[Pylance - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-python.vscode-pylance)

## pyflakes

比如这个文件中有一处错误，global变量不能在初始化时赋值，在保存py时就会提示你脚本有错误。

```shell
e:\Code\python_study\true-false逻辑控制符.py:9:17: invalid syntax
global log_func = 1
                ^
```



