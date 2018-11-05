---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---
other = {}
t = setmetatable({}, { __newindex = other })
t.foo = 3
print(other.foo) -- 3
print(t.foo) -- nil