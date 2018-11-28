--扩展string函数

function string:split(delimiter)
    local result = {}
    for match in (self .. delimiter):gmatch("(.-)" .. delimiter) do
        table.insert(result, match)
    end
    return result
end

function string:contains(substr)
    if string.find(self, substr) then
        return true
    else
        return false
    end
end

function string.replace(self, str, newstr)
    return string.gsub(self, str, newstr, 1)
end

function string.replaceAll(self, str, newstr)
    return string.gsub(self, str, newstr)
end

function string.endsWith(s, last)
    return last == '' or string.sub(s, -string.len(last)) == last
end

function string.startsWith(s, start)
    return string.sub(s, 1, string.len(start)) == start
end

function string.trim (s)
    if not s then return nil end
    return s:match('%s*(.*)%s*')
end

---TrimEnd 去除字符串前后空格
---@param s string
function string.TrimEnd (s)
    if not s then return nil end
    return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end

function string.tobytestring(str)
    local __fmt = "%02x "
    local __format = function(__s)
        return string.format(__fmt, string.byte(__s))
    end
    return string.gsub(str, "(.)", __format)
end


--从配置数据字段中的 "{x,x,x}" 转换成整型列表
function string.strToIntArr(str, delimiter)
    -- assert(str ~= nil, "Str is nil.....")
    if not str then
        warn("The argument str is nil.")
        return {}
    end
    local rStr = {}
    local len = #str
    if string.startsWith(str, "{") or string.startsWith(str, "[") then
        str = string.sub(str, 2, len - 1) --去掉{}
    end
    local del = delimiter or ','
    rStr = str:split(del)
    local result = {}
    --转换成数值类型
    for i = 1, #rStr do
        table.insert(result, tonumber(rStr[i]))
    end
    return result
end

--从配置数据字段中的 "{x,x,x}" 转换成字符串列表
function string.strToStrArr(str, delimiter)
    -- assert(str ~= nil, "Str is nil.....")
    if not str then
        warn("The argument str is nil.")
        return {}
    end
    local rStr = {}
    local len = #str
    if string.startsWith(str, "{") then
        str = string.sub(str, 2, len - 1) --去掉{}
    end
    local del = delimiter or ','
    rStr = str:split(del)
    return rStr
end


--获取UTF8字符串长度
--@param str 目标字符串
--@return cnt 字符长度
function string.utfStrlen(str)
	local len = #str
	local left = len 
	local cnt = 0
	local arr = {0, 0xc0, 0xe0, 0xf0, 0xf8, 0xfc}
	while left ~= 0 do
		local temp = string.byte(str, -left)
		local i = #arr
		while arr[i] do
			if temp >= arr[i] then
				left = left - i
				break
			end
			i = i - 1
		end
		cnt = cnt + 1
	end
	return cnt
end

--判断是否存在非法字符
--@param s 目标字符串
--@return bool
function string.isIllegal(s)
    local ss = ""
    for k = 1, #s do
        local c = string.byte(s, k)
        if not c then
            break
        end
        if (c >= 48 and c <= 57) or (c >= 65 and c <= 90) or (c >= 97 and c <= 122) then
            ss = ss .. string.char(c)
        elseif c >= 228 and c <= 233 then
            local c1 = string.byte(s, k + 1)
            local c2 = string.byte(s, k + 2)
            if c1 and c2 then
                local a1, a2, a3, a4 = 128, 191, 128, 191
                if c == 228 then
                    a1 = 184
                elseif c == 233 then
                    a2, a4 = 190, c1 ~= 190 and 191 or 165
                end
                if c1 >= a1 and c1 <= a2 and c2 >= a3 and c2 <= a4 then
                    k = k + 2
                    ss = ss .. string.char(c, c1, c2)
                end
            end
        end
    end
    if #s ~= #ss then
        --存在不是中文,字母,数字 字符
        return true
    end
    return false
end

---isEmpty
---@param str string
function string.isEmpty(str)
    return not (str and str ~= "" and tostring(str) ~= "0")
end

---IsNullOrEmpty 判断
function string.IsNullOrEmpty(str)
    return not (str and str ~= "" and tostring(str) ~= "")
end

---获取字符串的长度，适用于中文
---@param str string
function string.Length(str)
    if (str and str ~= "") then
        local _, count = string.gsub(str, "[^\128-\193]", "")
        return count
    end
    return -1
end

---截取指定字符串长度，适用于中文
---@param str string
function string.SubString(str, startIdx, length)
    startIdx = not startIdx or startIdx <= 0 and 1 or startIdx

    local strLengh = string.Length(str)
    if (strLengh < startIdx or strLengh < length) then
        return str
    end

    --把字符串转成table
    local tab = {}
    for uchar in string.gmatch(str, "[%z\1-\127\194-\244][\128-\191]*") do
        tab[#tab + 1] = uchar
    end

    local retStr = "";
    for i, v in ipairs(tab) do
        if (i >= startIdx and i <= length) then
            retStr = retStr .. v
        end
    end
    return retStr
end

function string.isZero(str)
    return str == 0 or str == "0"
end

function string.join(tb, split)    
    local str = ""
    for k,v in pairs(tb) do
        str = str..v..split
    end
    return str:SubString(1, str:len()-split:len())
end