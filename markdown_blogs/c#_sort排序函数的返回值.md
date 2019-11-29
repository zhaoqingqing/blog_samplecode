C# List.Sort函数的返回值

| 值     | 含义              |
| ------ | ----------------- |
| 小于零 | left在right的前面 |
| 零     | 位置不变          |
| 大于零 | right在left的前面 |

示例：

本测试结果在unity3d 和纯C#环境下执行。

```C#
List<int> list = new List<int>();
list.Add(1);
list.Add(4);
list.Sort((left,right)=>{
     return 1;
});

//排序后是：4，1
```

```c#
list.Sort((left,right)=>{
     return -1;
});
//排序后是：1，4
```



从小到大排序的返回值写法

````c#
list.Sort((left,right)=>{
     return left-right;
});
````

从大到小排序的返回值写法

````c#
list.Sort((left,right)=>{
     return right-left;
});
````





注意：C# sort的返回值和Lua语言中table.sort返回值是不一样的。

