在游戏的代码中，经常能看到这样的一段代码，帧数累加

这个帧数对于实际游戏开发过程中有什么用处呢？


```c#
int frameCount =0;
void FixedUpdate()
{
 	frameCount ++;   
}
```

