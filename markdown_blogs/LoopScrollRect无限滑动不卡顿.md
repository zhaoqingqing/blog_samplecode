### **LoopScrollRect(无限滑动不卡顿)**

插件地址：<https://github.com/qiankanglai/LoopScrollRect>

中文文档：<http://qiankanglai.me/2015/08/15/LoopScrollRect/>

 

### 原理分析

在UGUI的ScrollRect基础上作的修改

两者的差异部分使用`//==========LoopScrollRect========== `标识出来了

UGUI的ScrollRect:https://bitbucket.org/Unity-Technologies/ui/src/5.2/UnityEngine.UI/UI/Core/ScrollRect.cs?fileviewer=file-view-default

LoopScrollRect:https://github.com/qiankanglai/LoopScrollRect/blob/master/Assets/Scripts/LoopScrollRect.cs

### 使用示例

可以参考demo的示例

如果在lua中使用，逻辑和C#的一样

1.注册事件

2.刷新函数操作数据 

3.调用逻辑



### **注册事件**

注册列表滑动事件，在**OnInit**中注册一次，用来刷新列表

此事件在C#中触发，Lua中注册回调，事件有两个参数

```lua
  self.chatScrollRect.dataSource:ScrollToTextEvent("+", handler(self, UIChat.OnScrollChat, self, cellTrans, idx))
```



### **取消注册**

取消注册的列表滑动事件，在**OnClose**中取消

```lua
  self.chatScrollRect.dataSource:ScrollToTextEvent("-", UIChat.OnScrollChat)
```



### **触发滑动事件(刷新每一项)**

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



### 手动刷新列表

```lua
--设置列表的总数，并刷新cell
self.chatScrollRect.totalCount = 10
self.chatScrollRect:RefreshCells()
```



### 刷新并让列表滑动到底部

```lua
self.chatScrollRect:RefillCellsFromEnd()
```



### 两个刷新函数区别

RefreshCells：列表刷新

RefillCellsFromEnd：刷新最底部的消息，并滑动到底部



### 列表滑动到底部的事件

和UGUI的ScrollRect的做法一样，为scrollRect添加一个scrollbar，捕捉OnEndDrag事件，示例如下：

```lua
    self.chatScrollRect.onEndDrag = function(data)
        if self.chatScrollbar.value >= 1 then
            print("scroll to bottom")
        end
    end
```



### prefabSource为nil

如果在热更新的包中报prefabSource为nil，是因为热更新dll之后，prefabSource会丢失，需要在lua对prefabSource重新赋值，示例：

```lua
self.scrollRect.prefabSource = CS.UnityEngine.UI.XLoopScrollPrefabSource(self.itemCell.gameObject)
```



### 技巧和事项

为每一个Cell都绑定LayoutElement组件，并勾选Preferred Width 和Preferred Height，且给它们赋值。



跳转到指定的index/Item：

https://github.com/qiankanglai/LoopScrollRect/issues/14

https://github.com/qiankanglai/LoopScrollRect/issues/27



查找某一项的取巧做法：可以用id做为Cell的名字，当在查找时，根据FindChild(id)找到这一项，进行刷新。