## 背景介绍

我自己是jbtbrains家族IDE的重度用户，包括写Lua的IDEA，写C#的Rider，写js的webStorm，写python的pycharm，visual studio中的resharper扩展，原因就是可以提高编码的效率，各平台各语言的使用习惯统一，减少学习成本。

## 为什么要从pycharm换成vscode?

pycharm的文件中文编码问题很头疼

建议使用pycharm来做一些新的系统， 但如果是旧系统的话， 用vscode会方便一些， 主要是文件编码问题



## 等效替代FAQ

Q：hi，我想问一下，在pycharm中按下ctrl+F12就可以在当前文件搜索方法，这个功能在vscode是不是没有，只能在当前文件中查找？
A: Ctrl + F, 加关键字 def xxx, 搜索方法. 全 文件搜索， Ctrl + Shift +F



Q:  pycharm中的文档结构图，就是在一个窗口显示出这个文件包含的方法、字段，这个在vscode中有吗？
A：在vscode1.40的版本之后增加了outline(大纲)视图，如果几千行的文件大纲也是要半分钟才能显示，插件有[AZ AL Dev Tools/AL Code Outline - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=andrzejzwierzchowski.al-code-outline), 但是一般不怎么用， 因为比较卡



## 功能FAQ

Q：如何在标题栏显示文件的完整路径？

A：在settings.json，添加这行配置：

```json
"window.title":
"${dirty}${activeEditorLong}${separator}${rootName}${separator}${appName}",
```

## VSCode自带的大纲(outline)

[Visual Studio Code outline-view](https://code.visualstudio.com/updates/v1_24#_outline-view)

试用了vscode自带的大纲和插件，对于大型文件都是很慢才出现