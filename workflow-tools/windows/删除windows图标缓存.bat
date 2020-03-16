cd /d %userprofile%\AppData\Local\Microsoft\Windows\Explorer
taskkill /f /im explorer.exe
attrib -h iconcache_*.db
del iconcache_*.db /a
start explorer
pause