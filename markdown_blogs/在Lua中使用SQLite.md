## 在Lua中使用sqlite

Lua版本Sqlite文档：[http://lua.sqlite.org/index.cgi/doc/tip/doc/lsqlite3.wiki](http://lua.sqlite.org/index.cgi/doc/tip/doc/lsqlite3.wiki)

sqlite官网：[https://www.sqlite.org/index.html](https://www.sqlite.org/index.html)

### 用途

- 把游戏中的配置表数据存储到sqlite中
- 存储游戏中的聊天记录

### sqlite的优点

提高游戏的启动速度，在游戏启动时，不需要去加载配置文件，而是在用到时，从sqlite中读取，大大提高启动速度。

### 运行环境

我们是把sqlite编译进xlua的lib(.so)在lua中调用，没有通过mono提供的sqlite接口访问
我的运行环境如下（说明：文章写于2017年6月1日，在草稿箱一直未发布）

XLua： v2.1.6 

Unity ：5.3.7

luasqlite版本：sqlite 3

## 使用示例

### 创建表并查询

表的创建，添加数据，查询

```lua
--a simple libsqlite3 binding for lua5.0-5.2 that provides 3 functions only and is still fully functional: local db = lsqlite.open(database) results, err = db:exec(statments) db:close()

require("lsqlite")

-- open an in memory database
db = lsqlite.open(":memory:")

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

更多例子：https://docs.coronalabs.com/api/library/sqlite3/index.html



### 判断某张表是否存在

如果使用sqlite的语法，在lua版本中是无效的。

解决办法：使用xpcall捕获异常



### 数据查询

```lua
---比如select(query)功能
for row in self.db:nrows('SELECT * FROM '..tableName..' where '..idKey..'="'..value..'"') do
--- row就是一行数据
end
```

### 对表的操作

```lua
 ---对table的操作，通常用于insert,update，append，create
self.db:exec(sql)
```

###  注意事项

sqlite的部分功能在lua中并不能完全使用



## 遇到问题

### no lsqlite

直接在lua环境下，'require lsqlite`，报找不到lsqlite，需要导入sqlite，可以把它编译到xlua.so中

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
### 在Unity的lua环境无法close所有连接，导致Unity锁定db

查看文档：http://lua.sqlite.org/index.cgi/doc/tip/doc/lsqlite3.wiki#db_close

使用db:close和db:close_vm() 都无法完全关闭db的连接

编辑db文件，提示database被锁定

解决办法：通过在Unity的C#层进行Close

## 我的经验分享

### 把配置表分成多个db

经实测在移动设备或模拟器上执行Update/Create Table等SQL语句，性能非常差，执行一次热更新SQL约需要15s而直接下载并替换db则会快很多，所以我推荐直接替换db文件。

因为当有数据更新时是替换db，建议把经常修改的配置表放在一个db中，不常修改的放另一个db，也就是把数据存在多个db中。

根据我从业三个rpg游戏项目的经验，最常修改的部分有：

1. 语言包
2. 任务表
3. 道具表(装备，物品等等这些)
4. 新手引导
5. 自宝义配置表(key/value形式的表)
6. 活动表（充值/节日/节日活动表，部分数据放配置，部分配置协议下发）

