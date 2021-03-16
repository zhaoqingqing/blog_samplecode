## 执行python脚本

mac有内置的python，但还是建议你自己安装一个python，如果没有卸载mac自带的python2.7，当你需要使用python3执行脚本时，python命令需要改为python3

> 说明：env python是从环境变量中查找python的安装路径

如果安装的是python3，在py脚本的第一行加入

```sh
 #!/usr/bin/env python3
```

如果是python2，则加入

```sh
 #!/usr/bin/env python
```

打开终端，cd到脚本所在路径，执行python xxx.py

如果无法运行脚本，则给py添加执行权限：

```sh
chmod +x hello.py
```



## 双击执行python脚本

网上找到的方法修改.py为.command，然后双击，在公司的打包机上这样做会报语法解析错误。

我的做法是新建一个文件，修改后缀为.command，它在mac下是可执行文件，然后脚本内容如下：

```sh
cd work/ios/
python3 update.py
```

第一次执行时，要在终端给command文件添加可执行权限：chmod +x hello.command
