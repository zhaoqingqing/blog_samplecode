本文通过实际例子来看看StackFrame和StackTrace有什么区别，分别在.NET和Unity中测试。

## .NET环境

测试代码

```c#
using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyFunc1();
            MyFunc2();
            Console.ReadKey();
        }

        static void MyFunc1()  { Console.WriteLine(new StackFrame(true)); }
        static void MyFunc2() { Console.WriteLine(new StackTrace(true)); }
    }
}
```

通过Debug或Release模式生成exe运行而非在IDE下运行，在这两种模式下有、无pbd文件，输出结果是一致的，如下所示

### 有pdb文件

MyFunc1 at offset 59 in file:line:column E:\Code\csharp_study\ConsoleApplication1\ConsoleApplication1\Program.cs:15:34

   在 ConsoleApplication1.Program.MyFunc2() 位置 E:\Code\csharp_study\ConsoleApplication1\ConsoleApplication1\Program.cs:行号 16
   在 ConsoleApplication1.Program.Main(String[] args) 位置 E:\Code\csharp_study\ConsoleApplication1\ConsoleApplication1\Program.cs:行号 11

### 删除pdb文件

MyFunc1 at offset 59 in file:line:column <filename unknown>:0:0

   在 ConsoleApplication1.Program.MyFunc2()
   在 ConsoleApplication1.Program.Main(String[] args)

## Unity环境

我的unity版本 unity 2019.3.7 个人版

### 在Unity编辑器下

测试代码如下：

```c#
void OnClickBtn1()
{
	MyFunc1();
	MyFunc2();
}

void MyFunc1()
{
	Debug.Log(this.name + "click stacktrace:\n" + new StackTrace(true) + "\n");
}

void MyFunc2()
{
	Debug.Log(this.name + "click stackframe:\n" + new StackFrame(true) + "\n");
}
```



 **new StackFrame(true)打印的堆栈如下：**
Canvasclick stackframe:
MyFunc2 at offset 1 in file:line:column E:\Code\UGUIDemo\Assets\Function\TestLogStackTrace.cs:58:9



 **new StackTrace(true) 打印的堆栈**（在上面的基础上会有更多的Unity底层堆栈）

Canvasclick stacktrace:
  at TestLogStackTrace.MyFunc1 () [0x00001] in E:\Code\UGUIDemo\Assets\Function\TestLogStackTrace.cs:53 
  at TestLogStackTrace.OnClickBtn1 () [0x00001] in E:\Code\UGUIDemo\Assets\Function\TestLogStackTrace.cs:35 
.....中间省略一些Unity的调用栈
at UnityEngine.EventSystems.EventSystem.Update () [0x000f9] in D:\Program Files\Unity\Editor\Data\Resources\PackageManager\BuiltInPackages\com.unity.ugui\Runtime\EventSystem\EventSystem.cs:377 
UnityEngine.Debug:Log(Object)
ButtonScene:OnClickBtn1() (at Assets/uGUI/Scripts/ButtonScene.cs:40)
UnityEngine.EventSystems.EventSystem:Update() (at D:/Program Files/Unity/Editor/Data/Resources/PackageManager/BuiltInPackages/com.unity.ugui/Runtime/EventSystem/EventSystem.cs:377)

## 结论

结合实践和反编译mscorlib.dll的代码来看

StackTrace中有一个StaceFrame列表，包含完整的调用栈，对于第二个函数的完整调用栈如下

```powershell
new StackTrace(true) = {StackTrace} "   在 ConsoleApplication1.Program.MyFunc2()\r\n   在 ConsoleApplication1.Program.Main(String[] args)\r\n"
 FrameCount = {int} 2
 Static members = {} 
 Non-public members = {} 
  frames = {StackFrame[]} Count = 5
   [0] = {StackFrame} "GetStackFramesInternal at offset 0 in file:line:column <filename unknown>:0:0\r\n"
   [1] = {StackFrame} "CaptureStackTrace at offset 188 in file:line:column <filename unknown>:0:0\r\n"
   [2] = {StackFrame} ".ctor at offset 100 in file:line:column <filename unknown>:0:0\r\n"
   [3] = {StackFrame} "MyFunc2 at offset 27 in file:line:column <filename unknown>:0:0\r\n"
   [4] = {StackFrame} "Main at offset 43 in file:line:column <filename unknown>:0:0\r\n"
  m_iMethodsToSkip = {int} 3
  m_iNumOfFrames = {int} 2
```

而stackFrame中只有当前函数的这一帧调用者信息

这个结论同时适用于.NET环境和Unity环境中。

目前我们Unity线上项目设置的堆栈为Script only
