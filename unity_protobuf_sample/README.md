## 仓库说明
unity +  c++/nodejs 进行tcp通信，使用prototobuf序列化和反序列化
### 测试环境
- unity 5.3.4f1 (使用UGUI显示UI)
- c++ 11/nodejs6.3.1
- protobuf 2.6.x
- windows 7/10,linux-centos6.x
- IDE:visual studio in windows,eclipse for c++ in centos

## 文件说明
**unity工程**
<pre>
Assets
	Reporter （unity3d logs viewer 好用的查看日志插件[free]）
	Plugins
		protobuf
	Scritps
		NetTest
			UINetConn.cs（主文件）
			PackageSocket.cs(网络层封装)
			SimpleJson.cs
	ConsoleE （增强版unity console[free]）
	NetConn.unity
ProjectSettings
	资源序列成Text，显示meta
</pre>
**protobuf_tools**
<pre>
protobuf_tools
	 client(根据协议生成的c#代码)
	 echoserver
	 server(根据协议生成的c++代码)
	 protoc unzip here.7z (下载后请解压)
	 Google.ProtocolBuffers.dll(google的protobuf文件)
	 ProtoGen.exe
	 main.proto（协议内容）
	 build_client_protobuf.bat(自动生成proto客户端代码)
 	 build_server_protobuf.bat(自动生成proto服务器代码)

</pre>
