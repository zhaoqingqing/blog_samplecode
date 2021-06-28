@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set luaHome=D:\lua53

echo.
echo ************************************************************
echo *                                                          *
echo *                   Lua 系统环境变量设置                 	*
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: PATH=%luaHome%
echo === 注意: PATH会追加在最前面,
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
setx PATH "%PATH%;D:\lua53" -m
echo.
echo.
echo === 设置完成，请打开CDM输入lua验证是否成功 
echo === 请按任意键退出! 
pause>nul