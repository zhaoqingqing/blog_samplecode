## pycharm社区版可用于商业项目

来源于官方的FAQ

[Can I use Community Editions of JetBrains IDEs for developing commercial proprietary software? – Licensing and Purchasing FAQ](https://sales.jetbrains.com/hc/en-gb/articles/360021922640-Can-I-use-Community-Editions-of-JetBrains-IDEs-for-developing-commercial-proprietary-software-)

## pycharm专业版和社区版功能对比表

|                                    | PyCharm Professional Edition | PyCharm Community Edition |
| ---------------------------------- | ---------------------------- | ------------------------- |
| Intelligent Python editor          | ✔                            | ✔                         |
| Graphical debugger and test runner | ✔                            | ✔                         |
| Navigation and Refactorings        | ✔                            | ✔                         |
| Code inspections                   | ✔                            | ✔                         |
| VCS support                        | ✔                            | ✔                         |
| Scientific tools                   | ✔                            |                           |
| Web development                    | ✔                            |                           |
| Python web frameworks              | ✔                            |                           |
| Python Profiler                    | ✔                            |                           |
| Remote development capabilities    | ✔                            |                           |
| Database & SQL support             | ✔                            |                           |

## pycharm专业版特有的功能

专业版可以把其它文件夹附加到当前项目中，好比可以同时打开多个目录。

TODO：尝试一下这个方法能否在社区版中使用《[pycharm同时加载多个项目](https://blog.csdn.net/u012922485/article/details/106729363/)》

### Scientific tools

一组科学计算的库包括Matplotlib 和NumPy [Scientific tools | PyCharm (jetbrains.com)](https://www.jetbrains.com/help/pycharm/scientific-tools.html)

科学工具例子介绍，可绘制图表 [Scientific & Data Science Tools - Features | PyCharm (jetbrains.com)](https://www.jetbrains.com/pycharm/features/scientific_tools.html)

## 我的经验

对于游戏开发者来说，使用社区版就足够了，当然我司很多同事是使用vscode开发python。

因为pycharm中文编码很难解决，甚至非常的头疼，这个问题我研究了很久也没有一套很好的解决办法，但是在vscode中原生就解决了。

## pycharm社区版和vscode

vscode在调试时的显示的信息比pycharm社区版更详细，更强大。比如pycharm社区版，只能显示这个类的外部信息，而一些object内置的信息就无法显示出来，比如`__dict__`和内置方法