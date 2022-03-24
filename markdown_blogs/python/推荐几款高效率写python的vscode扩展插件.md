## 两个必装

1. Python 

   认准Microsoft出品的

2. Pylance

    支持自动补全、参数提示、转到定义等多项功能改进

起初我安装了很多python插件，但是导致最基础的代码提示和方法跳转都失效了，最后精简到只保留这两个。

当vscocde中python方法提示或转到定义等功能失效之后，建议先卸载全部python有关的插件，要填坑的可见这篇：[VS Code无法实现“转到定义“？](https://zhuanlan.zhihu.com/p/344118024)

<br/>

### 会有很多个jupyter?

在安装了微软的python扩展之后会被安装几个Jupyter开头的扩展，在几台电脑上测试都是如此，而且不能卸载它，卸载之后，python扩展也会失效。

<br/>

## 代码提示插件(基于AI机器学习)

Tabnine：[codota/TabNine: AI Code Completions (github.com)](https://github.com/codota/TabNine)

kite：[Kite - Free AI Coding Assistant and Code Auto-Complete Plugin](https://www.kite.com/)

我现在安装使用的是tabnine，对于一些引擎类的接口，非python自带的lib，有一定的代码提示帮助。

<br/>

## 其它可选

2. python snippets
    提供示例代码作参考
3. better comments
    注释，根据关键词用不同的颜色高亮代码片段
4. python docstring generator
    自动生成函数的注释格式，通过tab键快速切换填充块编写相应的注释

<br/>

## 代码命名插件

vscode装：Codelf

https://github.com/unbug/codelf

pycharm装这个：OnlineSearch2，配置方法：《[【教程】给 WebStorm 添加 Codelf 实现一键搜索 · Issue #24 · unbug/codelf (github.com)](https://github.com/unbug/codelf/issues/24)》

在pycharm的设置中找到OnlineSearch2，然后添加一行配置如下：

| Codelf | https://unbug.github.io/codelf/#%S | %s   |
| ------ | ---------------------------------- | ---- |

其它文章：《[pycharm插件OnlineSearch2解决变量命名 - 简书 (jianshu.com)](https://www.jianshu.com/p/8c68348d83e6)》

## 代码对齐

pycharm:smart align

vscode:Better Align

### smart align

Place your cursor at where you want your code to be aligned, and invoke the Align command via Code -> Smart Align or Press Alt + Shift + -. Then the code will be automatically aligned.
