
@echo off
@echo ================�ύ���SVN Start===============
rem SVN��װĿ¼
SET svn_home=C:\Program Files\TortoiseSVN\bin

rem SVN��ĿĿ¼(���޸Ķ�Ӧ��Ŀ¼)
SET code=D:\code\res\entities
SET gui=D:\code\res\gui
SET gui2=D:\code\res\gui2

"%svn_home%"\TortoiseProc.exe/command:commit /path:"%code%*%gui%*%gui2%" /notempfile /closeonend:0

echo ==============�ύ���SVN Finish==============