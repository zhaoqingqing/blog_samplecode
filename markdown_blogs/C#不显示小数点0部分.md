c#去掉小数点后的无效0 ，保留指定位数的小数，比如10.0显示成10，小数部分会四舍五入


```c#
float value = 0.0500f;
value.ToString("0.##");//保留两位小数输出0.05
var percent = ((float) 100/(float)100).ToString("0.#");//保留一位小数输出1

Console.WriteLine(1.211f.ToString("0.#"));//输出1.2
Console.WriteLine(1.2611f.ToString("0.#"));//输出1.3
```

也可以这样写： `string.Format("{0:0.##}",value)`

0.# 表示最多保留1位有效数字，但是不包括0

0.## 表示最多保留2位有效数字，但是不包括0

**我的测试环境**

.net 3.5 

此方法在Unity中也适用，引擎版本Unity3D 2018.4.15f1