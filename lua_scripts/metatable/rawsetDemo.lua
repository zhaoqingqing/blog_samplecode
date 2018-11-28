---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/14
---

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
print(tb.version)
print(tb.server) ---不会调用__index方法了？
print(tb.date)
print("\r")
--rawget是为了绕过__index而出现的，直接点，就是让__index方法的重写无效
print(rawget(tb, tb.version)) --打印nil