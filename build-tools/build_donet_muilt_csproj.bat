@echo off
echo ****************************************
echo            �Զ�����΢��������
echo                         
echo                 	for wd visual studio project
echo					by qingqing.zhao(569032731@qq.com)
echo ****************************************
title �Զ�����΢��������
color 0a
rem ʹ�÷�����1.��bat���ں�Դ����ͬ����Ŀ¼,�������޸�·�� 2.ִ��bat
cd %~dp0 
echo project path %~dp0

rem hh�������ȡСʱ���ܳ��ֿո������(�賿1�㵽����9��%time:~0,2%������ֿո�)
set h=%time:~0,2% 
set hh=%h: =0%
set log_file=%~dp0\channel_packages\buildlog_%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%hh%%time:~3,2%.log
set save_path=%~dp0\channel_packages\

set ylwd_sln=%~dp0\ylwd\ylwd.sln
set ylwd_files=%~dp0\ylwd\ylwd\bin\Release\ylwd.exe

set fileUpdate_sln=%~dp0\fileUpdate\fileUpdate.sln
set fileUpdate_files=%~dp0\fileUpdate\fileUpdate\bin\Release\fileUpdate.exe

rem this project don't create sln,use csproj
set launcher_sln=%~dp0\Lanucher_WinForm\Lanucher_WinForm.csproj
set launcher_files=%~dp0\Lanucher_WinForm\bin\Release\YlLaunch.exe


set uninst_sln=%~dp0\uninst\uninst.sln
set uninst_files=%~dp0\uninst\uninst\bin\Release\uninst.exe

set assistApp_sln=%~dp0\ylwd\ylwd.sln
set assistApp_files=%~dp0\ylwd\WdHelper\bin\Release\AssistApp.exe

set logicmodule_sln=%~dp0\ylwd\ylwd.sln
set logicmodule_files=%~dp0\ylwd\LogicModule\bin\Release\LogicModule.dll

rem todo please update visual studio install path
cd /d c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\
rem document https://msdn.microsoft.com/zh-cn/library/xee0c8y7.aspx

echo.
echo *** start build ......***

devenv %ylwd_sln% /Rebuild Release /project "ylwd\ylwd.csproj" /projectconfig Release /Out %log_file% 
copy %ylwd_files% %save_path%\ylwd.exe
echo copy %ylwd_files% to %save_path%\ylwd.exe
 
devenv %fileUpdate_sln% /Rebuild Release /project "fileUpdate\fileUpdate.csproj" /projectconfig Release /Out %log_file% 
copy %fileUpdate_files% %save_path%\fileUpdate.exe
echo copy %fileUpdate_files% to %save_path%\fileUpdate.exe

devenv %launcher_sln% /Rebuild Release /project "Lanucher_WinForm.csproj" /projectconfig Release /Out %log_file% 
copy %launcher_files% %save_path%\YlLaunch.exe
echo copy %launcher_files% to %save_path%\YlLaunch.exe

devenv %uninst_sln% /Rebuild Release /project "uninst\uninst.csproj" /projectconfig Release /Out %log_file% 
copy %uninst_files% %save_path%\uninst.exe
echo copy %uninst_files% to %save_path%\uninst.exe

devenv %assistApp_sln% /Rebuild Release /project "WdHelper\WdHelper.csproj" /projectconfig Release /Out %log_file% 
copy %assistApp_files% %save_path%\AssistApp.exe
echo copy %assistApp_files% to %save_path%\AssistApp.exe

devenv %logicmodule_sln% /Rebuild Release /project "LogicModule\LogicModule.csproj" /projectconfig Release /Out %log_file% 
copy %logicmodule_files% %save_path%\LogicModule.dll
echo copy %logicmodule_files% to %save_path%\LogicModule.dll

copy %~dp0\wd_config\2lewan.json %save_path%\config.json
copy %~dp0\ylwd\libs\Newtonsoft.Json.dll %save_path%\Newtonsoft.Json.dll


echo ***************************************
echo          auto build complete!
echo ***************************************
echo.

ping -n 5 127.0.0.1>nul                                                                                                                             