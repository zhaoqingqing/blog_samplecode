@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set setupdir=D:\lua53
rem LPY
echo.
echo ************************************************************
echo *                                                          *
echo *                   Lua ϵͳ������������                 *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: PATH=%setupdir%
echo === ע��: PATH��׷������ǰ��,
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
echo === ��׷�ӻ�������(׷�ӵ���ǰ��) PATH=%setupdir%
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%setupdir%;%Y%" -m
echo.
echo.
echo === ������ɣ����CDM����lua��֤�Ƿ�ɹ� 
echo === �밴������˳�! 
pause>nul