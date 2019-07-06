### 遇到问题

特效同事给的Animation更改了物体的很多属性，如Active，Alpha， Scale，Position等等，物体本身需要重复利用，因此使用对象池技术不直接销毁而是隐藏等需要时再显示，但是在隐藏后发现再次显示的时候有些属性不会自动复原。

### 解决办法

1. 在Animator Controller中添加一个空的 Animator State 为**New State**，并赋值动作相同的 animation clip 
2. 设置 **New State** 的 Speed 为 0 ，让动画不会播放且停在第1帧
3. 设置  **New State** 为 Default State (默认播放)



### 重复播放

```csharp
m_animator.Play("attack_1",0,0f);
```

### 状态重置

当动画播放完成后，重置状态

```csharp
// 重置Animator
public void ResetAnimator(){
	m_animator.Play ("New State");
}
```

如上所说在用对象池销毁之前（即acitve设为false之前）把动画状态机（Animator）设置为播放第一个动画（Animation），然后刷新状态（调用ResetAnimator()）即可。



### 其它信息

部分参考：https://blog.csdn.net/u013236878/article/details/52813994，但作者提到的方法我测试不可行。

```c#
m_animator.Play ("New State");
m_animator.Update (0);
```

我的Unity版本： Unity5.3.7