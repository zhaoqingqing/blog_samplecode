@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set luaHome=D:\lua53

echo.
echo ************************************************************
echo *                                                          *
echo *                   Lua ϵͳ������������                 	*
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: PATH=%luaHome%
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
setx PATH "%PATH%;D:\lua53" -m
echo.
echo.
echo === ������ɣ����CDM����lua��֤�Ƿ�ɹ� 
echo === �밴������˳�! 
pause>nul