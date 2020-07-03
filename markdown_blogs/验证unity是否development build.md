libunity.so 大小在30MB以上，以unity2018.4.15f1为例，有46MB

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

