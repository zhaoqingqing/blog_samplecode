## 最简单的方式

在windows上从cmd给python脚本传递参数

文档： [Python3 命令行参数](https://www.runoob.com/python3/python3-command-line-arguments.html)

注意事项：第1个参数为脚本名(包含完整的路径)，当你双击py脚本时，第一个参数也是脚本名



## 内置argparse

可以使用python内置模块(import argparse)进行更加友好的传参，参考文章《[Python 命令行参数的3种传入方式](https://tendcode.com/article/python-shell/)》，示例：

```python
E:\Code\python_study\python test_cmd.py -n "参数1" --body "参数2"
```



我的总结：对于只需要传递一个参数，可以使用最简单的方式，而对于需要传递更加多的参数，则建议使用 argparse模块