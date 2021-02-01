::需要下载https://github.com/TruthHun/html2md 再使用
@echo on
for /r %%i in (*.html) do html2md.exe %%~pi%%~ni.html %%~pi%%~ni.md
pause