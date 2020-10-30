### Profiler的几个函数

dump出来的内存信息

dump memory info(10:15):  MemoryInfo  GC.GetTotalMemory:86M

**Profiler.GetMonoUsedSize:86M**

活动对象分配管理内存和non-collected对象。 　　 　　

这个函数返回的数量分配管理内存对象,活动的和non-collected。总是调用GC.Collect()作为非引用对象，在调用这个函数之前仍将占据空间,直到他们收集的垃圾收集器(GC)。请注意,这将返回一个值不断增加,直到GC.Collect ()。

可以监控这个值用来分析内存的分配



 **Profiler.usedHeapSize:103M**

当前程序使用的堆的大小。 



**Profiler.GetMonoHeapSize:180M**

管理内存预留空间的大小。

这将成长总分配管理内存超过目前保留数量。预留空间的大小分配管理,也将影响频繁的垃圾收集器将如何运行,以及需要多长时间做一个垃圾收集。堆越大,时间越长,但很少会运行。



**Profiler.GetTotalAllocatedMemory（分配内存）:103M**

unity分配的总内存



**Profiler.GetTotalReservedMemory(保留内存):111M**

unity保留的内存

这个函数返回unity保留的总内存包括当前和未来的分配。如果保留内存充分利用、unity将从系统根据需要分配更多的内存。



**Profiler.GetTotalUnusedReservedMemory（未使用保留内存）:7M**



有的项目FPS上显示的内存是Profiler.GetMonoUsedSize，而有的项目是使用Profiler.GetTotalAllocatedMemory



### profile - Memory页的参数

 A. Used Total: 
      当前帧的Unity内存、Mono内存、GfxDriver内存、Profiler内存的总和. 
   B. Reserved Total: 
      系统在当前帧的申请内存. 
   C. Total System Memory Usage: 
      当前帧的虚拟内存使用量.（通常是我们当前使用内存的1.5~3倍) 
   D. GameObjects in Scene: 
      当前帧场景中的GameObject数量. 
   E. Total Objects in Scene: 
      当前帧场景中的Object数量(除GameObject外，还有Component等). 
   F. Total Object Count: 
      Object数据 + Asset数量.



### Profile查函数调用次数

可以通过多次切换场景，查看Profile中某个函数的调用次数是否有变化，来确定是否有重复调用