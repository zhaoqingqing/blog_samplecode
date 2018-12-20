:: svn添加所有新增加文件
svn add * --no-ignore --force

::svn 获取所有的已删除列表
svn status | findstr /R "^!" > missing.list
:: 把已删除的列表添加到svn 状态中
for /F "tokens=2 delims= " %%A in (missing.list) do (svn delete %%A)
del missing.list

svn ci -m "[admin auto build windows assetbundles]"

pause