---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/28
---

local tb = {}
setmetatable(tb, { __newindex = function(table, key, value)
    rawset(table, key, value)
end })
tb.memberA = "test"
print(tb.memberA)  --打印 test

setmetatable(tb, { __index = function()
    return "not find"
end })

print(tb["abc"])