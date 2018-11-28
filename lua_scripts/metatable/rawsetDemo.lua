---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/14
---

local tb = {}

setmetatable(tb, { __newindex = function(table, key, value)
    local patchKey = "version"
    if key == patchKey then
        rawset(table, patchKey, "补丁值")
    else
        rawset(table, key, value)
    end
end })
---需要把__index放在__newindex之后，调用不存在值，才会调用此方法，如果在__newindex之前，则不会调用
setmetatable(tb, { __index = function()
    return "not find"
end })
tb.version = "正常版本"
tb.date = "2018"
print(tb.version) --打印 补丁值
print(tb.server) --打印nil，不会调用__index方法了？
print(tb.date)  --打印2018
