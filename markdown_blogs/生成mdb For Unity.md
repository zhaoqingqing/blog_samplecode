我们使用C#代码编译出来的dll是只有pdb文件，没有mdb文件，这样就会在Unity中出现报错时dll中的行号无法打印出来，Unity提供一个pdb2mdb.exe，支持从pdb转成mdb



## 生成方法

经测试在Unity2018.x+win10和win7下可以把pdb2mdb.exe拷贝到任意目录下然后运行 pdb2mdb.exe xx.dll就可以生成mdb文件，也可以在VS中的后期生成事件命令行中配置。

而在Unity2019中，需要用这个方法生成mdb

```powershell
::test in unity2019.2+win10+rider

cd %~dp0
set tableml=%~dp0TableML\TableML\bin\Release\TableML.dll
set tableml_compiler=%~dp0TableML\TableMLCompiler\bin\Release\TableMLCompiler.dll

set mono_path="D:\Program Files\Unity\Editor\Data\MonoBleedingEdge\bin\mono.exe"
set pdb2mdb_path="D:\Program Files\Unity\Editor\Data\MonoBleedingEdge\lib\mono\4.5\pdb2mdb.exe"

%mono_path% %pdb2mdb_path% %tableml%
%mono_path% %pdb2mdb_path% %tableml_compiler%

```





## 报错信息

直接使用pdb2mdb *.dll，会报这个错误，需要加上mono.exe，方法见上面

```powershell
PS D:\Program Files\Unity\Editor\Data\MonoBleedingEdge\lib\mono\4.5> .\pdb2mdb.exe .\TableML.dll
Mono pdb to mdb debug symbol store converter
Usage: pdb2mdb assembly
```