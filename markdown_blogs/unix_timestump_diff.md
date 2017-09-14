```lua
function Tool.PrefixTime(time, max)
    max = not max and 10 or max
    if time < max then
        time = "0" .. time
    end
    return time
end

---GetDateFormat 格式化显示两个unix时间戳之间的时间差值
---@param unixTime
---@param showDay boolean 是否包含天数
function Tool.GetDateFormat(unixTime, showDay)
    local result = ""
    if unixTime >= 0 then
        local dd = math.floor(unixTime / 8640000)
        local hh = math.floor(unixTime / 3600)
        local mm = math.floor(unixTime / 60) % 60
        local ss = math.floor(unixTime % 60)
        if (showDay) then
            result = string.format("%s天%s时%s分%s秒", Tool.PrefixTime(dd), Tool.PrefixTime(hh), Tool.PrefixTime(mm), Tool.PrefixTime(ss))
        else
            result = string.format("%s时%s分%s秒", Tool.PrefixTime(hh), Tool.PrefixTime(mm), Tool.PrefixTime(ss))
        end
    end
    return result
end
```

