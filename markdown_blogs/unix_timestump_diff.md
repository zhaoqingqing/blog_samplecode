两个时间戳相减，得到两个日期之间的差值

把这个差值，格式化显示成：天数:小时数:分钟数:秒数



前缀处理，小于10前面加0

```lua
function Tool.PrefixTime(time, max)
    max = not max and 10 or max
    if time < max then
        time = "0" .. time
    end
    return time
end
```



时间戳差值转成table

这里时间戳的单位是秒，如果是毫秒的话，计算day时，要把秒转成毫秒(除以1000)

```lua
---FormatUnixTime2Tb 把unix时间戳转成tb值
---@param unixTime
function Tool.FormatUnixTime2Tb(unixTime)
    if unixTime >= 0 then
        local tb = {}
        ---一天的秒数86400
        tb.dd = math.floor(unixTime /60/60/24)
        tb.hh = math.floor(unixTime / 3600)%24
        tb.mm = math.floor(unixTime / 60) % 60
        tb.ss = math.floor(unixTime % 60)
        return tb
    end
end
```



格式化成指定的字符串

```lua
---GetDateFormat 格式化unix时间戳成天:时:分:秒
---@param unixTime
function Tool.GetDateFormat(unixTime)
    local result = ""
    local tb = Tool.FormatUnixTime2Tb(unixTime)
    if tb then
        if (tb.dd > 0) then
            result = string.format("%s天%s时%s分%s秒", Tool.PrefixTime(tb.dd), Tool.PrefixTime(tb.hh), Tool.PrefixTime(tb.mm), Tool.PrefixTime(tb.ss))
        else
            result = string.format("%s时%s分%s秒", Tool.PrefixTime(tb.hh), Tool.PrefixTime(tb.mm), Tool.PrefixTime(tb.ss))
        end
    end
    return result
end
```



