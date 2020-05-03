## 打包工具

### 程序集更新工具

UpdateAssemblyInfo.cs

未使用反射，通过替换Assemblyinfo.cs更新程序集信息

### 文件列表生成工具

WdResList.cs

```json
data/Managed/Assembly-CSharp.dll&95a1a6893a40a5ef79487c98c973840828af9f6f
```

WebResList.cs

```html
data/Managed/Assembly-CSharp.dll&276cbc75702d21e4a378b00afdf0b1b9066058fd&1|
data/Managed/Assembly-CSharp.dll&95a1a6893a40a5ef79487c98c973840828af9f6f&2|
```

### VS(Visual Studio) 自动打包脚本

build_donet_muilt_csproj.bat

build_donet_signle_csproj.bat

### MSBuild 自动打包脚本

msbuild-sample.cmd

## 博客园自动化脚本

自动发布博客到博客园