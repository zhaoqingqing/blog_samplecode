@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set sdkHome=D:\gradle-7.1

echo.
echo ************************************************************
echo *                                                          *
echo *                   Gradle ϵͳ������������               *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: GRADLE_HOME=%sdkHome%
echo === ע��: ���GRADLE_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������: PATH=%sdkHome%
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
echo === �´����������� GRADLE_HOME=%sdkHome%
setx "GRADLE_HOME" "%sdkHome%" -M
echo.
echo.
echo === ��׷�ӻ�������(׷�ӵ���ǰ��) PATH=%sdkHome%\bin;
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%sdkHome%\bin;%Y%" -m
echo.
echo.
echo === �밴������˳�! ��֤��gradle -v
pause>nul