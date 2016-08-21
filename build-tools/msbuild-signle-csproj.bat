echo. msbuild build csporj project

set savePath=%~dp0\channel_packages\
set installPath=%~dp0\MicroLauncher\ylwd\ylwd.csproj

msbuild /m %installPath% /t:clean;Rebuild /p:Configuration=Release;OutDir=%savePath%

rem copy build file 

ping -n 15 127.0.0.1>null