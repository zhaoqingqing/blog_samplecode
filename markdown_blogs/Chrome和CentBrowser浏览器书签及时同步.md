

在google3月15日之后宣布停止同步之后，在国内使用第三方浏览器同步书签有时候就会遇到问题。

查看chrome同步日期：https://chrome.google.com/sync?hl=zh-CN 或[chrome://sync-internals/](chrome://sync-internals/)

注意书签同步是需要科学上网的。



国内书签同步方案：

- floccus+webdav

- floccus+坚果云


floccus书签同步插件： https://floccus.org/

参考资料：《[同步书签的几种解决方案](https://www.centbrowser.net/zh-cn/forum.php?mod=viewthread&tid=8827&extra=page%3D1)》

## chrome调试工具

[chrome://sync-internals/](chrome://sync-internals/) (或这个也是一样 [chrome://sync/](chrome://sync/) )是给浏览器开发人员使用的调试工具，这段讲的内容都是在这个调试工具中的。

同步的服务器地址：Server URL	https://clients4.google.com/chrome-sync/dev，替换host

```
74.125.204.138 chrome.google.com
64.233.189.113 clients4.google.com 
```

Last Synced会显示同时时间	Just now

Sync Protocol Log会显示同步的日志

点击“Stop Sync (Keep Data)”，之后点击“Request Start”，就会强制同步一次

## 让chrome立即同步

这几个方法会让chrome立即同步

2. 随便添加或删除一个书签，改改设置，理论上两分钟之后Chrome就会立即同步一次。
3. 退出当前Google账号，重新登陆，必定会触发一次同步
4. 点击“Stop Sync (Keep Data)”，之后点击“Request Start”
4. 打开：[chrome://extensions/](chrome://extensions/) (扩展程序)，打开开发者模式，点击更新
5. 删除User Data\Default下面的Cookies和Cookies-journal然后重启浏览器重新登陆试试