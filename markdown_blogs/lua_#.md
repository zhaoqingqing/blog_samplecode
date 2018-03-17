 

### Lua中的#

对字符串来说，#取字符串的长度，但对于table需要注意。

lua的table可以用数字或字符串等作为key， #号得到的是用整数作为索引的最开始连续部分的大小, 如果t[1] == nil, 即使t[5], t[6], t[7]是存在的，#t仍然为零。对于这类tb[1],tb[2]....才能获取到正确的长度。

如果table的第一个元素key为非数字，那么#tb获取到的长度也是0。

在平时开发过程中如果是table，不建议使用这个API。

### 建议方法

```lua
function table.length(t)
    local i = 0
    for k, v in pairs(t) do
        i = i + 1
    end
    return i
end
```