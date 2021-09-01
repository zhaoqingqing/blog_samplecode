使用vscode编写bat脚本让工作流得到了极大的改善

> 以前：在文本编辑器中写完，保存，回到资源管理器双击bat运行，再循环重复

> 现在：在vscode中编写bat，按下快捷键执行bat

<br/>

## 在vscode中运行bat

1. 给vscode安装 [Code Runner](https://marketplace.visualstudio.com/items?itemName=formulahendry.code-runner)

2. 在vscode中选择 **文件** -> **首选项** -> **设置**，打开VS Code设置页面，找到 **扩展** -  **Run Code configuration**，勾上 **Run In Terminal** 选项。

这样设置之后，脚本就会在 Terminal 中运行了，而且运行bat也不会显示中文乱码了。

<br/>

## 三种方法执行bat

1. 在vscode中编辑bat
2. 在编辑区，右键选择 **Run Code**，
3. 或键盘快捷键 **Ctrl+Alt+N**，
4. 或右上角的运行小三角按钮

<br/>

插件的作者是微软的韩老师，CodeRunner文章：《[VSCode插件推荐\] Code Runner: 代码一键运行，支持超过40种语言 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/54861567)》

