### 问题说明

突然出现torisegit会自动忽略*.dll文件不会提交，比如：CSharp.dll。

​      

### 问题原因

原因是由于安装了Sourcetree，受到了其环境变量的影响。

​      

### Windows系统解决方法

解决方法如下：

打开 Sourcetree -> 工具 ->选项->Git,找到全局忽略列表，点击右侧编辑文件，找到*.dll，删除、保存即可。

​      

### Mac系统解决办法

TortoiseGit -> 右键 -> 设置 -> 对话框左边选GIT -> 右边点击编辑全局 .git/config

看到**gitignore_global.txt**这个有全局忽略，找到gitignore_global.txt编辑。

Mac上的SourceTree， 菜单SourceTree -> Preferences -> GIT -> 编辑 /Users/XXX/.gitignore_global

示例

```
[core]
autocrlf = true
excludesfile = C:\\Users\\XXX\\Documents\\gitignore_global.txt
trustExitCode = true

```

​      

参考：https://blog.csdn.net/love_hot_girl/article/details/80928583?utm_source=copy 