一直使用Typora编写markdown，随着vscode在工作中使用的越来越多，产生了一个想法：能不能在vscode中写markdown，减少软件的成本?

可是vscode官方自带的的markdown体验却一般般，那么有没有更好的markdown扩展呢？

PS.最好是体验与typora接近，可以更快的上手与转换。

经过一番查找，找到了一个比较符合条件的扩展：office viewer

<br/>

## office viewer

扩展地址：[ Office Viewer(Markdown Editor) - Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=cweijan.vscode-office)

github地址：[cweijan/vscode-office: 让VSCode支持预览PDF,Excel等格式, 并增加markdown所见即所得编辑器 (github.com)](https://github.com/cweijan/vscode-office)

该扩展在vscode内集成[Vditor](https://github.com/Vanessa219/vditor)(针对VSCode做了些[兼容性改动](https://github.com/vscode-ext-studio/vditor)), 实现了对markdown的所见即所得编辑, 相比typora的特性:

- 开源免费无广告无隐私追踪 (如果对你有帮助考虑点下star(●'◡'●))
- 在最新版本中优化了vscode主题支持, 现在颜色默认跟随vscode主题
- vscode内置了git, 创建一个git仓库就可以对markdown进行版本管理
- 支持多窗口打开markdown (typora只支持mac)
- 相比typora的缺点: 对代码块, latex公式和图形支持度不高.

<br/>

## 重度使用14天后的感受

所见即所得的体验还可以的，虽然比Typora弱一些，但是他可以与vscode集成，能够在workspace中管理我不同目录的markdown。

突然发现Typora也可以全局搜索当前打开目录下的任意文件，快捷键：Ctrl+P，这种高效搜索法能让你在数千数万文件中跳到你想找的文件去。

> PS. 虽然typora没有workspace，但自已动手把不同文件夹link到一起，用起来也和workspace一样。

`<br/>`

## 代码块与主题问题

建议安装后修改vscode的主题为：One Dark Modern，同时建议启用扩展自带文件夹图标。因为在其它深色主题下代码片段(`代码片段`)在预览时区分不出来，而扩展自带的主题可以。

但是修改为One Dark Modern之后，python代码的缩进符就看不清楚了，这就有取舍问题。

或者根据不同的workspace使用不同的主题

<br/>

## 切换窗口回到起点

解决方法：只要md文件中有焦点就不会出现这个问题，具体可查阅官方的issue

[不同程序窗口切换回来之后，回到文件开头 · Issue #116 · cweijan/vscode-office (github.com)](https://github.com/cweijan/vscode-office/issues/116)

<br/>

## 图片位置

如何修改粘贴图片后保存的位置？打开扩展设置，修改paster img path的路径。

[请问如何修改保持图片的路径 · Issue #70 · cweijan/vscode-office (github.com)](https://github.com/cweijan/vscode-office/issues/70)

<br/>

## 代码预览

建议关闭代码预览 ，取消勾选扩展设置中的Preview Code，因为鼠标点击代码区域后会显示两份代码。

参考：[请问如何更改vditor设置 · Issue #112 · cweijan/vscode-office (github.com)](https://github.com/cweijan/vscode-office/issues/112)

<br/>

## 感谢作者

在我重度使用过程中，往github提了几个我碰到的issue，这些issue都很快地得到了作者的回复，作为个人开源者的确很棒！
