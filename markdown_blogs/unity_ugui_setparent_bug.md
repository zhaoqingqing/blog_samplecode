[title] = ugui SetParent在安卓上一个诡异bug

**问题描述**

我的环境：Unity3D 5.3.7 ，在lua中出现的问题

出问题机型：安卓模拟器、部分低配安卓机型（比如：红米2A）

以下代码是设置某个节点的父节点，在PC、Editor、大部分手机上都是正常的，但问题机型上，设置后节点会消失。

```c#
RectTransform rectTransform = xxx;
rectTransform.SetParent(trans);
```

**解决办法**

使用transform的方法，并且给SetParent添加参数，最后设置它的SetActive(true) (**注意最后两行**)

```c#
RectTransform rectTransform = xxx;
rectTransform.transform.SetParent(trans,false);
rectTransform.gameObject.SetActive(true);
```



