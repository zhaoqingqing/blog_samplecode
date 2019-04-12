加载Assets目录下的资源，以Assets为前缀

可以通过链接的方式，链接其它工程的资源到当前工程

getAsset = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/" + KEngineDef.ResourcesBuildDir + "/" + path, typeof(UnityEngine.Object));





AssetFileLoader