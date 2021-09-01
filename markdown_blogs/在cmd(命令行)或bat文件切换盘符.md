## bat文件

写一个自动更新git的bat文件，如果bat文件放在E盘，想要去到D盘的某个目录下执行命令，代码如下：

```powershell
SET ksf=D:\code\KSFramework
@echo on

d:
cd %ksf%
git pull
```



## 进入D盘

### 命令d:

打开cmd，默认是在C:\Users\zhaoq>，如果要进入d盘，使用如下命令：d:，再接着输入你要前往的目录，不要使用cd d:\

```powershell
d:
cd D:\Program Files\Microvirt\MEmu\
```

输出结果如下：

```powershell
C:\Users\zhaoq>d:
D:\>
```

### 错误方法

而如果使用  ` cd d:\ ` 则无法进入D盘，测试脚本如下：

```powershell
C:\Users\zhaoq>cd d:\
C:\Users\zhaoq>
```



## 进入C盘

同样通过上面的方法，却无法进入到根目录

```powershell
C:\Users\zhaoq>c:
C:\Users\zhaoq>c:
```

需要使用 `cd c:\`

```powershell
C:\Users\zhaoq>cd c:\
c:\>
```