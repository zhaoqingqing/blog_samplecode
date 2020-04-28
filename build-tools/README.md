## 0.1 打包工具


### 0.1.1 程序集更新工具


UpdateAssemblyInfo.cs

未使用反射，通过替换Assemblyinfo.cs更新程序集信息

### 0.1.2 文件列表生成工具


WdResList.cs

```json
data/Managed/Assembly-CSharp.dll&95a1a6893a40a5ef79487c98c973840828af9f6f
```

WebResList.cs

```html
data/Managed/Assembly-CSharp.dll&276cbc75702d21e4a378b00afdf0b1b9066058fd&1|
data/Managed/Assembly-CSharp.dll&95a1a6893a40a5ef79487c98c973840828af9f6f&2|
```

### 0.1.3 Devenv(Visual Studio) 自动打包脚本


build_donet_muilt_csproj.bat

build_donet_signle_csproj.bat

### 0.1.4 MSBuild 自动打包脚本
