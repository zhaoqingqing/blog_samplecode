### 上传文件到海马玩模拟器 

环境变量:ANDROID_SDK_HOME配置是D:\Android\android_sdk_windows
报错:adb server version (31) doesn’t match this client (40); killing… 

分析:海马玩和sdk中adb版本不一致 
验证:1、打开海马玩路径，查看对应的adb版本信息

```bash
C:\Program Files (x86)\Droid4X>adb version 
Android Debug Bridge version 1.0.31
```



2、再看看我们sdk路径下对应的adb版本信息

```bash
C:\Users\zhaoq>adb version
Android Debug Bridge version 1.0.40
Version 4986621
Installed as D:\Android\android_sdk_windows\platform-tools\adb.exe
```

**解决方法**

直接用sdk\platform-tools\adb.exe下面的adb替换海马玩的adb，重启海马玩，重新建立adb连接。



### 手机客户端无法连接

报错信息如下 

```bash
C:\Users\zhaoq>adb shell 
adb server version (31) doesn't match this client (40); killing...

- daemon started successfully * 
error: no devices/emulators found 
```

错误原因： 
adb版本不对 
因为我升级了SDK，导致sdk\platform-tools\adb.exe文件更新升级了，而手机客户端不能连接上去 



解决办法
我找到以前的sdk里面的adb.exe文件，使用旧版的adb.exe文件替换sdk\platform-tools\adb.exe文件，完美解决 



参考：https://blog.csdn.net/codehxy/article/details/52175186?utm_source=copy 

PS. 上述报错，并不是网上所说的端口被占用问题。