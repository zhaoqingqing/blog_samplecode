--- 以KeyValue形式定义table
--- Created by zhaoq.
--- DateTime: 2017/10/17 21:29
---


-- 定义一个key,value形式的table
local kv = {fruit = "apple",
    bread = "french",
    drink = "milk"}
--通过key从table中取值
print(kv["fruit"])
-- 也可以这样取值
print(kv.bread)

for index, value in pairs(kv) do
    print("index:", index, "value:", value)
end

---输出结果如下：
--apple
--french
--index:	fruit	value:	apple
--index:	drink	value:	milk
--index:	bread	value:	french

local tb = { [3] = "lang", [4] = "zhi", [5] = "cheng", [7] = "jing", [8] = "hong" }
print(tb[2],tb[8])

----输出结果如下：
--nil	hong