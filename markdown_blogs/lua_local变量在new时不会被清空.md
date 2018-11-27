### 前言


我的运行环境 Lua5.3

按照我们以往的Java或C#编程经验，如果一个class被new，那么这个class中所有成员变量的值都是默值或是构造函数中赋的值，但在Lua中的local变量却并不会被清空。



### 示例

这个例子中，我们定义了一个local 的 **instance** 在**ClassA**中，通过new() 两次 ClassA，通过输出观察到构造函数（ctor）调用了两次，但第二次new时，local 变量还是存在上次的值。

```lua
--- Lua中local变量的作用域，并不局限于当前class
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/26
---
---
require("Common/class")
local ClassA = class("ClassA")
local flag = nil
function ClassA:ctor()
    print("ClassA:ctor")
    self:TestLocal()
end

function ClassA:TestLocal()
    if not flag then
        flag = "ClassA"
        print("TestLocal")
    end
end

ClassA.new()
ClassA.new()
```

输出结果：

```lua
lua.exe E:/Code/blog_samplecode/lua_scripts/oop/LocalRefContext.lua
ClassA:ctor
TestLocal
ClassA:ctor
```

