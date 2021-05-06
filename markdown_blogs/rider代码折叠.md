## 可折叠元素块

rider那些元素块是可折叠？参考官方文档：[Fold Code Elements](https://www.jetbrains.com/help/rider/Code_Folding.html)

Code folding works for the keywords if/ while/ else/ for/ try/ except/ finally/ with in case of at least two statements.

## 自定义折叠

有两种方法进行自动定义折叠

1. 添加 `#region xxx代码  #endregion`包围的代码是可以折叠的，可以选中需要添加的代码，点击 Code - Surround With，就会自动添加 region

2. 如果你想折叠任意代码而又不想修改原代码，选中你需要的折叠的代码，按下Ctrl+. 就可以折叠或解折叠选中的代码，或点击菜单Code - Fold - Fold Selection




## 默认折叠代码块

在rider中设置默认需要折叠的代码块：

Ctrl + Alt +S 打开设置，输入Code Fold，就可以设置默认需要折叠的代码块