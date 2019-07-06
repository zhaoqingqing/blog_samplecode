### Editor下加载Prefab

加载Assets目录下的资源，以Assets为前缀

当给策划做编辑器时，可以通过链接的方式，链接其它工程的资源到当前工程，这样就不用拷贝，也可以保证两边资源是一致的。

参考：AssetFileLoader.cs

```c#
getAsset = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/" + KEngineDef.ResourcesBuildDir + "/" + path, typeof(UnityEngine.Object));
```



### 判断Gameobject是否为Prefab

```c#
//判断GameObject是否为一个Prefab的引用
if(PrefabUtility.GetPrefabType(go)  == PrefabType.PrefabInstance)
{
	UnityEngine.Object parentObject = EditorUtility.GetPrefabParent(go); 
	string path = AssetDatabase.GetAssetPath(parentObject);
	//判断GameObject的Prefab是否和右键选择的Prefab是同一路径。
	if(path == AssetDatabase.GetAssetPath(Selection.activeGameObject))
	{
		//输出场景名，以及Prefab引用的路径
		Debug.Log(scene.path  + "  " + GetGameObjectPath(go));
	}
}
```



### prefab拉到Hierarchy里

自动将预制添加到场景中，但是又不想破坏预制的链接关系，这时候可以使用[PrefabUtility](http://docs.unity3d.com/ScriptReference/PrefabUtility.html)类进行操作。

```c#
string path = AssetDatabase.GetAssetPath(selectGO);  
GameObject uiInstance = PrefabUtility.InstantiatePrefab(selGb) as GameObject  
```
