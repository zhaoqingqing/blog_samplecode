::pandoc test.html -o test.md
@echo on
for /r %%i in (*.html) do pandoc %%~pi%%~ni.html -o %%~pi%%~ni.md

pause