---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/3/8
---

require("lsqlite")

-- open an in memory database
 db = lsqlite.open(":memory:")

-- open a file


-- open an inaccessible file
-- db = lsqlite.open("/root/test.db")

-- check if we got an handle
if not db then print("could not open the database") return end
db:exec("create table 'my_table' ( 'a', 'b' );")
results, err=db:exec("select * from 'my_table';")
print(err, results)