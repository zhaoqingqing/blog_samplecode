--- __indext重新定义行为
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---


local tempTable = { memberB = "test" }
---__index定义了当key查找不到的行为
setmetatable(tempTable, { __index = function()
    return "not find"
end })

print(tempTable.memberA) --打印 not find
print(tempTable.memberB) --打印test