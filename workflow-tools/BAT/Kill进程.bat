@echo offEcho
tasklist /V /S localhost /U %username% >temp_process_list.txt  
type temp_process_list.txt | find "et.exe"  | find "wps.exe" 

if errorlevel 1 goto NotExist
if errorlevel 0 goto KillProcess

:NotExist
echo 进程不存在，不处理

:KillProcess
Echo 正在杀死进程...
rem WPS相关的进程 Kill
taskkill /f /im et.exe
taskkill /f /im wps.exe
Echo 杀死进程完毕

del temp_process_list.txt
pause