## 我的环境

Unity 5.3.7p4

在运行时动态的设置UI元素的锚点和中心点。

## 设置坐标

对于UI上的元素，使用anchorPosition，而不是localpostion，因为Recttransform可以设置锚点。

## 设置Anchor

### 修改offsetMax不生效
使用下面这段代码设置Anchor并不会生效，尽管他和你在属性面板看到的值是一样的。
```lua
retRoot.offsetMin = Vector2(0,0)
retRoot.offsetMax = Vector2(0,0) 
```

### SetInsetAndSizeFromParentEdge

使用SetInsetAndSizeFromParentEdge函数来进行设定。此函数不受锚点和中心的影响，其中第一个参数代表对齐方式，第二个参数为距离边界的距离，第三个参数为宽度或高度。

示例：
```lua
---设置为左上角
retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width)
retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, height)
```

### 修改Anchor不会影响Pivot

修改Anchor之后，并不会影响Pivot

## 设置Pivot(中心点)

pivot是一个0~1之间的值 示例：`retRoot.pivot = Vector2(0, 0)`

其中0，0为左下角

当你要做动画，设置父容器的Pivot就可以控制动画的出现方向


### 查看Pivot

在Editor的工具栏将Pivot的模式设置为这个模式（Pivot  Local），才能查看到正确的Pivot。

![](https://images2018.cnblogs.com/blog/363476/201804/363476-20180419165746196-472786449.png)

## 示例代码

设置左上、左下、右上、右下四个锚点，并同时设置中心点。

```lua

---@param retRoot UnityEngine.RectTransform
function TipsHelper.SetTipsAnchor(retRoot, anchor, width, height)
    if not retRoot then
        print("[error] SetAnchor失败，RectTransform不能为空")
        return
    end
    if anchor == Constants.Anchor.LeftTop then
        retRoot.pivot = Vector2(0, 1)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, height)
    elseif anchor == Constants.Anchor.LeftBottom then
        retRoot.pivot = Vector2(0, 0)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, width)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, height)
    elseif anchor == Constants.Anchor.RightTop then
        retRoot.pivot = Vector2(1, 1)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, width)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, height)
    elseif anchor == Constants.Anchor.RightBottom then
        retRoot.pivot = Vector2(1, 0)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, width)
        retRoot:SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, height)
    end
end
```
## 代码设置Stretch

**填充父节点：**

```csharp
var uiRect = uiElement.GetComponent<RectTransform>();
uiRect.localScale = Vector3.one;
uiRect.localPosition = Vector3.zero; // 注意Pos.z也要设置
uiRect.sizeDelta = parent.GetComponent<RectTransform>().sizeDelta;
```

**填充整个屏幕：**

```c#
public static void StretchFull (this RectTransform rect, float paddingLeft, float paddingTop, 
                               float paddingRight, float paddingBottom) {
    rect.anchorMin = Vector2.zero;
    rect.anchorMax = Vector2.one;
    rect.offsetMin = new Vector2 (paddingLeft, paddingBottom);
    rect.offsetMax = new Vector2 (-paddingRight, -paddingTop);
}
```





## 参考资料

- [unity-ugui-原理篇三：recttransform](http://www.arkaistudio.com/blog/334/unity/unity-ugui-%E5%8E%9F%E7%90%86%E7%AF%87%E4%B8%89%EF%BC%9Arecttransform)
- [成為 UGUI 的排版大師 – 一次精通 RectTransform](https://blog.fourdesire.com/2018/07/03/%E6%88%90%E7%82%BA-ugui-%E7%9A%84%E6%8E%92%E7%89%88%E5%A4%A7%E5%B8%AB-%E4%B8%80%E6%AC%A1%E7%B2%BE%E9%80%9A-recttransform/)

