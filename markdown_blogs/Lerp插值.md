### 在X秒内插值

```c#
//开始时间
float time_start ;
//持续时间
var duration = 3.0f;
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
        var value = Mathf.Lerp(0,1,rate);
        if(value>=1){
            end = true
            Debug.Log("走完了")
        }
    }
}
```

