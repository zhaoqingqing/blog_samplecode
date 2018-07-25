### lua table排序

table的sort函数

比如按照大小进行排序，下面这种写法在某些情况下可能会排序错误，甚至报`invalid order function for sorting`

```lua
table.sort(srcTable,function(vo1,vo2) 
    return vo1 >= vo2
end)
```
**这是为什么呢?**

因为sort函数里面要写清楚所有的情况，比如上面的，如果`vo1 == vo2 return true`则和默认值重复会报错，这里需要对于值相等的使用其它条件或者return false，才能得到正确的结果。

如果可能出现的情况会比较多，这时候使用sort，可能要写的很复杂，且排序不稳定。

**sort函数的返回值**

```lua
function(vo1,vo2) 
    return vo1 > vo2
end
```

return true 是要让vo1排在前

return false 要让vo2排在前

### 自己写排序

如果排序中的条件唯一，但可能出现的情况有很多，例下这个例子，把绑定的排序在前面，非绑定在后面。

可以把满足条件A的元素放在tba，不满足的元素放tbb，再这两个table插入到一个新的table中。

示例：

```lua
local binds = {}
local others = {}
for i, v in pairs(stuffList) do
	if v.isbind == true then
		table.insert(binds, v)
	else
		table.insert(others, v)
	end
end
local sorted = {}
for i, v in ipairs(binds) do
	table.insert(sorted, v)
end
for i, v in ipairs(others) do
	table.insert(sorted, v)
end
```

最后得到的sorted就是经过排序后的列表。

