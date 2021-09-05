## 背景介绍

我自己是jetbrains家族IDE的重度用户，比如写Lua/Java用IDEA，写C#用Rider，写js用webStorm，写pytho用pycharm，visual studio必安装Resharper扩展，原因就是可以提高编码的效率，各平台各语言IDE的使用习惯统一，减少学习成本，甚至jetbrains不同IDE之间的快捷键都一样，减少记忆的成本。

<br/>

## 为什么要从pycharm换成vscode?

pycharm的中文编码问题很头疼，主要是一些历史原因，项目中十几年前的py代码文件编码不规范，是更换的主要原因。

建议使用pycharm来做一些新的系统， 但如果是旧系统的话，查看文件编码是否规范，如果不规范，那么务必使用vscode来修改，否则pycharm保存py文件后，游戏启动就会黑屏了，traceback:编码异常。

<br/>

## 等效替代FAQ

Q：hi，我想问一下，在pycharm中按下ctrl+F12就可以在当前文件搜索方法，这个功能在vscode是不是没有，只能在当前文件中查找？
A: Ctrl + F, 加关键字 def xxx, 搜索方法， 在所有文件中搜索：按下Ctrl + Shift +F，然后输入搜索内容

<br/>

Q:  pycharm中的文档结构图，就是在一个窗口显示出这个文件包含的方法、字段，这个在vscode中有吗？
A：在vscode1.40的版本之后增加了outline(大纲)视图，如果几千行的文件大纲也是要半分钟才能显示，插件有[AZ AL Dev Tools/AL Code Outline - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=andrzejzwierzchowski.al-code-outline), 但是一般不怎么用， 因为比较卡

<br/>

## 功能FAQ

Q：如何在标题栏显示文件的完整路径？

A：在settings.json，添加这行配置：

```json
"window.title":
"${dirty}${activeEditorLong}${separator}${rootName}${separator}${appName}",
```

<br/>

## 类/文件大纲(outline)

VSCode自带类/文件大纲，见文章：[Visual Studio Code outline-view](https://code.visualstudio.com/updates/v1_24#_outline-view)

在商店中也有一款大纲插件，但是对于上千行的文件，我测试了插件和vscode自带的，大纲都是很慢才出现，但是pycharm很快大纲就显示出来了，为什么pycharm会这么快？原因我猜测是pycharm在打开工程时就在后台进行了较长时间的载入计算

