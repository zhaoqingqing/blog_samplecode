SET svn_home=C:\Program Files\TortoiseSVN\bin
cd %~dp0
cd .\..\
set codePath=%CD%
"%svn_home%"\TortoiseProc.exe/command:revert /path:"%codePath%" /notempfile /closeonend:1


pause