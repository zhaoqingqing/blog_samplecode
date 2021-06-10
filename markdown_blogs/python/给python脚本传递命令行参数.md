记录一下给python脚本传参数的几种方式

## 最简单的方式

在cmd/bat脚本中调用python脚本传递参数

```python
#传递参数
python test.py arg1 arg2 arg3
#在python中取参数
sys.argv[0] #取出来的是脚本名
sys.argv[1] #取到第一个参数
len(sys.argv) #计算命令行参数个数。
```

注意事项：

第1个参数为脚本名(包含完整的路径)，当你双击py脚本时，第一个参数也是脚本名

文档： [Python3 命令行参数](https://www.runoob.com/python3/python3-command-line-arguments.html)

## 内置argparse

还可以使用python内置模块(`import argparse`)进行更加友好的传参，示例：

```python
E:\Code\python_study\python test_cmd.py -n "参数1" --body "参数2"
```

参考文章《[Python 命令行参数的3种传入方式](https://tendcode.com/article/python-shell/)》



我的总结：对于只需要传递一个参数，可以使用最简单的方式，而对于需要传递更加多的参数，则建议使用 argparse模块