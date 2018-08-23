 

### Canvas的实际大小#

canvas的大小，不能通过 Screen.width，Screen.height 来获取。

```c#
Canvas的大小 = 设定的分辨率 * canvas.transform.localScale.x
```
实际应用场景：[[UGUI\]游戏中的Tips贴图标边缘显示](https://www.cnblogs.com/zhaoqingqing/p/8858819.html)

