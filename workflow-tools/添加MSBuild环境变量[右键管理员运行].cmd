@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set setupdir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin

echo.
echo ************************************************************
echo *                                                          *
echo *                   msbuild ϵͳ������������               *
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
echo === ������ɣ����CDM����msbuild��֤�Ƿ�ɹ� 
echo === �밴������˳�! 
pause>nul