在绝大多数情况下，我们都不会用到rawget和rawset。

本文的运行环境：lua 5.3 for windows

### rawset 赋值操作

rawset是在设置值的过程，进行处理，比如：当某个值改变时，触发事件。或修改某个key为新值。

来看看rawset函数的定义

```lua
--- Sets the real value of `table[index]` to `value`, without invoking the
--- `__newindex` metamethod. `table` must be a table, `index` any value
--- different from **nil** and NaN, and `value` any Lua value.
---@param table table
---@param index any
---@param value any
function rawset(table, index, value) end
```

看个例子，设置过__newindex之后，就不会调用__index了？

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
print(tb.version) --打印 补丁值
print(tb.server) --打印nil，不会调用__index方法了？
print(tb.date)  --打印2018
```

经过我的测试后， 发现

```lua
---如果把__index放在__newindex之后，调用不存在值，才会调用__index方法
如果在__index在__newindex之前，则不会调用
```

### rawget 取原始值

rawget是为了绕过__index而出现的，直接点，就是让__index方法的重写无效

来看看rawget函数的定义

```lua
--- Gets the real value of `table[index]`, the `__index` metamethod. `table`
--- must be a table; `index` may be any value.
---@param table table
---@param index any
---@return any
function rawget(table, index) end
```

编写一个例子，测试rawget绕过__index方法

```lua
local tb = {}
setmetatable(tb, { __index = function()
    return "not find"
end })

tb.version = "正常版本"
print(tb.version)
print(tb.server) ---不存在的值，调用__index方法
--rawget是为了绕过__index而出现的，直接点，就是让__index方法的重写无效
print(rawget(tb, "version")) --打印 正常版本
print(rawget(tb, "server")) --打印nil
```



### __newindex

__newindex可以和rawset配合使用，也可以单独使用

当为表分配值时，解释器会查找__newindex方法，如果存在，则解释器会调用它。

结合使用 __index和 __newindex，允许lua有强大的构造，从只读表，到具有默认值的表，到面向对象编程的继承

文档：https://www.lua.org/pil/13.4.2.html


### Lua5.3 __index要通过setmetatable设置

在lua5.3中，直接使用tableA.__index = function() end 设置，我这边测试，并不会生效

```lua
local tempTable = { memberB = "test" }

tempTable.__index = function()
    return "not find"
end

print(tempTable.memberA) --打印 nil
print(tempTable.memberB) --打印test
```

而通过这种方式就正常

```lua
local tempTable = { memberB = "test" }
---__index定义了当key查找不到的行为
setmetatable(tempTable, { __index = function()
    return "not find"
end })

print(tempTable.memberA) --打印 not find
print(tempTable.memberB) --打印test
```

