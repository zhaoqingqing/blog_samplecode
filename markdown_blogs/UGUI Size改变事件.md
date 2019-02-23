手动调用 强制更新Canvas之后，再获取高度`Canvas.ForceUpdateCanvases()`

RectTransform会在下一帧才更新

LayoutUtility.GetPreferredHeight(RectTransform)



https://docs.unity3d.com/ScriptReference/EventSystems.UIBehaviour.OnRectTransformDimensionsChange.html

This callback is called if an associated [RectTransform](https://docs.unity3d.com/ScriptReference/RectTransform.html) has its dimensions changed.

如果子节点设置了Anchor，父节点的事件触发时，也会传递到子节点