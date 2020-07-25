网上查了一下Unity的SetActive变化事件没有找到，我想到用另一种思路来实现这个事件通知，它可用来调试是何处把某个gameobject隐藏掉了

Unity提供了这两个函数，OnEnable，OnDisable，当SetActive时会调用这两个函数，所在这两个函数中发出事件就可以实现想要的效果。

用法：新建一个脚本挂在你需要监听变化的gameobject上，代码如下

```c#
using UnityEngine;
using System;

/// <summary>
/// 把此MonoBehaviour挂在你需要监听的gameobject上
/// </summary>
public class MonBehaviourEvent : MonoBehaviour
{
    /// <summary>
    /// gameobject的SetActive事件变化通知
    /// </summary>
    public Action<bool> OnActiveChange;

    void OnEnable()
    {
        OnActiveChange?.Invoke(true);
    }

    void OnDisable()
    {
        OnActiveChange?.Invoke(false);
    }
}
```



## 扩展SetActive

SetActive(true)，会触发MonoBehaviour.OnEnable()事件，就算对象之前本就是activeSelf=true，事件依然会发生； 
SetActive(false)，会触发MonoBehaviour.OnDisable()事件，就算对象之前本就是activeSelf=false，事件依然会发生；

所以在调用SetActive之前需要进行判断，扩展了如下，对于

```c#
public static class GameObjectEx
{
    public static void SetActiveX(this GameObject go, bool state)
    {
        if (go && go.activeSelf != state)
        {
            go.SetActive(state);
        }
    }

    public static void SetActive(this Component go, bool state)
    {
        if (go && go.gameObject && go.gameObject.activeSelf != state)
        {
            go.gameObject.SetActive(state);
        }
    }
}
```

