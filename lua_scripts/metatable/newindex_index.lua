---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/14
---


local tb = {}
--setmetatable(tb, { __newindex = function(table, key, value)
--    --tb[key] = value
--    rawset(table, key, value)
--end })

tb.A = "aaaa"
print(tb.A)

print("\n")


----只能通过setmetatable才生效？？？
tb.__index = function()
    return "not find"
end

--setmetatable(tb, { __index = function()
--    return "not find"
--end })
print(tb.b)