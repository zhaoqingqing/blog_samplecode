@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set setupHome=C:\mingw64\bin

echo.
echo ************************************************************
echo *                                                          *
echo *                   Lua ϵͳ������������                 	*
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: PATH=%setupHome%
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
setx PATH "%PATH%;C:\mingw64\bin" -m
echo.
echo.
echo === ������ɣ����CDM����gcc��֤�Ƿ�ɹ� 
echo === �밴������˳�! 
pause>nul