@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set gradleHome=D:\gradle-7.1\bin

echo.
echo ************************************************************
echo *                                                          *
echo *                   Gradle 系统环境变量设置                *
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: GRADLE_HOME=%gradleHome%
echo === 注意: 如果GRADLE_HOME存在,会被覆盖,此操作不可逆的,请仔细检查确认!! ===
echo.
echo === 准备设置环境变量: PATH=%gradleHome%
echo === 注意: PATH会追加在最前面,
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
setx path "%path%;D:\gradle-7.1\bin" -m
echo.
echo.
echo === 请按任意键退出! 验证：gradle -v
pause>nul