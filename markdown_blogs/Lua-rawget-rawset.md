在绝大多数情况下，我们都不会用到rawget和rawset。



### rawset 赋值操作

```lua
local tb = {}
setmetatable(tb, { __index = function()
    return "not find"
end })
setmetatable(tb, { __newindex = function(table, key, value)
    local patchKey = "version"
    if key == patchKey then
        rawset(table, patchKey, "补丁值")
    else
        rawset(table, key, value)
    end
end })
tb.version = "正常版本"
tb.date = "2018"
print(tb.version)  ---补丁值
print(tb.server) ---nil，不会调用__index方法了？
print(tb.date) ---2018
print("\r")
--rawget是为了绕过__index而出现的，会让__index方法的重写无效
print(rawget(tb, tb.version)) --打印nil
```



### __newindex

```
function
```



### Lua5.3 __index通过setmetatable设置

在lua5.3中，直接使用tableA.__index = function() end 设置，我这边测试，并不会生效__

而通过这种方式就正常

```lua
local tb = {}
tb.__index = function()
    return "not find"
end
```

