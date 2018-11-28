--- Lua中local变量的作用域，并不局限于当前class
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/26
---
---
require("Common/class")
local ClassA = class("EquipCombineModel")
local flag = nil
function ClassA:ctor()
    print("ClassA:ctor")
    self:TestLocal()
end

function ClassA:TestLocal()
    if not flag then
        flag = "ClassA"
        print("TestLocal")
    end
end

ClassA.new()
ClassA.new()