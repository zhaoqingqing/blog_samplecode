--- __indext重新定义行为
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---


local tempTable = {}
tempTable.memberB = "test"
print(tempTable.memberA)
print(tempTable.memberB)

--[[
nil
test
]]
print("\r")
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
