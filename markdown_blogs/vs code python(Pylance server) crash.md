The Pylance server crashed 5 times in the last 3 minutes. The server will not be restarted. See the output for more information.

当Pylance server挂了之后，vscode中python代码无法跳转，同一文件内也不行。

解决方法

1. 打开vscode的终端

2. 执行以下命令

```sql
set NODE_OPTIONS=--max_old_space_size=8172
```

3. 然后执行运行，完美解决问题！

vscode版本：

> 版本: 1.70.0 (user setup)
> 提交: da76f93349a72022ca4670c1b84860304616aaa2
> 日期: 2022-08-04T04:38:16.462Z
> Electron: 18.3.5
> Chromium: 100.0.4896.160
> Node.js: 16.13.2
> V8: 10.0.139.17-electron.0
> OS: Windows_NT x64 10.0.19042



参考资料：https://blog.csdn.net/lyh1299259684/article/details/114936824

## 错误日志


<--- Last few GCs --->

[24648:0000205C002E4000]     4061 ms: Scavenge 40.0 (51.2) -> 37.3 (53.2) MB, 1.5 / 0.0 ms  (average mu = 0.998, current mu = 0.998) task; 
[24648:0000205C002E4000]     4473 ms: Scavenge 41.5 (53.2) -> 38.0 (55.2) MB, 1.6 / 0.0 ms  (average mu = 0.998, current mu = 0.998) task; 
[24648:0000205C002E4000]     5250 ms: Scavenge 43.6 (55.2) -> 39.2 (55.9) MB, 1.1 / 0.0 ms  (average mu = 0.998, current mu = 0.998) task; 

<--- JS stacktrace --->


<--- JS stacktrace --->

FATAL ERROR: MarkCompactCollector: young object promotion failed Allocation failed - JavaScript heap out of memory
FATAL ERROR: MarkCompactCollector: young object promotion failed Allocation failed - JavaScript heap out of memory
 1: 00007FF673C886D6 node::Buffer::New+50438
 1: 00007FF673C886D6 node::Buffer::New+50438
 1: 00007FF673C886D6 node::Buffer::New+50438
 2: 00007FF673C888DF node::OnFatalError+463
 2: 00007FF673C888DF node::OnFatalError+463
 2: 00007FF673C888DF node::OnFatalError+463
 3: 00007FF6767807EA v8::ScriptOrigin::HostDefinedOptions+858
 3: 00007FF6767807EA v8::ScriptOrigin::HostDefinedOptions+858
 3: 00007FF6767807EA v8::ScriptOrigin::HostDefinedOptions+858
 4: 00007FF67678073C v8::ScriptOrigin::HostDefinedOptions+684
 4: 00007FF67678073C v8::ScriptOrigin::HostDefinedOptions+684
 4: 00007FF67678073C v8::ScriptOrigin::HostDefinedOptions+684
 5: 00007FF676827A43 v8::CppHeap::CollectGarbageInYoungGenerationForTesting+53827
 5: 00007FF676827A43 v8::CppHeap::CollectGarbageInYoungGenerationForTesting+53827
 5: 00007FF676827A43 v8::CppHeap::CollectGarbageInYoungGenerationForTesting+53827
 6: 00007FF67523B151 v8::CppHeap::GetHeapHandle+188273
 6: 00007FF67523B151 v8::CppHeap::GetHeapHandle+188273
 6: 00007FF67523B151 v8::CppHeap::GetHeapHandle+188273
 7: 00007FF673186B18 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+173064
 7: 00007FF673186B18 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+173064
 7: 00007FF673186B18 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+173064
 8: 00007FF673186686 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+171894
 8: 00007FF673186686 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+171894
 9: 00007FF67318D489 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+200057
 9: 00007FF67318D489 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+200057
10: 00007FF673F4D778 GetHandleVerifier+2670104
10: 00007FF673F4D778 GetHandleVerifier+2670104
11: 00007FF6741C5AE4 node_api_get_module_file_name+6276
11: 00007FF6741C5AE4 node_api_get_module_file_name+6276
 8: 00007FF673186686 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+171894
12: 00007FF673C9E438 uv_thread_create_ex+488
13: 00007FF675BB2CD0 Cr_z_crc32+4161984
 9: 00007FF67318D489 cppgc::DefaultPlatform::MonotonicallyIncreasingTime+200057
14: 00007FFF428C7034 BaseThreadInitThunk+20
10: 00007FF673F4D778 GetHandleVerifier+2670104
15: 00007FFF440A2651 RtlUserThreadStart+33
11: 00007FF6741C5AE4 node_api_get_module_file_name+6276
12: 00007FF673C9E438 uv_thread_create_ex+488
[Error - 10:46:27] The Pylance server crashed 5 times in the last 3 minutes. The server will not be restarted. See the output for more information.