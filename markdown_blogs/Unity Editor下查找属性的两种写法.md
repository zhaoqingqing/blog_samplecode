从2017开始，在editor脚本中查找属性是这样写了 ` m_Script                = serializedObject.FindProperty("m_Script");`

以下代码摘自：UGUI的源码

```c#
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.AnimatedValues;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(Selectable), true)]
    /// <summary>
    ///   Custom Editor for the Selectable Component.
    ///   Extend this class to write a custom editor for an Selectable-derived component.
    /// </summary>
    public class SelectableEditor : Editor
    {
        protected virtual void OnEnable()
        {
            m_Script                = serializedObject.FindProperty("m_Script");
            m_InteractableProperty  = serializedObject.FindProperty("m_Interactable");
		}
	}
}
```

而在unity4.x时，查找某个属性并不是这样写的，而我实测，这种写法在unity2019中也是生效的