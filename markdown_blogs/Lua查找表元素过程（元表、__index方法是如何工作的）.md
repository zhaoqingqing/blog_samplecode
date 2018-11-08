### Lua表类似HashMap

Lua的表本质其实是个类似HashMap的东西，其元素是很多的Key-Value对，如果尝试访问了一个表中并不存在的元素时，就会触发Lua的一套查找机制，也是凭借这个机制来模拟了类似“继承”的行为

举例说明：

```lua
local tempTable = {}
tempTable.memberB = "test"
print(tempTable.memberA) --这里试图打印tempTable并不存在的成员memberA
print(tempTable.memberB) 

--[[
nil
test
]]
```


输出为nil的原因很简单，tempTable中并没有memberA这个成员，这符合我们平时对HashMap的认知。但对于Lua表，如果tempTable有元表，情况就不同了。



### 什么是元表：

元表像是一个“操作指南”，里面包含了一系列操作的解决方案，例如__index方法就是定义了这个表在索引失败的情况下该怎么办。

```lua
local tempTable = {}
tempTable.memberB = "test"
---__index定义了当key查找不到的行为
setmetatable(tempTable, { __index = function()
    return "not find"
end })

print(tempTable.memberA)
print(tempTable.memberB)
--[[
not find
test
]]

```



### __index元方法：

很多人对此都有误解，这个误解是：如果A的元表是B，那么如果访问了一个A中不存在的成员，就会访问查找B中有没有这个成员。而这个理解是完全错误的，实际上，即使将A的元表设置为B，而且B中也确实有这个成员，返回结果仍然会是nil，原因就是B的__index元方法没有赋值。别忘了我们之前说过的：“元表是一个操作指南”，定义了元表，只是有了操作指南，但不应该在操作指南里面去查找元素，而__index方法则是“操作指南”的“索引失败时该怎么办”。这么说有点绕。所以：

举个栗子：）

```lua
father = {
	house=1
}
son = {
	car=1
}
setmetatable(son, father) --把son的metatable设置为father
print(son.house)
```

输出的结果是nil。

但如果把代码改为

```lua
father = {
	house=1
}
father.__index = father -- 把father的index方法指向自己
son = {
	car=1
}
setmetatable(son, father)
print(son.house)
```

输出的结果为1，符合预期

### __index元方法的含义


这样一来，结合上例，来解释__index元方法的含义：

在上述例子中，访问son.house时，son中没有house这个成员，但Lua接着发现son有元表father，

注意：此时，Lua并不是直接在father中找名为house的成员，而是调用father的__index方法，如果__index方法为nil，则返回nil，如果是一个表（上例中father的__index方法等于自己，就是这种情况），那么就到__index方法所指的这个表中查找名为house的成员，于是，最终找到了house成员。

注：__index方法除了可以是一个表，还可以是一个函数，如果是一个函数，__index方法被调用时将返回该函数的返回值。

```lua
father.__index = function()
    return "i am function"
end
```



### Lua查找一个表元素的3个步骤


到这里，总结一下Lua查找一个表元素时的规则，其实就是如下3个步骤:


1.在表中查找，如果找到，返回该元素，找不到则继续

2.判断该表是否有元表（操作指南），如果没有元表，返回nil，有元表则继续

3.判断元表（操作指南）中有没有关于索引失败的指南（即__index方法），如果没有（即__index方法为nil），则返回nil；如果__index方法是一个表，则重复1、2、3；如果__index方法是一个函数，则返回该函数的返回值



本文示例代码：https://github.com/zhaoqingqing/blog_samplecode/tree/master/lua_scripts/metatable

转载自：寰子 https://blog.csdn.net/xocoder/article/details/9028347 