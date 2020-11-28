怎样找出svn修改次数最多的文件？

我想统计配置表中，那个配置文件修改次数最多，但经过实践发现statsvn只支持到1.3的版本。

通过svn的命令行接口，把提交记录保存到xml中，再通过自己写代码解析xml也可以统计出修改次数最多文件。

```powershell
cd e:code\xx_svn
svn log --xml -v > svn_log.xml
```



statsvn官网：[http://www.statsvn.org](http://www.statsvn.org)

截止2020-11-28 最新版本为0.7 于01 Jan 2010发布，应该是没有在维护了。

经测试目前只支持到subversion 1.3，我本地安装的svn版本号为11，提示

> net.sf.statsvn.util.javautiltaskLogger error. subversion found 1.11 required 1.3.0