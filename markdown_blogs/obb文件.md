### obb格式

上架google play需要限制包体大小在100MB以内，资源文件使用obb文件格式。

上传的时候就是一个APK+obb文件。

obb存放的是资源文件，代码文件通过so存放在APK内



>  **obb的文件命名规则： main.versioncode.{package_name}.obb**
>
>  **示例：main.1.com.xxx.sgame.obb**



### SarpZipLib库

SarpZipLib下载：https://www.nuget.org/packages/SharpZipLib/

SharpZipLib文档：https://icsharpcode.github.io/SharpZipLib/help/api/index.html

主要知识点

- ZipOutputStream 压缩输出流，将文件一个接一个的写入压缩文档，此类不是线程安全的。
- PutNextEntry 开始一个新的ZIP条目，ZipOutputStream中的方法。
- ZipEntry 一个ZIP文件中的条目，可以理解为压缩包里面的一个文件夹/文件。
- ZipInputStream 解压缩输出流，从压缩包中一个接一个的读出文档。
- GetNextEntry 读出ZIP条目，ZipInputStream中的方法。

### 制作obb

使用ICSharpCode.SharpZipLib 制作obb，也是一种压缩格式

ZipEntryFactory类：https://icsharpcode.github.io/SharpZipLib/help/api/ICSharpCode.SharpZipLib.Zip.ZipEntryFactory.html

```c#
zipEntryFactory.MakeFileEntry(entryName)
    
```

代码可参考：[C# 利用SharpZipLib生成压缩包](https://www.cnblogs.com/hsiang/p/9721423.html)



### 读取obb

必须在主线程中读取obb

obb文件可以压缩包内读取文件而不用解压

示例：

```c#
var obbFile = new ZipFile（fileStream)
obbFile.IsStreamOwner = true
obbFile.GetEntry(fileName.Replace("\\","/"))
```

```csharp
ZipEntry GetEntry(string name)
```

Searches for a zip entry in this archive with the given name. String comparisons are case insensitive