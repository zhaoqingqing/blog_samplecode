@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set sdkhome=C:\Program Files\Java\jdk1.8.0_92
set androidHome=D:\Android\AndroidSdk

echo.
echo ************************************************************
echo *                                                          *
echo *            JDK��Android ϵͳ������������                 *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: JAVA_HOME=%sdkhome%
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
echo === �´����������� JAVA_HOME=%sdkhome%
setx "JAVA_HOME" "%sdkhome%" -M
echo.
echo === �´����������� ANDROID_HOME=%androidHome%
setx "ANDROID_HOME" "%androidHome%" -M
echo.
echo === �´����������� classPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.
setx "classPath" "%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;." -m
echo.
echo.
echo === ��׷�ӻ�������(׷�ӵ���ǰ��) PATH=%%JAVA_HOME%%\bin;%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%%JAVA_HOME%%\bin;%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools;%Y%" -m
echo.
echo.
echo === �밴������˳�! 
pause>nul