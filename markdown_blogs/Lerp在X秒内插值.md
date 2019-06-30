### 在X秒内插值

我们知道Mathf.Lerp函数的是用在两个值之间进行插值，用于平滑过渡。

`var 插值结果 = Mathf.Lerp(from,to,rate)  //rate是0~1的值`

Unity没有提供一个直接的接口，用于在X秒内进行插值，那么如何实现在X秒内进行插值呢？

示例代码：

```c#
//总时间
var duration = 3.0f;
//开始时间
float time_start ;
bool end = false;
bool start = false;

//每帧调用
void OnGUI(){
    if(GUI.Button(new　Rect(100,10,100,40))){
        end = false;
        start = true;
        time_start= Time.time;
    }
    if(start&&!end){
        var rate = Mathf.Clamp01((Time.time-time_start)/duration)
        //在3秒内从0~1
        var value = Mathf.Lerp(0,1,rate);
        if(value>=1){
            end = true
            Debug.Log("走完了")
        }
    }
}
```