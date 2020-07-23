---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2020/7/23
--- lua中使用json库 (需要导入第三方库，或者安装lua for windows)
json = require('json')

---@param tb table
function table.table2JsonString(tb)
    if (not tb or type(tb) ~= "table" ) then
        warn("to json string fail,not table or nil")
        return "{}"
    end
    --local newTb = table.tosimple(tb)
    return json.encode(tb)
end

---
---@param jsonStr string
---@return table
function table.jsonStr2Table(jsonStr)
    if (not jsonStr or jsonStr == "") then
        return nil
    end
    return json.decode(jsonStr)
end

--table转成json
local lua_table = {
    a = "hello",
    b = "world",
    c = 123456,
    d = "123456",}
local json_str = table.table2JsonString(lua_table)
print(json_str)
print(lua_table["a"])
print(lua_table["b"])

----json转成table
local json_object = "{\"name\":\"lua\",\"other\":\"csharp,\",\"num\":100}"
local tb = table.jsonStr2Table(json_object)
print(tb["name"])

