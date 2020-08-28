想把博客园之前的一些html文章转换成markdown的文章，因为md更好地保存，经过实践之后，保留这两个工具，也尝试过python的脚本但运行时有报错，就省心地用了相对稳定的工具。

## pandoc

安装 pandoc，并配置环境变量，在dos下使用下列语句转换格式。

pandoc：https://pandoc.org/installing.html

```powershell
pandoc text.html -o text.markdown
```

pandoc转换出来的html保留了原来的很内容，比如一些特定的div #，比如这样子的

::: {.content}
::: {#outer_postBodyPS}
::: {#postBodyPS}



## html2md

地址：https://github.com/TruthHun/html2md

批量转换脚本

```powershell
@echo on
for /r %%i in (*.html) do html2md.exe %%~pi%%~ni.html %%~pi%%~ni.md
pause
```

这个工具转换出来的html更加简洁，我目前是使用这个脚本进行转换