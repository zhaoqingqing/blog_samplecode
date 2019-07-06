正常情况下，特效给的动画时间是固定的，但是这个特效是个进度条或者用做倒计时的话，时间是不固定的。

那么同一个特效动画，怎么控制它在指定的时间内播放完呢？

### 控制播放速度

以Unity 2018.3.4为例

在6秒内播放进度条动画，但特效给的动画时长可能是2秒，通过修改speed来达到效果。

```c#
var cdTime = 6.0f;
var animation = gameobject.GetComponent<Animation>();
var animLength = animation.GetClip(animName);
foreach(var state in animation){
    state.speed = animLength/cdTime;
}
```



### Animation倒序播放

如果要让动作倒序播放，则修改time为结束时间，并且修改速度为负数。

```c#
var cdTime = 6.0f;
var animation = gameobject.GetComponent<Animation>();
var animLength = animation.GetClip(animName);
foreach(var state in animation){
	state.time = animLength;
    state.speed = -animLength/cdTime;
}
```



参考：https://www.cnblogs.com/Peng18233754457/p/7447033.html