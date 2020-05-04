##  应用场景

对于背包界面，排行榜列表，聊天消息，等有大量的UI列表的界面，常规做法是为每一条数据生成一个格子，在数据量越大的情况下，会生成越来越多的Gameobject，引起卡顿。


这篇文章讲述的就是解决UI列表卡顿的方法，在列表中只生成指定数量的Gameobject，滑动时进行数据更新，保证性能。

![](https://images2018.cnblogs.com/blog/363476/201712/363476-20171203124445085-1144195685.gif)



## **LoopScrollRect(UGUI循环列表不卡顿)**

插件地址：<https://github.com/qiankanglai/LoopScrollRect>

中文文档：<http://qiankanglai.me/2015/08/15/LoopScrollRect/>

适用于UGUI，支持UGUI原生的GridLayout，ScrollBar

我的修改版本：https://github.com/zhaoqingqing/LoopScrollRect.git


## 原理分析

在UGUI的ScrollRect基础上作的修改

两者的差异部分使用`//==========LoopScrollRect========== `标识出来了，源代码对比：

UGUI的ScrollRect:https://bitbucket.org/Unity-Technologies/ui/src/5.2/UnityEngine.UI/UI/Core/ScrollRect.cs?fileviewer=file-view-default

LoopScrollRect:https://github.com/qiankanglai/LoopScrollRect/blob/master/Assets/Scripts/LoopScrollRect.cs


## 使用示例

可以参考demo的示例

如果在lua中使用，逻辑和C#的一样，步骤如下：

1.注册事件、取消注册

2.在刷新函数根据数据更新列表 

3.调用逻辑



## **注册事件**

注册列表滑动事件，在**OnOpen**中注册，用来刷新列表

此事件在C#中触发，Lua中注册回调，事件有两个参数

```lua
    self.chatScrollRect.dataSource.ScrollToTextEvent = function(cellTrans, idx) self:OnScrollChat(cellTrans, idx) end
```



## **取消注册**

取消注册的列表滑动事件，在**OnClose**中取消

```lua
  self.chatScrollRect.dataSource.ScrollToTextEvent = nil 
```



## **触发滑动事件(刷新每一项)**

在以下情况事件会被触发：

1. 如果列表的值已全部生成出来，在滑动过程中不会触发，否则会触发
2. 调用RefreshCells或RefillCellsFromEnd时，会触发

```lua
function UIRewardResources:OnScrollEvent(cellTrans, idx)
    if (not cellTrans or not idx) then
        return
    end
    idx = idx + 1 -- Lua的索引从1开始,而scrollRect是从0开始
    local data = DataCenter.resource.data[idx]
  	--执行你的刷新逻辑
    self:DoRenderItem(cellTrans, data)
end
```



## 手动刷新列表

```lua
--设置列表的总数，并刷新cell
self.scrollRect.itemTypeStart = 0 ---让列表从头开始滑动
self.chatScrollRect.totalCount = 10
self.chatScrollRect:RefreshCells()
```



## 刷新并让列表滑动到底部

在聊天列表中每次发言完都是最新消息都在最底下，可以使用这个接口

```lua
self.chatScrollRect:RefillCellsFromEnd()
```

如果在模拟器上出现无法滑动到底部的现象，在Unity 2018.4.15f + 网易MuMu模拟环境下可添加下列代码

```c#
IEnumerator RefreshToEnd()
{
	yield return null;
	yield return null;
	Canvas.ForceUpdateCanvases();
	loop_scroll.verticalNormalizedPosition = 1.0f;
}
```



## 两个刷新函数区别

RefreshCells：列表刷新

RefillCellsFromEnd：从最底部的消息开始刷新，并滑动到底部



## 列表滑动到底部的事件


和UGUI的ScrollRect的做法一样，为scrollRect添加一个scrollbar，捕捉OnEndDrag事件，示例如下：

```lua
    self.chatScrollRect.onEndDrag = function(data)
        if self.chatScrollbar.value >= 1 then
            print("scroll to bottom")
        end
    end
```


如果你的数据量特别大，在滑动到底部事件时进行分页请求数据


如果是做分页：建议在滑动到某个数量级且滑动到底部时，设置一次数据，保证滑动的流畅性


## prefabSource为nil

如果在热更新的包中报prefabSource为nil，是因为热更新dll之后，prefabSource会丢失，需要在lua对prefabSource重新赋值，示例：

```lua
self.scrollRect.prefabSource = CS.UnityEngine.UI.XLoopScrollPrefabSource(self.itemCell.gameObject)
```




## 跳转到指定的index/Item

参考：https://github.com/qiankanglai/LoopScrollRect/issues/14


方法一：

设置itemTypeStart为需要的Pos

```lua
	self.scrollRectEquipList.content.anchoredPosition = Vector2.zero
	self.scrollRectEquipList.itemTypeStart = pos - 1
	self.scrollRectEquipList.totalCount = equipCount
	self.scrollRectEquipList:RefreshCells()
```

方法二：不绑定initInStart脚本，并调用 RefillCells(90)

## 两次调用列表滑动位置不正确

对于tab页签，左右切页都使用同一个ScrollRect，在前一个滑动到底部之后，再切到下一个页签，会出现列表还在滑动的现象，在切换页签前添加以下代码，停止上一次的滑动，并把位置进行复位

```c#
void ResetPos()
{
	loop_scroll.StopAllCoroutines();
	loop_scroll.StopMovement();
	loop_scroll.content.anchoredPosition = Vector2.zero;
}
```





## 技巧和事项

Cell指：每一个格子，或每一项列表


为每一个Cell都绑定LayoutElement组件，并勾选Preferred Width 和Preferred Height，且给它们赋合适值，保证列表自适应。

查找某一项的取巧做法：可以用id做为Cell的名字，当在查找时，根据FindChild(id)找到这一项，进行刷新。

滑动到指定的index/Item：

https://github.com/qiankanglai/LoopScrollRect/issues/14

https://github.com/qiankanglai/LoopScrollRect/issues/27