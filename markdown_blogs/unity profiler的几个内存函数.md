dump出来的内存信息

dump memory info(10:15):  MemoryInfo  GC.GetTotalMemory:86M
  Profiler.usedHeapSize:103M
  Profiler.GetMonoHeapSize:180M
  Profiler.GetMonoUsedSize:86M
  Profiler.GetTotalAllocatedMemory（分配内存）:103M
  Profiler.GetTotalReservedMemory(保留内存):111M
  Profiler.GetTotalUnusedReservedMemory（未使用保留内存）:7M



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





