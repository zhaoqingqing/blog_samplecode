@echo off
echo ****************************************
echo            自动编译并打包
echo                         
echo                 for wd visual studio by qingqing.zhao
echo ****************************************
title 自动编译微端
color 0a
rem link:http://blog.csdn.net/edcvf3/article/details/10136347
rem 使用方法：1.此bat放在和源代码同级父目录,否则请修改路径 2.执行bat
cd %~dp0 
echo project path %~dp0

rem hh用来解决取小时可能出现空格的问题(凌晨1点到早上9点%time:~0,2%都会出现空格)
set h=%time:~0,2% 
set hh=%h: =0%
set log_file=%~dp0\release_files\buildlog_%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%%hh%%time:~3,2%.log
set save_path=%~dp0\release_files\

set ylwd_sln=%~dp0\ylwd\ylwd.sln
set ylwd_files=%~dp0\ylwd\ylwd\bin\Release\ylwd.exe

set fileUpdate_sln=%~dp0\fileUpdate\fileUpdate.sln
set fileUpdate_files=%~dp0\fileUpdate\fileUpdate\bin\Release\fileUpdate.exe

rem this project don't create sln,use csproj
set launcher_sln=%~dp0\Lanucher_WinForm\Lanucher_WinForm.csproj
set launcher_files=%~dp0\Lanucher_WinForm\bin\Release\YlLaunch.exe


set uninst_sln=%~dp0\uninst\uninst.sln
set uninst_files=%~dp0\uninst\uninst\bin\Release\uninst.exe

rem please update visual studio install path
cd /d c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\
rem document https://msdn.microsoft.com/zh-cn/library/xee0c8y7.aspx
rem 用法：devenv [解决方案文件 | 项目文件 | 任意文件.扩展名] [开关]

echo.
echo *** start building ......***

devenv %ylwd_sln% /Rebuild Release /project "ylwd\ylwd.csproj" /projectconfig Release /Out %log_file% 
copy %ylwd_files% %save_path%\ylwd_test.exe
echo copy %ylwd_files% to %save_path%\ylwd_test.exe
 
devenv %fileUpdate_sln% /Rebuild Release /project "fileUpdate\fileUpdate.csproj" /projectconfig Release /Out %log_file% 
copy %fileUpdate_files% %save_path%\fileUpdate_test.exe
echo copy %fileUpdate_files% to %save_path%\fileUpdate_test.exe

devenv %launcher_sln% /Rebuild Release /project "Lanucher_WinForm.csproj" /projectconfig Release /Out %log_file% 
copy %launcher_files% %save_path%\YlLaunch_test.exe
echo copy %launcher_files% to %save_path%\YlLaunch_test.exe

devenv %uninst_sln% /Rebuild Release /project "uninst\uninst.csproj" /projectconfig Release /Out %log_file% 
copy %uninst_files% %save_path%\uninst_test.exe
echo copy %uninst_files% to %save_path%\uninst_test.exe

echo ***************************************
echo              auto build complete!
echo ***************************************
echo.

pause                                                                                                                            