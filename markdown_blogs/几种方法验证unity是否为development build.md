我在月初接入了[uwa的性能测试SDK](https://www.uwa4d.com/#download)，需要提交一个development build的游戏安装包给uwa进行真人真机测试，本文说下如何判断安装包是否为development build。

## 直观上判断

如果是development build模式打包出来的安装包，在游戏的画面的右下角会有development build的水印，且在切换场景也不会消失

## 通过libunity.so判断

使用压缩软件，打开apk，查看libunity.so（在lib/armxx目录下），如果是development build话libunity.so 会比较大，以Unity2018.4.15f1为例 development build的有46MB。而release模式只有20MB

## 通过代码判断

Unity引擎提供这样一个接口来访问是否 development build，原文如下：

In the Build Settings dialog there is a check box called "Development Build".

If it is checked isDebugBuild will be true. In the editor `isDebugBuild` always returns true. It is recommended to remove all calls to [Debug.Log](https://docs.unity3d.com/ScriptReference/Debug.Log.html) when deploying a game, this way you can easily deploy beta builds with debug prints and final builds without.

```c#
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        // Log some debug information only if this is a debug build
        if (Debug.isDebugBuild)
        {
            Debug.Log("This is a debug build!");
        }
    }
}
```



## Unity 打包设置

不管是通过Unity直接生成apk，还是导出android studio项目之后再生成apk，都需要加上`BuildOptions.Development`，就能保证导出的版本为development

```c#
BuildPipeline.BuildPlayer(GetScenePaths(), outPath, tag, BuildOptions.Development );
```