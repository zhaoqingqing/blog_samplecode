--- __index需要放在__newindex之后
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/14
---


local tb = {}
setmetatable(tb, { __newindex = function(table, key, value)
    rawset(table, key, value)
end })

tb.A = "aaaa"
print(tb.A) --打印 aaaa

setmetatable(tb, { __index = function()
    return "not find"
end })
print(tb.b) --打印 not find