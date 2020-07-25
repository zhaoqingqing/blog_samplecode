MeshFilter有两个属性mesh和sharedMesh，从官方文档和实际使用来说说这两者的区别

## MeshFilter文档

Unity的MeshFilter文档：https://docs.unity3d.com/ScriptReference/MeshFilter.html

| [mesh](https://docs.unity3d.com/ScriptReference/MeshFilter-mesh.html) | Returns the instantiated Mesh assigned to the mesh filter. |
| ------------------------------------------------------------ | ---------------------------------------------------------- |
| [sharedMesh](https://docs.unity3d.com/ScriptReference/MeshFilter-sharedMesh.html) | Returns the shared mesh of the mesh filter.                |

mesh访问的是一个新的object(新实例)

sharedMesh是原始资源，所有实例的属性共用同一份，也就是说修改它共用属性全部实例都会发生改变，如果在编辑器下且直接对原始资源的sharedMesh进行修改，则原始资源也会发生改变。



## 使用情景

如果我们不需要修改mesh中具体的属性，仅仅是对它赋值的话（比如从ab中加载出来进行设置或替换），那么使用sharedMesh

如果在Editor脚本开发中，需要修改mesh中的数据，则使用mesh



## mesh文档解释

关于mesh的unity文档解释：

Returns the instantiated [Mesh](https://docs.unity3d.com/ScriptReference/Mesh.html) assigned to the mesh filter.

If no mesh is assigned to the mesh filter a new mesh will be created and assigned.

If a mesh is assigned to the mesh filter already, then first query of `mesh` property will create a duplicate of it, and this copy will be returned. Further queries of `mesh` property will return this duplicated mesh instance. Once `mesh` property is queried, link to the original shared mesh is lost and [MeshFilter.sharedMesh](https://docs.unity3d.com/ScriptReference/MeshFilter-sharedMesh.html) property becomes an alias to `mesh`. If you want to avoid this automatic mesh duplication, use [MeshFilter.sharedMesh](https://docs.unity3d.com/ScriptReference/MeshFilter-sharedMesh.html) instead.

By using `mesh` property you can modify the mesh for a single object only. The other objects that used the same mesh will not be modified.

It is your responsibility to destroy the automatically instantiated mesh when the game object is being destroyed. [Resources.UnloadUnusedAssets](https://docs.unity3d.com/ScriptReference/Resources.UnloadUnusedAssets.html) also destroys the mesh but it is usually only called when loading a new level.

翻译成中文如下：

如果一个mesh已经被分配给MeshFilter，那么第一次查询mesh属性会创建一个副本，这个副本会被返回。进一步查询mesh属性将返回这个复制的mesh实例。一旦mesh属性被查询，链接到原始共享网格会丢失，MeshFilter.sharedMesh属性成为mesh的别名。如果你想避免这种自动生成副本，使用MeshFilter.sharedMesh代替。

通过使用mesh属性，您可以仅修改单个对象的mesh。其他使用相同mesh的对象将不会被修改。

当游戏对象被销毁时，销毁自动实例化的mesh是你的责任。UnloadUnusedAssets也会破坏mesh，但通常只在Scene.LoadNewLevel时调用。

## mesh伪代码

猜测mesh的实现代码大致如下：

```c#
public class MeshFilter ...
{
	...
	private Mesh _mesh;
	public Mesh mesh
	{
		get
		{
			if (_mesh == null) 
			{
				_mesh = new Mesh();
				Copy(sharedMehs, _mesh);
			}
			return _mesh;
		}
	}
	...
}
```

