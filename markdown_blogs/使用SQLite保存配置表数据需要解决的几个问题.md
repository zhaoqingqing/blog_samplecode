## 在Unity中使用sqlite

如果你是在Unity/Mono中使用sqlite，那么打开Unity的安装目录，找到以下文件，拷贝到项目的Plugins目录下

Sqlite3.dll

Mono.Data.Sqlite.dll

Mono.Data.SqliteClient.dll



## 使用SQLite要解决的问题

比如一张很大的数据表，查询一条数据之后，是否整张表的数据都载入内存中？

根据以往使用csv或lua做为配置文件的经验，只要使用到了表中的一条数据，则整张表的数据都截入到了内存中

对于某个界面或者某个玩法才会用到的数据表，能否在关闭/离开时，释放掉配置占用的内存？



