##lua string常用函数

string库中所有的function都不会直接操作原字符串，而是复制一份再进行操作  

```lua

  
s = "[Abc]"  
print(string.len(s))          --5  
print(string.rep(s, 2))       --[Abc][Abc]  
print(string.lower(s))        --[abc]  
print(string.upper(s))        --[ABC]  
  
  
--string.sub 截取字符串   
--字符索引从前往后是1,2,...;从后往前是-1,-2,...  
print(string.sub(s, 2))       --Abc]  
print(string.sub(s, -2))      --c]  
print(string.sub(s, 2, -2))   --Abc  
```