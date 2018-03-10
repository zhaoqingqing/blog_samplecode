[title] = ugui中的toggle.isOn属性笔记

**准备知识**

toggle：指unity3d引擎中UGUI的 toggle组件 （单选框）

本文使用lua语言描述



**事件触发**

使用unity的ugui，你如果细心观察会发现toggle在界面被关闭/隐藏(active=false)之后，toggle的isOn属性并不会设置为false。

如果你依赖于Toggle的isOn用来触发事件，那么在下次打开时，由于toggle的isOn状态没有发生改变，事件就不会触发。

**toggle状态改变触发事件：**

```lua
toggle.onValueChanged:RemoveAllListeners()
toggle.onValueChanged:AddListener(function(isOn)
	if (isOn) then
		self:RefreshNotice(localData)
	end
end)
```



**小技巧**

如果你需要每次打开界面都触发IsOn绑定的事件，那么可以在界面被关闭时，取消Toggle的IsOn属性

**取消toggle示例：**

```lua
---TODO 请先保存当前界面所有的Toggle组件到self.toggles数组，在关闭时取消isOn属性
function UIChangePreview:OnClose()
    if self.toggles then
        for k, v in pairs(self.toggles) do
            if v then
                v.isOn = false
            end
        end
    end
end
```

