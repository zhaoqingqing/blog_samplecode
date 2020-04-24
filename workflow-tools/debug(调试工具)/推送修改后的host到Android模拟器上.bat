::NotePad++之类的文本编辑器，再使用“查找替换”，将“\r\n”替换成“\n”（注意要在notepad++里把查找模式设置为扩展模式，才能识别转义字符\r\n）
@echo off

for /f "delims=" %%i in ( 'where adb') do set ADB=%%i
if not defined ADB (
	echo path中未找到adb.exe
	goto end
)
cd %~dp0
:: 安卓模拟器的安装路径
set ADB=C:\Program Files (x86)\Droid4X\adb.exe

set src_path=%~dp0/hosts

::获取root权限
"%ADB%" root 
::重新挂载模拟器
"%ADB%" remount

::备份设备上的host到本地
"%ADB%"  pull /system/etc/hosts %~dp0\hosts.bak

::推送本地新文件到设备上
"%ADB%" push %src_path% /system/etc/hosts


echo 已将%relativePath%推送到android设备上

pause