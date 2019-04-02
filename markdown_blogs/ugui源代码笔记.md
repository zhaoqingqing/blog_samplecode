### 使用源代码进行开发

- 根据自己电脑上的Unity安装目录，找到UGUI存放的地方。进入此目录(我电脑上的目录是D:\Program Files\Unity\Editor\Data\UnityExtensions\Unity\GUISytem)。
- Unity目录下的GUISytem文件夹就是UGUI存放的地方。
- 首先，备份此文件夹。
- 然后，删除此文件夹。（再次进入Unity程序，会发现没有UI选项了）



替换UnityEngine.UI

把源代码编译出来的dll覆盖unity安装路径下\Editor\Data\UnityExtensions\Unity\GUISystem的文件

（PS：建议备份原有文件夹，copy出来一份，目录下面的.xml文件千万别删了）。

### 常见笔记

以Unity 5.3为例

OnPopulateMesh

当绘制三角形时调用

SetVerticesDirty

将UI标识为需要重新绘制

```csharp

```
#### VertexHelper

[UI](https://bitbucket.org/Unity-Technologies/ui/src/8152ebf61733?at=2017.3f2) / [UnityEngine.UI](https://bitbucket.org/Unity-Technologies/ui/src/8152ebf61733/UnityEngine.UI/?at=2017.3f2) / [UI](https://bitbucket.org/Unity-Technologies/ui/src/8152ebf61733/UnityEngine.UI/UI/?at=2017.3f2) / [Core](https://bitbucket.org/Unity-Technologies/ui/src/8152ebf61733/UnityEngine.UI/UI/Core/?at=2017.3f2) / [Utility](https://bitbucket.org/Unity-Technologies/ui/src/8152ebf61733/UnityEngine.UI/UI/Core/Utility/?at=2017.3f2) / VertexHelper.cs



参考文章：[UGUI源码学习之初涉Image（一）](https://blog.csdn.net/a237653639/article/details/50774207)

http://blog.csdn.net/dark00800/article/details/78900763

[如何使用vs2012单步调试uGUI（unity3d 5.3f4）](https://www.cnblogs.com/fangyukuan/p/5131472.html)