以Unity3D引擎 2018.4.15f1 版本为例，使用ugui

测试手机有小米，华为

网易mumu安卓模拟器，CPU设置成二核和三核

UI使用多线程加载



C#中获取CPU核数 Environment.ProcessorCount



## CPU调度

系统空闲进程占用很高的CPU？这其实是CPU处于空闲，软硬件相结合，用来降低功耗，可查看文章《[CPU 空闲时在干嘛？](https://mp.weixin.qq.com/s/N4VLLKDCkkUVjuQm_9z9Mg)》

##### **队列判空：一个更好的设计**

为什么链表中通常会有哨兵节点的原因，就是为了避免各种判空，这样既容易出错也会让代码一团糟

