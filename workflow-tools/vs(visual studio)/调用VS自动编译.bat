@echo off
echo ****************************************
echo            自动编译安装器
echo                         
echo                 	for visual studio project
echo					by 赵青青(569032731@qq.com)
echo ****************************************
title 自动编译安装器
color 0a
rem 使用方法：1.此bat放在和源代码同级父目录,否则请修改路径 2.执行bat
cd %~dp0 
echo project path %~dp0

rem hh用来解决取小时可能出现空格的问题(凌晨1点到早上9点%time:~0,2%都会出现空格)
set h=%time:~0,2% 
set hh=%h: =0%
set log_file=%~dp0\channel_packages\build_installer_log_%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%hh%%time:~3,2%.log


set savePath=%~dp0\channel_packages\
set installerPath=%~dp0\MicroLauncher\ylwd\ylwd.csproj
set installerBuildFiles=%~dp0\MicroLauncher\ylwd\bin\Release\ylwd.exe

msbuild /m %installerPath% /t:clean;Rebuild /p:Configuration=Release  /fl /flp:logfile=%log_file%;verbosity=diagnostic

copy %installerBuildFiles% %savePath%\ylwd.exe


echo ***************************************
echo          安装器编译完成.请进行多渠道版本配置
echo ***************************************
echo.
rem pause
ping -n 15 127.0.0.1>nul