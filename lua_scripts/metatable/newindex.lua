---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---
---定义
local tb = {}
local m = setmetatable({}, { __newindex = function(table, key, value)
    tb[key] = value
end })
m[123] = 456
print(m[123]) ---nil
print(tb[123]) ---456
print("\n")
m.a = "test"
m.__index = function() return "not find" end
print(tb["abc"])


print("\n")
other = {}
t = setmetatable({}, { __newindex = other })
t.foo = 3
print(other.foo) -- 3
print(t.foo) -- nil


