--[[--
创建一个类
~~~ lua
-- 定义名为 Shape 的基础类
local Shape = class("Shape")
-- ctor() 是类的构造函数，在调用 Shape.new() 创建 Shape 对象实例时会自动执行
function Shape:ctor(shapeName)
    self.shapeName = shapeName
    printf("Shape:ctor(%s)", self.shapeName)
end
-- 为 Shape 定义个名为 draw() 的方法
function Shape:draw()
    printf("draw %s", self.shapeName)
end
--
-- Circle 是 Shape 的继承类
local Circle = class("Circle", Shape)
function Circle:ctor()
    -- 如果继承类覆盖了 ctor() 构造函数，那么必须手动调用父类构造函数
    -- 类名.super 可以访问指定类的父类
    Circle.super.ctor(self, "circle")
    self.radius = 100
end
function Circle:setRadius(radius)
    self.radius = radius
end
-- 覆盖父类的同名方法
function Circle:draw()
    printf("draw %s, raidus = %0.2f", self.shapeName, self.raidus)
end
--
local Rectangle = class("Rectangle", Shape)
function Rectangle:ctor()
    Rectangle.super.ctor(self, "rectangle")
end
--
local circle = Circle.new()             -- 输出: Shape:ctor(circle)
circle:setRaidus(200)
circle:draw()                           -- 输出: draw circle, radius = 200.00
local rectangle = Rectangle.new()       -- 输出: Shape:ctor(rectangle)
rectangle:draw()                        -- 输出: draw rectangle
~~~
### 高级用法
class() 除了定义纯 Lua 类之外，还可以从 C++ 对象继承类。
比如需要创建一个工具栏，并在添加按钮时自动排列已有的按钮，那么我们可以使用如下的代码：
~~~ lua
-- 从 cc.Node 对象派生 Toolbar 类，该类具有 cc.Node 的所有属性和行为
local Toolbar = class("Toolbar", function()
    return display.newNode() -- 返回一个 cc.Node 对象
end)
-- 构造函数
function Toolbar:ctor()
    self.buttons = {} -- 用一个 table 来记录所有的按钮
end
-- 添加一个按钮，并且自动设置按钮位置
function Toolbar:addButton(button)
    -- 将按钮对象加入 table
    self.buttons[#self.buttons + 1] = button
    -- 添加按钮对象到 cc.Node 中，以便显示该按钮
    -- 因为 Toolbar 是从 cc.Node 继承的，所以可以使用 addChild() 方法
    self:addChild(button)
    -- 按照按钮数量，调整所有按钮的位置
    local x = 0
    for _, button in ipairs(self.buttons) do
        button:setPosition(x, 0)
        -- 依次排列按钮，每个按钮之间间隔 10 点
        x = x + button:getContentSize().width + 10
    end
end
~~~
class() 的这种用法让我们可以在 C++ 对象基础上任意扩展行为。
既然是继承，自然就可以覆盖 C++ 对象的方法：
~~~ lua
function Toolbar:setPosition(x, y)
    -- 由于在 Toolbar 继承类中覆盖了 cc.Node 对象的 setPosition() 方法
    -- 所以我们要用以下形式才能调用到 cc.Node 原本的 setPosition() 方法
    getmetatable(self).setPosition(self, x, y)
    printf("x = %0.2f, y = %0.2f", x, y)
end
~~~
**注意:** Lua 继承类覆盖的方法并不能从 C++ 调用到。也就是说通过 C++ 代码调用这个 cc.Node 对象的 setPosition() 方法时，并不会执行我们在 Lua 中定义的 Toolbar:setPosition() 方法。
@param string classname 类名
@param [mixed super] 父类或者创建对象实例的函数
@return table
]]
function class(classname, super)
    local superType = type(super)
    local cls

    if superType ~= "function" and superType ~= "table" then
        superType = nil
        super = nil
    end

    if superType == "function" or (super and super.__ctype == 1) then
        -- inherited from native C++ Object
        cls = {}

        if superType == "table" then
            -- copy fields from super
            for k,v in pairs(super) do cls[k] = v end
            cls.__create = super.__create
            cls.super    = super
        else
            cls.__create = super
            cls.ctor = function() end
        end

        cls.__cname = classname
        cls.__ctype = 1

        function cls.new(...)
            local instance = cls.__create(...)
            -- copy fields from class to native object
            for k,v in pairs(cls) do instance[k] = v end
            instance.class = cls
            instance:ctor(...)
            return instance
        end

        function cls.create(...)
            return cls.new(...)
        end
    else
        -- inherited from Lua Object
        if super then
            cls = {}
            setmetatable(cls, {__index = super})
            cls.super = super
        else
            cls = {ctor = function() end}
        end

        cls.__cname = classname
        cls.__ctype = 2 -- lua
        cls.__index = cls

        function cls.new(...)
            local instance = setmetatable({}, cls)
            instance.class = cls
            instance:ctor(...)
            return instance
        end

        function cls.create(...)
            return cls.new(...)
        end
    end

    return cls
end