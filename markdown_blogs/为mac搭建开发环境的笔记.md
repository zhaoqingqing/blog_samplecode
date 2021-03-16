公司的游戏项目需要出ios包上架到app store，由我负责接入ios的sdk，这里记录一下为mac搭建开发环境的笔记，大多是软件和编程习惯相关的内容。

## 常用软件

解压缩软件：bandizip在mac下是收费软件，所以使用360压缩代替

截图/贴图：snipaste，windows和mac下都是免费的

svn:《[MAC OS 图形化SVN管理工具](https://www.cnblogs.com/zhaoqingqing/p/3715941.html)》

文本编辑器：vscode

start Menu: 在任务栏显示网速和cpu使用率

输入法：mac系统中可以添加五笔输入法，切换键为ctrl+空格

企业QQ需要公司升级为企点才可以使用

## 编程习惯

### xcode

在mac中编写objc是使用xcode

mac中没有home和end，取而代之的是苹果键+左右箭头

### vs社区版

vs社区版在mac上可以调试unity，使用习惯和windows上有些差异，也可以使用rider来编写C#代码，使用体验一致。

## 系统管理

### 修改hosts

《[Mac OS 下三种修改Hosts文件的方法](https://blog.csdn.net/qq_41162289/article/details/80239468)》

1. 打开Finder，点击 前往 输入/etc/
2. 右键选择'显示简介'，在底部先解锁，给Everyone添加读写权限
3. 编辑hosts文件，然后保存

### 执行sh脚本

打开终端，cd 到脚本所在的目录，然后拖动脚本过去。

**注意：一定要cd到脚本所在目录，才能正确地执行脚本，这点和windows下还是不一样的。**

如果报错 ：: Permission denied。就是没有权限。

解决办法：修改该sh 的权限 ：使用命令： chmod 777 xx.sh 。

chmod +x 是将文件状态改为可执行，而chmod 777 是改变文件读写权限

### 执行python脚本

查看我的这篇文章《[在mac中双击执行python](https://www.cnblogs.com/zhaoqingqing/p/14545453.html)》



## 其它资料

mac软件下载：https://macwk.com/

mac中的快捷键使用：https://macwk.com/article/macos-keyboard-shortcuts

| ⌥ option 对应alt | ⌃cmd 对应ctrl | ⌘apple键 对应 win图标 |
| ---------------- | ------------- | --------------------- |
| ⇧ 对应shift      |               |                       |
|                  |               |                       |

剪切/移动文件 Command + Option + V
在 Mac 的文件右键菜单上也没有“剪切”操作的，对文件使用 Cmd+C 然后 Cmd+V 只能完成「复制」。而使用 Cmd+C 然后 Command + Option + V 快捷键，则可实现「移动文件」，文件被复制到新的位置后，原路径下的文件会被删除，相当于 Windows 下的剪切。

立即锁定屏幕 Control + Command + Q