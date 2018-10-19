原因是由于安装了Sourcetree，受到了其环境变量的影响。解决方法如下：打开Sourcetree -> 工具 ->选项->Git,找到全局忽略列表，点击右侧编辑文件，找到*.dll，删除、保存即可。





TortoiseGit -> 右键 -> 设置 -> 对话框左边选GIT -> 右边点击编辑全局 .git/config

看到gitignore_global.txt这个有全局忽略，找到gitignore_global.txt编辑。

Mac上的SourceTree， 菜单SourceTree -> Preferences -> GIT -> 编辑 /Users/XXX/.gitignore_global

/Users/XXX/.gitignore_global
--------------------- 
作者：love_hot_girl 
来源：CSDN 
原文：https://blog.csdn.net/love_hot_girl/article/details/80928583?utm_source=copy 
版权声明：本文为博主原创文章，转载请附上博文链接！