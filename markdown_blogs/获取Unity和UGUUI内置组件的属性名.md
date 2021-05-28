## 需求来源

在阅读UGUI的源码时，发现Unity对于私有字段才加了[[SerializeField]]标签，而public的没有，且在Editor扩展中，也是查找带序列化标签的私有字段进行修改，那么在开发编辑器插件时，就很有必要知道私有字段名，因为在Inspector中看到是公用字段名(如果切换到中文之后就是汉字)，那么怎样获取这个序列化属性的名字呢？

### 快速获得属性名

对于Unity自带组件的某些属性，如果你不知道属性名称，可以这样做：

1. 选中组件中所在的GameObject，转到属性面板(Inspect)的组件上，把鼠标移到你要的属性上
2. 按住Shift+右键 - 选择 打印属性路径(Print Property Path)，在Console中就会打印你鼠标所在的属性名

PS. 对于自定义的脚本，如果是属性而不是字段，就是有get和set的，也是可以这样操作的，像这样的`[SerializeField] public string LangId;`就无法使用。

![image-20210528113910950](https://img2020.cnblogs.com/blog/363476/202105/363476-20210528114334741-9181711.png)

## ugui的源代码示例

如果在编辑器开发要访问Selectable.cs这两个属性是m_Colors和m_TargetGraphic，而Inspector上显示的是colors和targetGraphic

```c#
// Colors used for a color tint-based transition.
[FormerlySerializedAs("colors")]
[SerializeField]
private ColorBlock m_Colors = ColorBlock.defaultColorBlock;
public ColorBlock colors            
{ 
	get { return m_Colors; } 
	set {if (SetPropertyUtility.SetStruct(ref m_Colors, value))  OnSetProperty(); } 
}
```

```c#
// Graphic that will be colored.
[FormerlySerializedAs("highlightGraphic")]
[FormerlySerializedAs("m_HighlightGraphic")]
[SerializeField]
private Graphic m_TargetGraphic;
public Graphic targetGraphic     
{ 
	get { return m_TargetGraphic; } 
	set { if (SetPropertyUtility.SetClass(ref m_TargetGraphic, value))     OnSetProperty(); } 
}
```

