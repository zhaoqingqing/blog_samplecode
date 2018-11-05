--- 当把A的metatable设置为B时，在A中访问B的元素，会返回nil，因为仅仅是设置了metatable，而B的__index没有赋值
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/5
---

local father = {
    house = 1
}
---如果不把__index指向自己，则会输出nil
--father.__index = father
---测试返回一个函数，当成员查找失败时，查__index
father.__index = function()
    return "i am function"
end

local son = {
    car = 1
}
setmetatable(son,father)
print(son.house)
