做技术的我们经常会访问github.com，有时出现github访问非常慢或者git clone速度很慢，git push也很慢

原因很简单：github被高高的墙屏蔽了。 所以解决方案就是手动把 cdn 和IP地址绑定一下，或者更换地址。

​     

## 访问慢

1、 获取github地址

访问 http://github.com.ipaddress.com/ 获取ip地址

2、 获取 global.ssl.fastly地址

http://github.global.ssl.fastly.net.ipaddress.com/ 获取ip地址

3、 获取assets-cdn.github.com 地址（可选）

https://github.com.ipaddress.com/assets-cdn.github.com

4、修改hosts映射

Windows下用管理员身份打开以下文件

```javascript
C:\Windows\System32\drivers\etc\hosts
```

在末尾添加上述获取到的地址，然后保存（2020-6-6）

```javascript
140.82.114.3 github.com
199.232.69.194 github.global.ssl.fastly.net 
185.199.108.153 github.com
185.199.109.153 github.com
185.199.110.153 github.com
185.199.111.153 github.com
```

打开CMD，输入以下命令，刷新一下DNS

```powershell
ipconfig /flushdns
```

然后使用ping 命令试试

```powershell
ping github.com
```

注意：如果通过此方法绑定之后，还是无法访问，那么尝试删除掉host中新加的内容，关闭浏览器刷新DNS后再访问试试     

​      

## clone慢

在tampermonkey中安装脚本**GitHub 镜像加速访问、下载**，然后访问github时，页面上会出现镜像网站按钮，使用镜像网站中的地址进行clone

注意：镜像网站中的地址只能clone，无法push

 ![image-20200612191809558](https://img2020.cnblogs.com/blog/363476/202006/363476-20200612192759890-10979560.png)

​     

## github Issues图片无法显示

打开https://githubusercontent.com.ipaddress.com/avatars1.githubusercontent.com，找到最新的IP地址，在host中添加映射，示例

```powershell
199.232.68.133    avatars0.githubusercontent.com
199.232.68.133    avatars1.githubusercontent.com
199.232.68.133    avatars2.githubusercontent.com
```

​     

## 疑问点

这些网站是什么？

```
github.global.ssl.fastly.net 
avatars0.githubusercontent.com
```



## 小技巧

输入你想查询的网址后面跟上.ipaddress.com，就可以查到域名的创建日期，服务器地址，每日访问量等信息

比如我想查询博客园的cnblgs.com，输入https://cnblogs.com.ipaddress.com/，得到信息如下：

Domain Summary

|        Global Traffic Rank | 120                                               |
| -------------------------: | ------------------------------------------------- |
|         Estimated Visitors | 3.1 Million / Day                                 |
| Estimated Page Impressions | 10 Million / Day                                  |
|       Domain Creation Date | November 12, 2003                                 |
|                 Domain Age | 16 years, 6 months and 23 days (6,050 days)       |
|                 IP Address | 101.37.97.51                                      |
|        Web Server Location | ![img](https://s.ipaddress.com/flags/cn.png)China |

想查询github.com 输入 https://github.com.ipaddress.com/，得到信息如下：

Domain Summary

|        Global Traffic Rank | 74 ▾9                                                     |
| -------------------------: | --------------------------------------------------------- |
|         Estimated Visitors | 4.5 Million / Day                                         |
| Estimated Page Impressions | 27.1 Million / Day                                        |
|       Domain Creation Date | October 9, 2007                                           |
|                 Domain Age | 12 years, 7 months and 27 days (4,623 days)               |
|                 IP Address | 140.82.114.3                                              |
|        Web Server Location | ![img](https://s.ipaddress.com/flags/us.png)United States |