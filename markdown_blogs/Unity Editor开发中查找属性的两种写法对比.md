从2017开始，在editor脚本中查找属性是这样写的 ` var m_Script = serializedObject.FindProperty("m_Script");`

## SerializedProperty

以UGUI的源码为例

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

## 直接修改

而我在unity4.x时，查找某个属性是这样写的，我在Unity2019和Unity2020中测试目前这种写法还是生效的

```c#
using UnityEditor;
using UnityEngine;
 
[CustomEditor(typeof(MyActor))]
public class MyActorInspector : Editor
{
    public int ATKProp;
 
    void OnEnable()
    {
        MyActor myActor = target as MyActor; //类型转换为MyActor
        ATKProp = myActor.ATK;//缓存对象的某个字段和属性
    }
 
    public override void OnInspectorGUI()
    {
        ATKProp = EditorGUILayout.IntSlider("ATK", ATKProp, 0, 100);
    }
}
```

## 这两种写法有什么区别呢？

serializedObject.FindProperty可以修改private的值，而直接修改只能访问public的值

SerializedProperty被编辑的对象需要加上[Serializable]标签，且要找的属性如果是private需要加上[SerializeField]标签，否则序列化会报错

SerializedProperty写法的值在编辑过程中可以撤消(Undo)、Prefab overrides，而直接修改无法撤消，就是按Ctrl+Z无效，所以建议平时还是使用FindProperty开发。

SerializedProperty中指向当前对象叫 [serializedObject](https://docs.unity.cn/cn/current/ScriptReference/Editor-serializedObject.html) ，在直接写叫 target

SerializedProperty文档：[https://docs.unity.cn/cn/current/ScriptReference/SerializedObject.html](https://docs.unity.cn/cn/current/ScriptReference/SerializedObject.html)

在官网文档中也有提到这两种写法的区别：[https://docs.unity.cn/cn/current/ScriptReference/Editor.html](https://docs.unity.cn/cn/current/ScriptReference/Editor.html)

​     

## SerializedProperty文档



```c#
// 更新序列化属性，写在OnInspectorGUI的开头
serializedObject.Update ();

//对序列化属性修改后，需要应用修改才能保存序列化数据，要写在OnInspectorGUI方法的结尾
serializedObject.ApplyModifiedProperties ();
```

## 遇到问题

### serializedObject复选框无法勾选

比如下面这段代码就会让复选框无法操作

```c#
protected override void OnEnable()
{
	base.OnEnable();
	UseLangId = serializedObject.FindProperty("useLangId");
}

public override void OnInspectorGUI()
{
	EditorGUILayout.PropertyField(UseLangId,"使用语言包"); //这样会导致Inspector的复选框，无法勾选和取消
    serializedObject.Update();//NOTE 这句要放在最前面，否则无法操作复选框
    serializedObject.ApplyModifiedProperties();
	base.OnInspectorGUI();
}
```



### EditorGUI.indentLevel是什么意思？

增加缩进深度，就是在这个属性的开头会有空格，需要配套出现，示例如下：

```c#
++EditorGUI.indentLevel;
for (int i = 0; i < paramArr.arraySize; i++)
{
	paramArr.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(paramArr.GetArrayElementAtIndex(i).stringValue);
	args[i] = paramArr.GetArrayElementAtIndex(i).stringValue;
}
--EditorGUI.indentLevel;
```

