 error MSB8020: 无法找到 v142 的生成工具(平台工具集 =“v142”)

完整的错误日志如下：

```powershell
1>------ 已启动生成: 项目: hellocpp, 配置: Debug x64 ------
1>C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\VC\VCTargets\Microsoft.Cpp.Platform.targets(67,5): error MSB8020: 无法找到 v142 的生成工具(平台工具集 =“v142”)。若要使用 v142 生成工具进行生成，请安装 v142 生成工具。或者，可以升级到当前 Visual Studio 工具，方式是通过选择“项目”菜单或右键单击该解决方案，然后选择“重定解决方案目标”。
1>已完成生成项目“hellocpp.vcxproj”的操作 - 失败。
========== 生成: 成功 0 个，失败 1 个，最新 0 个，跳过 0 个 ==========
```

原因是这个项目我是使用vs2019创建的，而现在项目组统一的IDE为vs2017

[error MSB8020: 无法找到 v142 的生成工具(平台工具集 =“v142”)。若要使用 v142 生成工具进行生成，请安装 v142 生成工具。_我爱加菲猫-CSDN博客](https://blog.csdn.net/weixin_39956356/article/details/103112448)

