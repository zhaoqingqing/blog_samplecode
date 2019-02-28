问题：

RectTransform如果使用transform.postion，复制出来的RectTransform使用相同的postion赋值，坐标不一致。



注意点：

所有父节点的anchposition都需要是0，才不会影响。



但是为什么父节点的postion，会影响到子节点的transform.position呢？



解决办法：

需要在SetParent时，双方都使用transform，示例：

```c#
local effectNode = GameObject.Instantiate(self.EffectNode.transform)
child.transform:SetParent(effectNode)
child.transform.position = effectNode.position
```





获取RectTransform的world position

https://stackoverflow.com/questions/43736079/position-of-rect-transform-in-unity-ui