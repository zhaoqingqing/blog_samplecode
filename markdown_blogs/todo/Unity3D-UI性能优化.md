### 关于UI上的内存管理

UI上每个图片/图标都是由框架管理内存，当图片隐藏/UI关闭时，释放掉这部分内存。

存在问题

实现比较复杂