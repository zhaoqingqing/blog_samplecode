@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
::set sdkHome=D:\Android\AndroidSdk
set sdkHome=E:\Android\sdk

echo.
echo ************************************************************
echo *                                                          *
echo *                   Android ϵͳ������������               *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: Android_HOME=%sdkHome%
echo === ע��: ���Android_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
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
setx "ANDROID_HOME" "%sdkHome%" -m
echo.
echo.

setx PATH "%PATH%;%%ANDROID_HOME%%\platform-tools;%%ANDROID_HOME%%\tools" -m
echo.
echo.
echo === �밴������˳�! 
pause>nul