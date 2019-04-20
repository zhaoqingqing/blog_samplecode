

### 遇到问题

在做编辑器开发时，需要在Unity Editor下直接读取Excel源文件，首先想到的是通过npoi去读取，但是遇到无法读取xlsx格式，只能读取xls格式的问题。



我的环境

unity 2018.3.6f1

npoi 2.4.1

xlsx指excel 2007格式 ，xls指excel2003格式

资料issues： https://github.com/tonyqus/npoi/issues/182



### 解决方案

在vs工程中安装npoi，找到依赖项**sharpziplib**，在**packages/**目录下

（注：nuget安装包【npoi.nupkg】并不包含sharpzip.dll）

**使用npoi对应版本的SharpZipLib**，放到unity中，就可解决，比如：

NPOI.2.4.1/net40/*.dll

SharpZipLib.0.86.0

注意：一定要使用npoi对应版本的sharpziplib，如果原unity工程中有sharpziplib，则替换掉。



### 无法创建xlsx格式

如果遇到npoi创建出来的xlsx无法打开，可尝试以下方法（注：wps可以打开，但ms office无法打开）

应该数据流写入的 是 .xlsx 的数据模式但是 用的是.xls的后缀名,导致数据识别错误



创建xlsx格式和xls格式 使用不同的接口

xls 2003格式：   HSSFWorkbook wk = new HSSFWorkbook(fs);

xlsx 2007格式： XSSFWorkbook wk = new XSSFWorkbook(fs); 就可以了



### C#配置表解析器

使用C#+npoi编写的配置表解析器：[TableML Excel编译/解析工具](https://www.cnblogs.com/zhaoqingqing/p/7440980.html)



### 开源代码

在npoi的基础之上，又封装了一层，便于简单地读取excel

<https://github.com/mr-kelly/KSFramework>

查找 ExcelFile.cs

