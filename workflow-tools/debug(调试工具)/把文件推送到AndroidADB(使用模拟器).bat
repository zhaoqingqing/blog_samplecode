@echo off

for /f "delims=" %%i in ( 'where adb') do set ADB=%%i
if not defined ADB (
	echo path中未找到adb.exe
	goto end
)
:: 模拟器的路径
set ADB=C:\Program Files (x86)\Droid4X\adb.exe
:: 要推送的目录
set DocLuaRoot=/mnt/sdcard/Android/data/com.xxx/files/Lua
set FILE=%1
set relativePath=%FILE:*Product\Lua\=%
set relativePath=%relativePath:\=/%

rem 加密：
%~dp0\FileEncryptor.exe %FILE% file.tmp
"%ADB%" push file.tmp %DocLuaRoot%/%relativePath%.k

rem %ADB% push %FILE% %DocLuaRoot%/%relativePath%.k  

del file.tmp

echo 已将%relativePath%加密并移至：
echo %DocLuaRoot%/%relativePath%.k
:end
pause