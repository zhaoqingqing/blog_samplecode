介绍lua的日期函数常用方法及我的一个踩坑。

### 时间戳转日期

```lua
os.date("%Y%m%d%H",unixtime)
--os.date("%Y%m%d%H",1534435200)  2018081700
```



### 日期转时间戳

```lua
---指定日期的时间戳
os.time({day=17, month=8, year=2018, hour=0, minute=0, second=0})
--1534435200
```



### 当前时间戳

```lua
os.time()
```



### 格式占位符

```lua
--时间格式 yyyyMMddHHmmss
print(os.date("%Y%m%d%H%M%S", os.time()))
```



### 转成年月日接口

```lua
function Tool.FormatUnixTime2Date(unixTime)
    if unixTime and unixTime >= 0 then
        local tb = {}
        tb.year = tonumber(os.date("%Y",unixTime))
        tb.month =tonumber(os.date("%m",unixTime))
        tb.day = tonumber(os.date("%d",unixTime))
        tb.hour = tonumber(os.date("%H",unixTime))
        tb.minute = tonumber(os.date("%M",unixTime))
        tb.second = tonumber(os.date("%S",unixTime))
        return tb
    end
end
```

当然，如果你只需要拿天数进行比较，可以使用`tonumber(os.date("%d",unixTime))`



### 踩坑日志

不建议采用以下方式计算日期

```lua
function Tool.FormatDiffUnixTime2Tb(diffUnixTime)
    if diffUnixTime and diffUnixTime >= 0 then
        local tb = {}
        ---一天的秒数86400
        tb.dd = math.floor(diffUnixTime / 60 / 60 / 24)
        tb.hh = math.floor(diffUnixTime / 3600) % 24
        tb.mm = math.floor(diffUnixTime / 60) % 60
        tb.ss = math.floor(diffUnixTime % 60)
        return tb
    end
end
```

比如这两个零点日期，通过上述接口计算的dd是非常接近的！

| 日期               | unix timestamp | 计算值            |
| ------------------ | -------------- | ----------------- |
| 2018/8/16 23:59:59 | 1534435199     | 17759.66665509259 |
| 2018/8/17 00:00:01 | 1534435201     | 17759.66667824074 |
|                    |                |                   |





### 参考资料

https://www.cnblogs.com/Denny_Yang/p/6197435.html

http://www.cnblogs.com/whiteyun/archive/2009/08/10/1542913.html

http://blog.csdn.net/goodai007/article/details/8077285