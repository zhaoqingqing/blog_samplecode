@echo 添加计划任务
rem 把"更新SVN.bat"和此bat放在同一目录，双击即可创建计划任务，每天7：00自动执行此bat
SCHTASKS /Create /SC DAILY /ST 07:00:00 /TN "自动更新SVN" /TR  "%~sdp0更新SVN.bat" /F
pause