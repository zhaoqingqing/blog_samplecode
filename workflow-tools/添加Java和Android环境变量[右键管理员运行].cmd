@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set javaHome=C:\Program Files\Java\jdk1.8.0_202
set androidHome=E:\Android\sdk

echo.
echo ************************************************************
echo *                                                          *
echo *            JDK和Android 系统环境变量设置                 *
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: JAVA_HOME=%javaHome%
echo === 注意: 如果JAVA_HOME存在,会被覆盖,此操作不可逆的,请仔细检查确认!! ===
echo.
echo === 准备设置环境变量(后面有个.): classPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%\lib\dt.jar;.
echo === 注意: 如果classPath存在,会被覆盖,此操作不可逆的,请仔细检查确认!! ===
echo.
echo === 准备设置环境变量: PATH=%%JAVA_HOME%%\bin
echo === 注意: PATH会追加在最前面,
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
echo === 新创建环境变量 JAVA_HOME=%javaHome%
setx "JAVA_HOME" "%javaHome%" -m
echo.
echo === 新创建环境变量 ANDROID_HOME=%androidHome%
setx "ANDROID_HOME" "%androidHome%" -m
echo.
echo === 新创建环境变量 classPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.
setx "classPath" "%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;." -m
echo.

echo.
setx path "%%JAVA_HOME%%\bin;%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;%Y%" -m
echo.
echo.
echo === 请按任意键退出! 
pause>nul