---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---
---定义
local tb = {}
local m = setmetatable({}, { __newindex = function(table, key, value)
    tb[key] = value
end })
m["memberA"] = 456
print(m["memberA"]) -- 打印 nil
print(tb["memberA"]) --打印 456

print("\n")
m.a = "test"
m.__index = function() return "not find" end
print(tb["abc"])


print("\n")
local other = {}
local  t = setmetatable({}, { __newindex = other })
t.foo = 3
print(other.foo) -- 3
print(t.foo) -- nil


