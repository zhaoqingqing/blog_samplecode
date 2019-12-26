统一的日志开关和日志调用条件，对于某些并不重要的信息，加上Editor的判断减少字符串拼接，比如

```
if(Applica.isEditor) Debug.Log($"id:{id}，名字:{name}")
```

预加载分两步：预加载和创建出gameobject

预加载，在玩家任务寻路过程中就进行预加载关卡资源

在创角动画的播放过程中，预加载新手村场景

相机Camera初始化的消耗很大

频繁出现的UI不做setactive=false/true，而是移到hidden层，让相机不渲染。

