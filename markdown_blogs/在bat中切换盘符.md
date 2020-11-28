在bat程序中，在不同的盘符中切换，直接输入盘符的名字，前面不要加cd，示例

```powershell
cd %~dp0
d:
cd D:\Python37
e:
cd E:\Code\KSFramework
c:
cd C:\Users\qing

pause
```

执行结果如下：

```powershell

E:\Code\blog_samplecode\workflow-tools\windows>cd E:\Code\blog_samplecode\workflow-tools\windows\
E:\Code\blog_samplecode\workflow-tools\windows>d:
D:\>cd D:\Python37
D:\Python37>e:
E:\Code\blog_samplecode\workflow-tools\windows>cd E:\Code\KSFramework
E:\Code\KSFramework>c:
C:\>cd C:\Users\qing
C:\Users\qing>pause
```

如果是这样的写法，反而无法切换到 D:\Python37

```
cd %~dp0
cd d:
cd D:\Python37
```

