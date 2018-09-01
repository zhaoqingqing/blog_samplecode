### 排序的Key需要是连续的

```lua
local x = {[1]={x=6},
           [2]={x=5},
           [3]={x=7},
           [5]={x=2},
           [6]={x=8},
           [7]={x=5}}
---从小到大排序
table.sort(x,function(a,b)
    return a.x < b.x
end)

for i=1,10 do
    if x[i] ~= nil then 
        print(x[i].x)
    end
end

```

**打印出：**5,6,7,     2,8,5
可以看到后面的数据并没有进行排序，因为key不是连续的，中间存在断层，Lua只会对连续的部分进行排序。



### 非连续Key不能排序

```lua
local x = { [101] = { x = 6 },
                 [2] = { x = 5 },
                 [10] = { x = 7 } }
print("排序前：", table.tostring(x))
---从小到大排序
table.sort(x, function(a, b)
    return a.x < b.x
end)
print("排序后：", table.tostring(x))
```

**打印出：**排序前和排序后数据是一样的，同样验证 **Lua只会对连续的部分进行排序**

```lua
排序前：	{
  101 = {
    x = 6,
  },
  2 = {
    x = 5,
  },
  10 = {
    x = 7,
  },
}
排序后：	{
  101 = {
    x = 6,
  },
  2 = {
    x = 5,
  },
  10 = {
    x = 7,
  },
}

```

