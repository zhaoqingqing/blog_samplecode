

google宣布在3月15日之后[禁用提供给第三方Chromium内核的浏览器的同步功能](https://www.oschina.net/news/127037/google-removed-3rd-chromium-sync)，那么使用基于Chrominum内

核的第三方浏览器在同步书签，扩展和配置时就会遇到问题，比如我使用的CentBrowser。

查看chrome书签同步日期：https://chrome.google.com/sync?hl=zh-CN 或[chrome://sync-internals/](chrome://sync-internals/)

注意书签同步是需要科学上网的。



网上找了下几种书签同步方案：

- floccus+webdav

- floccus+坚果云


floccus书签同步插件： https://floccus.org/

参考资料：《[同步书签的几种解决方案](https://www.centbrowser.net/zh-cn/forum.php?mod=viewthread&tid=8827&extra=page%3D1)》

## chrome调试工具

[chrome://sync-internals/](chrome://sync-internals/) (这个也是一样 [chrome://sync/](chrome://sync/) )是给浏览器开发人员使用的调试工具，这段讲的内容都是在这个调试工具中的内容。

Server URL	https://clients4.google.com/chrome-sync/dev：同步的服务器地址


Last Synced：显示同时时间	，比如：Just now

Sync Protocol Log：显示同步的日志

点击“Stop Sync (Keep Data)”，之后点击“Request Start”，就会强制同步一次

## 让chrome立即同步

这几个方法会让chrome立即同步，前提要在能科学上学的状态下操作。

2. 随便添加或删除一个书签，改改设置，理论上两分钟之后Chrome就会立即同步一次。
3. 退出当前Google账号，重新登陆，必定会触发一次同步
4. 点击“Stop Sync (Keep Data)”，之后点击“Request Start”
4. 打开：[chrome://extensions/](chrome://extensions/) (扩展程序)，打开开发者模式，点击更新
5. 删除User Data\Default下面的Cookies和Cookies-journal然后重启浏览器重新登陆试试