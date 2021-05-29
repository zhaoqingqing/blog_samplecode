从2017开始，在editor脚本中查找属性是这样写了 ` m_Script                = serializedObject.FindProperty("m_Script");`

以下代码摘自：UGUI的源码

[SerializedObject.FindProperty文档](https://docs.unity3d.com/ScriptReference/SerializedObject.FindProperty.html)

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
            SerializedProperty m_Script = serializedObject.FindProperty("m_Script");
            SerializedProperty m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
		}
	}
}
```

而在unity4.x时，查找某个属性并不是这样写的，而我实测，这种写法在unity2019中也是生效的

```c#
using UnityEditor;
using UnityEngine;
 
[CustomEditor(typeof(MyActor))]
public class MyActorInspector : Editor
{
    public int ATKProp;
    public int LuckyPointProp;
 
    void OnEnable()
    {
        MyActor myActor = target as MyActor; //类型转换为MyActor
        ATKProp = myActor.ATK;//缓存对象的某个字段和属性
    }
 
    public override void OnInspectorGUI()
    {
        ATKProp = EditorGUILayout.IntSlider("ATK", ATKProp, 0, 100);
        ProgressBar((ATKProp/100.0f),"ATK");
    }
}
```

区别：

serializedObject.FindProperty可以修改private的值，而另一种写法只能访问public的值

被编辑的对象需要加上[Serializable]标签，且FindProperty要找的字段需要加上[SerializeField]标签

文档：https://docs.unity.cn/cn/current/ScriptReference/SerializedObject.html



## 遇到问题

### serializedObject复选框无法勾选

```c#
protected override void OnEnable()
{
	base.OnEnable();
	UseLangId = serializedObject.FindProperty("useLangId");
	UseLangIdStr = new GUIContent("使用语言包");
}

public override void OnInspectorGUI()
{
	EditorGUILayout.PropertyField(UseLangId,UseLangIdStr); //这样会导致Inspector的复选框，无法勾选和取消
    serializedObject.Update();//NOTE 这句要放在最前面，否则无法操作复选框
    serializedObject.ApplyModifiedProperties();
	base.OnInspectorGUI();
}
```



### EditorGUI.indentLevel是什么意思？

//增加缩进深度，就是在这个属性的开头会有空格，需要配套出现

```c#
++EditorGUI.indentLevel;
for (int i = 0; i < paramArr.arraySize; i++)
{
	paramArr.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(paramArr.GetArrayElementAtIndex(i).stringValue);
	args[i] = paramArr.GetArrayElementAtIndex(i).stringValue;
}
--EditorGUI.indentLevel;
```

