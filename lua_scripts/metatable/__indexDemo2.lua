---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/28
---

local tempTable = { memberB = "test" }

tempTable.__index = function()
    return "not find"
end

print(tempTable.memberA) --打印 nil
print(tempTable.memberB) --打印test
