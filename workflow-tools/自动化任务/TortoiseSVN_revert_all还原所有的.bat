SET svn_home=C:\Program Files\TortoiseSVN\bin
REM 还原某个目录下的所有文件
cd /d %~dp0
set codePath=%CD%
"%svn_home%"\TortoiseProc.exe/command:revert /path:"%codePath%" /notempfile /closeonend:1


pause