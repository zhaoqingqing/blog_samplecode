

本文所指的Runtime是指Unity所使用的.NET版本，当然你可能会说Unity是使用的Mono，但本质上Mono也是从.NET发展而来，但在Unity对Mono或多或少有一些修改，具体以Unity的文档为准。

## Unity各版本对应的C# Runtime

说明：Scripting Backend不管是选Mono或IL2CPP，API Compatibility Level都是一样的

| Unity引擎版本    | Api Compatibility Level(API兼容性)                     | Unity发布日期 |
| ---------------- | ------------------------------------------------------ | ------------- |
| Unity5.3.8       | .NET 2.0 和 .NET 2.0 Subset                            |               |
| Unity2018.4.15f1 | .NET 4.x Equivalent 和 .NET 3.5 Equivalent(Deprecated) |               |
| Unity2019.3.7f1  | .NET 4.x 和.NET Standard 2.0                           |               |

英文单词翻译

Subset 子集

Equivalent  等价值

Deprecated 弃用的

### .NET 版本说明

| .NET 版本         | 发布日期      |      |
| ----------------- | ------------- | ---- |
| .NET 2.0          |               |      |
| .NET 3.5          |               |      |
| .NET 4.x          |               |      |
| .NET Standard 2.0 | 2017年8月14日 |      |




### .NET 2.0 Subset

.NET 2.0 提供了几乎整套的API功能，但是很多时候游戏都用不上那么多，导致大量多余的代码占用了宝贵的空间资源。为了避免浪费，我们就可以用Unity提供的 .NET 2.0 Subset（相当于.NET 2.0的一个子集）。为节省资源，这里面很多一般用不到的程序代码都被移除了，所以这一优化也会是很有用的，只是需要确保我们的代码能够正常工作。



### .NET Standard 

.NET Standard 在更加底层做了一层共用的东西，对于.NET的多种实现(AspNet Core/ Net Core /Xamarin)都将遵循或说实现相同的API接口

关于.NET Standard 2.0的更多信息《[介绍 .NET Standard](https://zhuanlan.zhihu.com/p/24267356)》

.NET Framework 4.6.1已支持.NET Standard 2.0

## IL2CPP 运行原理

![image-20200725091528094](E:\Code\blog_samplecode\blog_images\image-20200725091528094.png)