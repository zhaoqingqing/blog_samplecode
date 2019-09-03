UGUI在两个Canvas之间进行坐标转换

从A界面转成B界面的坐标

B界面为目标界面



RectTransformUtility.ScreenPointToLocalPointInRectangle(目标界面RectTransform,要转的节点屏幕坐标，目标界面的camera,out 转换后的坐标点)



**要转的节点屏幕坐标**

如果worldCamera为空就返回 vector2.zero

var screenPoint = canvas.worldCamera.WorldToScreenpoint(obj.transform.position)

示例：

```c#

```

