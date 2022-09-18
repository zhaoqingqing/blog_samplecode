@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set javaHome=C:\Program Files\Java\jdk1.8.0_202
set androidHome=E:\Android\sdk

echo.
echo ************************************************************
echo *                                                          *
echo *            JDK��Android ϵͳ������������                 *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: JAVA_HOME=%javaHome%
echo === ע��: ���JAVA_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������(�����и�.): classPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%\lib\dt.jar;.
echo === ע��: ���classPath����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������: PATH=%%JAVA_HOME%%\bin
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
echo === �´����������� JAVA_HOME=%javaHome%
setx "JAVA_HOME" "%javaHome%" -m
echo.
echo === �´����������� ANDROID_HOME=%androidHome%
setx "ANDROID_HOME" "%androidHome%" -m
echo.
echo === �´����������� classPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.
setx "classPath" "%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;." -m
echo.

echo.
setx path "%%JAVA_HOME%%\bin;%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;%Y%" -m
echo.
echo.
echo === �밴������˳�! 
pause>nul