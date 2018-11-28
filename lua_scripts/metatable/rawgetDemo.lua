---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/28
---
--- Gets the real value of `table[index]`, the `__index` metamethod. `table`
--- must be a table; `index` may be any value.
---@param table table
---@param index any
---@return any
--function rawget(table, index) end

local tb = {}
setmetatable(tb, { __index = function()
    return "not find"
end })

tb.version = "正常版本"
print(tb.version)
print(tb.server) ---不存在的值，调用__index方法
--rawget是为了绕过__index而出现的，直接点，就是让__index方法的重写无效
print(rawget(tb, "version")) --打印 正常版本
print(rawget(tb, "server")) --打印nil