@echo off

reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v ShowSecondsInSystemClock /t REG_DWORD /d 1 /f

TASKKILL /F /IM explorer.exe

echo.

echo ����explorer.exe

START %windir%\explorer.exe

echo.

pause