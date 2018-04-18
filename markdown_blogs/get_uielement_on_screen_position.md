### Tips贴图标边缘显示



##获取Mesh的四个顶点坐标



```c#
    //获取UI元素的屏幕坐标，四个坐标点的顺序为：左下 左上 右上 右下
	public static Vector3[] GetUIScreenPosition(Canvas canvas,RectTransform trans)
    {
        Vector3[] posArray = new Vector3[4];
        if (trans == null)
        {
            Log.Warning("canvas={0}或trans={1} ,为空",canvas,trans);
            posArray[0] = Vector3.zero;
            return posArray;
        }
        //NOTE 如果界面是以Camera方式渲染
        if (canvas && canvas.worldCamera)
        {
            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            //Log.Info("uiName={0},渲染模式为Camera", canvas.name);
            //NOTE 这种方式获取的坐标在图标中心点，计算出四个点的坐标
            var centerPos = canvas.worldCamera.WorldToScreenPoint(trans.position);
            var scaleFact = Screen.width/scaler.referenceResolution.x;
            var iconWidth = trans.sizeDelta.x*scaleFact;
            var iconHeight = trans.sizeDelta.y*scaleFact;
            //找到的点在左下角
//            posArray[0] = new Vector3(centerPos.x, centerPos.y , 0);
//            posArray[1] = new Vector3(centerPos.x, centerPos.y + iconHeight, 0);
//            posArray[2] = new Vector3(centerPos.x + iconWidth, centerPos.y + iconHeight, 0);
//            posArray[3] = new Vector3(centerPos.x + iconWidth, centerPos.y , 0);
            //找到的点在中心点
            posArray[0] = new Vector3(centerPos.x - iconWidth*0.5f, centerPos.y - iconHeight*0.5f, 0);
            posArray[1] = new Vector3(centerPos.x - iconWidth*0.5f, centerPos.y + iconHeight*0.5f, 0);
            posArray[2] = new Vector3(centerPos.x + iconWidth*0.5f, centerPos.y + iconHeight + iconHeight*0.5f, 0);
            posArray[3] = new Vector3(centerPos.x + iconWidth*0.5f, centerPos.y - iconHeight*0.5f, 0);
//            Log.Info("图标宽度={0},{1} ,中心点={2}",iconWidth,iconHeight,centerPos);
        }
        else
        {
            //Log.Info("uiName={0},渲染模式为Overlay",canvas.name);
            trans.GetWorldCorners(posArray);
        }

        return posArray;
    }
```
上面获取到图标四个点的世界坐标之后，可以计算出Tips的世界坐标，示例：

```c#
retRoot.position = pos
```

### 获取UI元素的实际大小

​	当在编辑器下开发时（或者设备分辨率和开发分辨率不相同时），**Game区域**大小并不是实际设置的分辨率大小，也就是说你从属性面板看到的Width和Height和图片实际的Size是有区别的。

​	那么如何获取某元素的实际大小呢？

```
//实际宽度= 宽度 * canvas的缩放值
var viewWidth = retRoot.sizeDelta.x * canvas.transform.localScale.x
```

