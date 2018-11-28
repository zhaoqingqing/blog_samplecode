---
--- Created by zhaoqingqing. 569032731@qq.com
--- DateTime: 2018/11/13
---
require("Common/extable")
local tableChatKeyAndTypeList = {
    {'channel', 'INTEGER'},
    {'fromId', 'INTEGER'},
    {'fromName', 'TEXT'},
    {'fromLevel', 'INTEGER'},
    {'fromCareer', 'INTEGER'},
    {'fromSex', 'INTEGER'},
    {'toId', 'INTEGER'},
    {'soundFile', 'TEXT'},
    {'soundLength', 'INTEGER'},
    {'text', 'TEXT'},
    {'extendData', 'TEXT'},
    {'time', 'INTEGER'},
    {'toName', 'TEXT'},
    {'toLevel', 'INTEGER'},
    {'toCareer', 'INTEGER'},
    {'toSex', 'INTEGER'},
    {'vipLevel', 'INTEGER'}
}
for i, v in pairs(tableChatKeyAndTypeList) do
    print(table.tostring(v))
end