@ECHO OFF & PUSHD %~DP0 & TITLE 添加资源管理器右键
Md "%WinDir%\System32\test_permissions" 2>NUL||(Echo 请使用右键管理员身份运行&&Pause >NUL&&Exit)
Rd "%WinDir%\System32\test_permissions" 2>NUL
SetLocal EnableDelayedExpansion
reg add "HKLM\SOFTWARE\Classes\*\shellex\ContextMenuHandlers\CirrusShellEx" /ve /d "{57FA2D12-D22D-490A-805A-5CB48E84F12A}" /F>NUL
reg add "HKLM\SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\CirrusShellEx" /ve /d "{57FA2D12-D22D-490A-805A-5CB48E84F12A}" /F>NUL
reg add "HKLM\SOFTWARE\Classes\lnkfile\shellex\ContextMenuHandlers\CirrusShellEx" /ve /d "{57FA2D12-D22D-490A-805A-5CB48E84F12A}" /F>NUL
reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved" /v {57FA2D12-D22D-490A-805A-5CB48E84F12A} /d "Beyond Compare 4 Shell Extension" /F>NUL
reg add "HKLM\SOFTWARE\Classes\.bcpkg" /ve /d BeyondCompare.SettingsPackage /F>NUL
reg add "HKLM\SOFTWARE\Classes\.bcss" /ve /d BeyondCompare.Snapshot /F>NUL
reg add "HKLM\SOFTWARE\Classes\BeyondCompare.SettingsPackage" /ve /d "Beyond Compare Settings Package" /F>NUL
reg add "HKLM\SOFTWARE\Classes\BeyondCompare.SettingsPackage\DefaultIcon" /ve /d "%~dp0BCompare.exe,0" /F>NUL
reg add "HKLM\SOFTWARE\Classes\BeyondCompare.SettingsPackage\shell\open\command" /ve /d "\"%~dp0BCompare.exe\" \"%%1\"" /F>NUL
reg add "HKLM\SOFTWARE\Classes\BeyondCompare.Snapshot" /ve /d "Beyond Compare Snapshot" /F>NUL
reg add "HKLM\SOFTWARE\Classes\BeyondCompare.Snapshot\DefaultIcon" /ve /d "%~dp0BCompare.exe,0" /F>NUL
if exist "%WinDir%\SysWOW64" reg add "HKLM\SOFTWARE\Classes\CLSID\{57FA2D12-D22D-490A-805A-5CB48E84F12A}\InProcServer32" /ve /d "%~dp0BCShellEx64.dll" /F>NUL
if not exist "%WinDir%\SysWOW64" reg add "HKLM\SOFTWARE\Classes\CLSID\{57FA2D12-D22D-490A-805A-5CB48E84F12A}\InProcServer32" /ve /d "%~dp0BCShellEx.dll" /F>NUL
reg add "HKLM\SOFTWARE\Classes\CLSID\{57FA2D12-D22D-490A-805A-5CB48E84F12A}\InProcServer32" /v ThreadingModel /d "Apartment" /F>NUL
reg add "HKLM\SOFTWARE\Scooter Software\Beyond Compare\BcShellEx" /v ExePath /d "%~dp0BCompare.exe" /F>NUL
reg add "HKLM\SOFTWARE\Scooter Software\Beyond Compare 4\BcShellEx" /v ExePath /d "%~dp0BCompare.exe" /F>NUL
reg add "HKLM\SYSTEM\CurrentControlSet\Services\EventLog\Application\Beyond Compare 4" /v EventMessageFile /d "%~dp0BCompare.exe" /F>NUL 
reg add "HKLM\SYSTEM\CurrentControlSet\Services\EventLog\Application\Beyond Compare 4" /v TypesSupported /t REG_DWORD /d "7" /F>NUL 
ECHO.&ECHO.完成! 是否创建桌面快捷方式？
ECHO.&ECHO.是请按任意键，否就直接关闭！&PAUSE >NUL 2>NUL
mshta VBScript:Execute("Set a=CreateObject(""WScript.Shell""):Set b=a.CreateShortcut(a.SpecialFolders(""Desktop"") & ""\BCompare.lnk""):b.TargetPath=""%~dp0BCompare.exe"":b.WorkingDirectory=""%~dp0"":b.Save:close")&ECHO.&ECHO.完成! &PAUSE >NUL 2>NUL