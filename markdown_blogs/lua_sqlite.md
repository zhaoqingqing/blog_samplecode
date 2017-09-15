 

## 在Lua中使用sqlite For Unity3D

Lua版本Sqlite文档：[http://lua.sqlite.org/index.cgi/doc/tip/doc/lsqlite3.wiki](http://lua.sqlite.org/index.cgi/doc/tip/doc/lsqlite3.wiki)



### 运行环境

无需导入额外的库，只需要使用 `require("lsqlite")`即可。

我的运行环境如下

XLua/ULua

Unity 5.3.7



### 示例

更多例子：https://docs.coronalabs.com/api/library/sqlite3/index.html

```lua
--a simple libsqlite3 binding for lua5.0-5.2 that provides 3 functions only and is still fully functional: local db = lsqlite.open(database) results, err = db:exec(statments) db:close()

require("lsqlite")

-- open an in memory database
-- db = lsqlite.open(":memory:")

-- open a file
 

-- open an inaccessible file
-- db = lsqlite.open("/root/test.db")

-- check if we got an handle
if not db then print("could not open the database") return end

db:exec("drop table 'my_table';")
db:exec("create table 'my_table' ( 'a', 'b' );")
db:exec("insert into 'my_table' values ( 1, 2 );")
db:exec("insert into 'my_table' values ( 3, 4 );")
db:exec("insert into 'my_table' values ( 5, 6 );")
db:exec("insert into 'my_table' values ( -111, -222 );")
results, err=db:exec("select * from 'my_table';")

print(err, results)

local sum=0
for i = 1, #results do
    for k, v in pairs( results[i] ) do
	print( i, k, v )
	sum=sum+v
    end
end

print("sum: " .. sum)

db:close()
```

### 判断某张表是否存在

如果使用sqlite的语法，在lua版本中是无效的。



###  注意事项

sqlite的部分功能在lua中并不能完全使用

## 遇到问题

### no lsqlite

在xlua中`require lsqlite`，报找不到lsqlite

	no field package.preload['lsqlite']
	no such builtin lib 'lsqlite'
	no such file 'lsqlite' in CustomLoaders!
	no such resource 'lsqlite.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\lua\lsqlite.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\lua\lsqlite\init.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\lsqlite.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\lsqlite\init.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\..\share\lua\5.3\lsqlite.lua'
	no file 'C:\Program Files\Unity_5_3_7_p4\Editor\..\share\lua\5.3\lsqlite\init.lua'
## 在Mono/Unity中使用sqlite

如果你是在Unity C#中使用sqlite，那么你需要导入sqlite.dll，打开Unity的安装目录，找到以下文件，拷贝到Plugins目录

Sqlite3.dll

Mono.Data.Sqlite.dll

Mono.Data.SqliteClient.dll