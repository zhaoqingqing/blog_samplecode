在使用svn进行checkout或update时，我想让文件的日期为提交那时的日期，这要怎样做？

说明：我是在windows下使用TortoiseSVN进行操作的

### 方法1.修改config

```ini
[miscellany]
use-commit-times = yes
```

### 方法2.界面设置

在TortoiseSVN，右键- 设置-常规(TortoiseSVN->Settings->General)->勾选 “将文件日期设置为‘最后提交时间’”。

### 官方文档

TortoiseSvn的官方文档：https://tortoisesvn.net/docs/nightly/TortoiseSVN_zh_CN/tsvn-dug-settings.html

设置方法如下图所示

![image-20210315095016591](https://img2020.cnblogs.com/blog/363476/202103/363476-20210315100039762-1659631057.png)

### 测试结果

经测试在TortoiseSvn1.11版本设置之后，需要重启电脑才会生效。在未重启之前每次update或重新checkout还是会使用当前的系统时间