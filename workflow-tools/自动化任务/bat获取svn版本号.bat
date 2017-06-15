:: ttp://stackoverflow.com/questions/3179649/getting-the-current-revision-number-on-command-line-via-tortoisesvn
:: 借助window下的tortoisesvn获取本地svn副本的版本号
:: SubWCRev后请替换成自己本地的svn副本

for /f "tokens=5" %%i in ('SubWCRev  e:\3dsn\client\client_demo_ios\^|find "Last committed at revision"') do set version=%%i

echo %version%

pause