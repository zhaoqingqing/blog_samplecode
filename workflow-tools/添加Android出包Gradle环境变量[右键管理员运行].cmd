@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set gradleHome=D:\gradle-7.1\bin

echo.
echo ************************************************************
echo *                                                          *
echo *                   Gradle ϵͳ������������                *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: GRADLE_HOME=%gradleHome%
echo === ע��: ���GRADLE_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������: PATH=%gradleHome%
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
setx path "%path%;D:\gradle-7.1\bin" -m
echo.
echo.
echo === �밴������˳�! ��֤��gradle -v
pause>nul