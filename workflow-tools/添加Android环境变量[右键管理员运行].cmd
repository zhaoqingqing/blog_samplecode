@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set sdkHome=D:\android_sdk

echo.
echo ************************************************************
echo *                                                          *
echo *                   Android ϵͳ������������               *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: Android_HOME=%sdkHome%
echo === ע��: ���JAVA_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������: PATH=%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
echo === �´����������� ANDROID_HOME=%sdkHome%
setx "ANDROID_HOME" "%sdkHome%" -M
echo.
echo.
echo === ��׷�ӻ�������(׷�ӵ���ǰ��) PATH=%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;%Y%" -m
echo.
echo.
echo === �밴������˳�! 
pause>nul