cd %~dp0

sqlite3 .svn\wc.db "select * from work_queue"
sqlite3 .svn\wc.db "delete from work_queue"

svn cleanup
svn update

pause