## 前言

SDK下载：官网 - Pipeline SDK 选择对应Unity版本的SDK

创建项目：Pipeline产品 - 本地资源检测

从官网下载sdk之后，zip包中有详细的接入文档

使用效果参考：[New | UWA本地资源检测正式上线](https://blog.uwa4d.com/archives/UWA_Pipeline2.html)

截止2020-7-25这项服务是免费的，当然官网也写了目前还在公测阶段(从2020-3-6开始)是免费使用的

## 进行Scan

比如我们项目是分了很多个工程，不同工人员日常在各自工程工作(开发、美术)，最终把资源打包到GameBase运行

- GameBase(纯客户端代码工程)
- fx(特效工程)
- scene(场景/地编工程)
- charactor(角色工程)
- ui(gui界面工程)

在每个工程中都进行scan一遍，然后上传每个工程的uwascan结果到uwa官网进行分析

对于纯代码工程，scan速度是很快的，而如果资源比较多的工程，速度就会慢一些，比如fx工程Asset目录约有 4g 消耗时间约20分钟



## 上传到uwa