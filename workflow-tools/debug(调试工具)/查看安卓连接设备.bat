REM 安卓模拟器的安装路径
cd c:\
cd C:\Program Files (x86)\Droid4X
set workDir=%CD%
REM 如果非安卓模拟器，可以注释上面行
REM adb kill-server
adb devices
PAUSE