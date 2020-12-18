根据我自己的开发经验来说过，如果是多年服务器的同事习惯开发C++/lua来说，他们绝大多数是喜欢用_连接单词has_read，私有变量以_开头如：_skill_id，而对于C#来说则风格比较多，各种类型都有。

## 常见的命名方式


| Pascal(帕斯卡)                | Camel(驼峰法)    | C++/lua常用 |
| ----------------------------- | ---------------- | ----------- |
| 微软windows文件夹以此规范命名 | Unity3D字段/属性 |             |
| BitFalg                       | bitFalg          | bit_flag    |
| Callback                      | callback         |             |
| DoNot                         | doNot            |             |
| Email                         | email            |             |



## 微软的C#命名规范

MSDN上C#大小写约定：[https://msdn.microsoft.com/zh-cn/library/ms229043.aspx](https://msdn.microsoft.com/zh-cn/library/ms229043.aspx)

不建议使用 下划线(_)

更多内容参考我的这篇文章：[C# 编码约定（C# 编程指南）](https://www.cnblogs.com/zhaoqingqing/p/3954119.html)

## Unity官方的命名规范

Unity官方的WIKI上有写：[Csharp Coding Guidelines](http://wiki.unity3d.com/index.php/Csharp_Coding_Guidelines)


这个命名规范从Unity的脚本API中可以看出来，以[MonoBehaviour脚本API]()为例，字段及属性首字母小写，如下表所示：

## Properties

| [enabled](https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html) | Enabled Behaviours are Updated, disabled Behaviours are not. |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [isActiveAndEnabled](https://docs.unity3d.com/ScriptReference/Behaviour-isActiveAndEnabled.html) | Has the Behaviour had active and enabled called?             |
| [gameObject](https://docs.unity3d.com/ScriptReference/Component-gameObject.html) | The game object this component is attached to. A component is always attached to a game object. |
| [tag](https://docs.unity3d.com/ScriptReference/Component-tag.html) | The tag of this game object.                                 |
| [transform](https://docs.unity3d.com/ScriptReference/Component-transform.html) | The Transform attached to this GameObject.                   |
| [hideFlags](https://docs.unity3d.com/ScriptReference/Object-hideFlags.html) | Should the object be hidden, saved with the Scene or modifiable by the user? |
| [name](https://docs.unity3d.com/ScriptReference/Object-name.html) | The name of the object.                                      |




方法首字母大写，如下表所示：

## Public Methods

| [BroadcastMessage](https://docs.unity3d.com/ScriptReference/Component.BroadcastMessage.html) | Calls the method named methodName on every MonoBehaviour in this game object or any of its children. |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [CompareTag](https://docs.unity3d.com/ScriptReference/Component.CompareTag.html) | Is this game object tagged with tag ?                        |
| [GetComponent](https://docs.unity3d.com/ScriptReference/Component.GetComponent.html) | Returns the component of Type type if the game object has one attached, null if it doesn't. |
| [GetComponentInChildren](https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html) | Returns the component of Type type in the GameObject or any of its children using depth first search. |
| [GetComponentInParent](https://docs.unity3d.com/ScriptReference/Component.GetComponentInParent.html) | Returns the component of Type type in the GameObject or any of its parents. |
| [GetComponents](https://docs.unity3d.com/ScriptReference/Component.GetComponents.html) | Returns all components of Type type in the GameObject.       |

## 定制代码规范

比如jetbrains家的工具，在设置项中有codestyle