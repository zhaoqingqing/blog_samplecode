@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set setupHome=C:\mingw64\bin

echo.
echo ************************************************************
echo *                                                          *
echo *                   Lua 系统环境变量设置                 	*
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: PATH=%setupHome%
echo === 注意: PATH会追加在最前面,
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
setx PATH "%PATH%;C:\mingw64\bin" -m
echo.
echo.
echo === 设置完成，请打开CDM输入gcc验证是否成功 
echo === 请按任意键退出! 
pause>nul