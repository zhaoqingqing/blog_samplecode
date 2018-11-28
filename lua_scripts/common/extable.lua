--扩展table函数

function table.clone(t, nometa)
    local u = {}

    if not nometa then
        setmetatable(u, getmetatable(t))
    end

    for i, v in pairs(t) do
        if type(v) == "table" then
            u[i] = table.clone(v)
        else
            u[i] = v
        end
    end

    return u
end

function table.simpleclone(object)
    local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local newObject = {}
        lookup_table[object] = newObject
        for key, value in pairs(object) do
            newObject[_copy(key)] = _copy(value)
        end
        return setmetatable(newObject, getmetatable(object))
    end
    return _copy(object)
end


function table.merge(t, u)
    local r = table.clone(t)

    for i, v in pairs(u) do
        r[i] = v
    end

    return r
end

function table.keys(t)
    local keys = {}
    for k, v in pairs(t) do
        table.insert(keys, k)
    end
    return keys
end

function table.unique(t)
    local seen = {}
    for i, v in ipairs(t) do
        if not table.includes(seen, v) then
            table.insert(seen, v)
        end
    end

    return seen
end

function table.values(t)
    local values = {}
    for k, v in pairs(t) do
        table.insert(values, v)
    end
    return values
end

function table.last(t)
    return t[#t]
end

function table.append(t, moreValues)
    for i, v in ipairs(moreValues) do
        table.insert(t, v)
    end

    return t
end

function table.indexOf(t, value)
    for k, v in pairs(t) do
        if type(value) == "function" then
            if value(v) then
                return k
            end
        else
            if v == value then
                return k
            end
        end
    end

    return nil
end

function table.keyOf (t, value)
    for k, v in pairs(t) do
        if v == value then
            return k
        end
    end
end

function table.assign (t, key)
    local v = t[key]
    if not v then
        v = {}
        t[key] = v
    end
    return v
end

function table.includes(t, value)
    return table.keyOf(t, value)
end

function table.removeValue(t, value)
    local index = table.keyOf(t, value)
    if index then
        t[index] = nil
    end
    return t
end

function table.length(t)
    local i = 0
    for k, v in pairs(t) do
        i = i + 1
    end
    return i
end

function table.each(t, func)
    for k, v in pairs(t) do
        func(v, k)
    end
end

local function __soctKeys(t)
    local keys = table.keys(t)
    table.sort(keys)
    return keys
end

local function orderedNext(t, state)
    local key = nil
    if state == nil then
        t.__orderedIndex = __soctKeys(t)
        key = t.__orderedIndex[1]
    else
        for i, v in ipairs(t.__orderedIndex) do
            if t.__orderedIndex[i] == state then
                key = t.__orderedIndex[i + 1]
            end
        end
    end

    if key then
        return key, t[key]
    end

    t.__orderedIndex = nil
    return

end

--类似于pairs()，不同的是spais会对键进行有序遍历，类似于下面的table.sortedEach
function spairs(t)
    return orderedNext, t, nil
end

function table.sortedEach(t, func)
    local keys = table.keys(t)
    table.sort(keys)
    for i, v in ipairs(keys) do
        if t[v] then
            func(t[v])
            -- else
            -- log("warning: "..v.."not exists")
        end
    end
end

function table.find(t, func)
    for k, v in pairs(t) do
        if func(v) then
            return v, k
        end
    end

    return nil
end

function table.filter(t, func)
    local matches = {}
    for k, v in pairs(t) do
        if func(v) then
            table.insert(matches, v)
        end
    end

    return matches
end

function table.map(t, func)
    local mapped = {}
    for k, v in pairs(t) do
        table.insert(mapped, func(v, k))
    end

    return mapped
end

function table.groupBy(t, func)
    local grouped = {}
    for k, v in pairs(t) do
        local groupKey = func(v)
        if not grouped[groupKey] then
            grouped[groupKey] = {}
        end
        table.insert(grouped[groupKey], v)
    end

    return grouped
end

--- tostring的简化,只保留实际值
---@param tbl table
function table.tostringsimple(tbl, indent, limit, depth, jstack, newline)
    limit = limit or 1000
    depth = depth or 7
    jstack = jstack or {}
    newline = newline or "\n"
    local i = 0

    local output = {}
    if type(tbl) == "table" then
        -- very important to avoid disgracing ourselves with circular referencs...
        for i, t in ipairs(jstack) do
            if tbl == t then
                return "<self>,"..newline
            end
        end
        table.insert(jstack, tbl)

        table.insert(output, "{"..newline)
        for key, value in pairs(tbl) do
            if key ~= "class" then
                local innerIndent = (indent or " ") .. (indent or " ")
                if type(key) == "number" then
                    table.insert(output, innerIndent .. "[" .. key .. "]" .. " = ")
                else
                    table.insert(output, innerIndent .. tostring(key) .. " = ")
                end
                table.insert(output,
                value == tbl and "<self>," or table.tostringsimple(value, innerIndent, limit, depth, jstack, newline)
                )

                i = i + 1
                if i > limit then
                    table.insert(output, (innerIndent or "") .. "..."..newline)
                    break
                end
            end
        end

        table.insert(output, indent and (indent or "") .. "},"..newline or "}")
    else
        if type(tbl) == "string" then
            tbl = string.format("%q", tbl)
        end -- quote strings
        table.insert(output, tostring(tbl) .. ","..newline)
    end

    return table.concat(output)
end

function table.tosimple(tbl)
    return load("return " .. table.tostringsimple(tbl))()
end

function table.tostringEZ(tbl)
    table.tostring(tbl, nil, nil, nil, nil)
end

function table.tostring(tbl, indent, limit, depth, jstack)
    limit = limit or 1000
    depth = depth or 7
    jstack = jstack or {}
    local i = 0

    local output = {}
    if type(tbl) == "table" then
        -- very important to avoid disgracing ourselves with circular referencs...
        for i, t in ipairs(jstack) do
            if tbl == t then
                return "<self>,\n"
            end
        end
        table.insert(jstack, tbl)

        table.insert(output, "{{\n")
        for key, value in pairs(tbl) do
            local innerIndent = (indent or " ") .. (indent or " ")
            table.insert(output, innerIndent .. tostring(key) .. " = ")
            table.insert(output,
            value == tbl and "<self>," or table.tostring(value, innerIndent, limit, depth, jstack)
            )

            i = i + 1
            if i > limit then
                table.insert(output, (innerIndent or "") .. "...\n")
                break
            end
        end

        table.insert(output, indent and (indent or "") .. "}},\n" or "}}")
    else
        if type(tbl) == "string" then
            tbl = string.format("%q", tbl)
        end -- quote strings
        table.insert(output, tostring(tbl) .. ",\n")
    end

    return table.concat(output)
end

function table.simpledump(proto, space)
    local s = "{{"
    if not space then
        space = "\t"
    end
    for k, v in pairs(proto) do
        if k ~= "class" and type(v) ~= "userdata" then
            if type(v) == "table" then
                s = s .. "\n" .. space .. k .. ": \t" .. table.simpledump(v, space .. "\t")
            else
                s = s .. "\n" .. space .. k .. ": " .. v
            end
        end
    end
    s = s .. "\n" .. string.gsub(space, "\t", "", 1) .. "}}"
    return s
end

function table.print(table)
    print(tostring(table))
end


---
---@param tb table
function table.table2JsonString(tb)
    if (not tb or type(tb) ~= "table" ) then
        warn("to json string fail,not table or nil")
        return "{}"
    end
    local newTb = table.tosimple(tb)
    return json.encode(newTb)
end

---
---@param jsonStr string
---@return table
function table.jsonStr2Table(jsonStr)
    if (not jsonStr or string.isEmpty(jsonStr)) then
        return nil
    end
    return json.decode(jsonStr)
end