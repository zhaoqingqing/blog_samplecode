
@echo off
@echo ================提交多个SVN Start===============
rem SVN安装目录
SET svn_home=C:\Program Files\TortoiseSVN\bin

rem SVN项目目录(请修改对应的目录)
SET code=D:\code\res\entities
SET gui=D:\code\res\gui
SET gui2=D:\code\res\gui2

"%svn_home%"\TortoiseProc.exe/command:commit /path:"%code%*%gui%*%gui2%" /notempfile /closeonend:0

echo ==============提交多个SVN Finish==============