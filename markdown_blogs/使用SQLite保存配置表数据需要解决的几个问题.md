## 在Unity中使用sqlite

如果你是在Unity/Mono中使用sqlite，那么打开Unity的安装目录，找到以下文件，拷贝到项目的Plugins目录下

Sqlite3.dll

Mono.Data.Sqlite.dll

Mono.Data.SqliteClient.dll



蓝大使用sqlite是使用的libsqlite.so，从sqlite官网下载的安卓aar，解压出来是libsqlitex.so，而SQLite4Unity3d中也是libsqlite.so



## 使用SQLite要解决的问题

测试版本：Unity 2019.3.7f1

是否会载入整张表的数据

比如一张很大的数据表，查询一条数据之后，是否整张表的数据都载入内存中？

根据以往使用csv或lua做为配置文件的经验，只要使用到了表中的一条数据，则整张表的数据都截入到了内存中

A：经过在Unity中的实测，不会载入整张表中的数据

### 释放掉不用的配置数据

对于某个界面或者某个玩法才会用到的数据表，能否在关闭/离开时，释放掉配置占用的内存？



## ORM映射

推荐使用 [SQLite4Unity3d](https://github.com/robertohuertasm/SQLite4Unity3d) 数据库驱动层采用：[sqlite-net](https://github.com/praeclarum/sqlite-net)

已经做好了ORM映射，经测试可以在Unity的运行时修改数据库中的内容，且无需重启Unity。试过插入两千条数据，依然很慢，所以不建议在运行时插入数据。

疑问：

看上去没有ios的库，但官方说可以在IOS上使用

