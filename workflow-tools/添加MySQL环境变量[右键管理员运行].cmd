@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set setupdir=c:\Tools\mysql_winx64
rem LPY
echo.
echo ************************************************************
echo *                                                          *
echo *                   MySQL 系统环境变量设置                 *
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: PATH=%setupdir%\bin
echo === 注意: PATH会追加在最前面,
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
echo === 新追加环境变量(追加到最前面) PATH=%setupdir%\bin
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%setupdir%\bin;%Y%" -m
echo.
echo.
echo === 请按任意键退出! 
pause>nul