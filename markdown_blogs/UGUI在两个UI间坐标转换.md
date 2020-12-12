在UGUI中，在两个Canvas之间进行坐标转换，从CanvasA下的坐标转换到CanvasB下。

或者在同一个界面下，从不同的节点下，转成相同的坐标。



**函数定义**

public static bool **ScreenPointToLocalPointInRectangle**([RectTransform](https://docs.unity3d.com/ScriptReference/RectTransform.html) **rect**, [Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) **screenPoint**, [Camera](https://docs.unity3d.com/ScriptReference/Camera.html) **cam**, out [Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) **localPoint**);

解释：

**rect：**目标界面的最上层节点，可以传Canvas的RectTransform

**screenPoint：**要转换的节点屏幕坐标，如果worldCamera为空就返回 vector2.zero

**cam：**目标界面的camera，如果 Canvas 的模式为Screen Space - Overlay mode, the cam parameter should be null.

**localPoint：** 转换后的坐标点

**返回值：**判断此点是否在Rect所在的平面上



最后算出来的结果使用：rectTransform.anchoredPosition ＝ localPoint



**要转节点的屏幕坐标**

var screenPoint = canvas.worldCamera.WorldToScreenpoint(obj.transform.position)



通过查看ugui的Slider(滑块)源码

````c#
void UpdateDrag(PointerEventData eventData ,Camera cam)
{
  RectTransformUtility.ScreenPointToLocalPointInRectangle(clickRect,eventData.position,cam,out localcursor)
}
````

## 相对于父节点的坐标

父节点.InverseTransformPoint(子节点.transform.position)，这样得到的坐标就是脱离层级关系后的坐标