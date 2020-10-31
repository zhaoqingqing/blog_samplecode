## 寄存器

**寄存器**（Register）是[中央处理器](https://zh.wikipedia.org/wiki/中央處理器)内用来暂存指令、[数据](https://zh.wikipedia.org/wiki/數據)和[地址](https://zh.wikipedia.org/wiki/内存地址)的[电脑存储器](https://zh.wikipedia.org/wiki/電腦記憶體)。寄存器的存贮容量有限，读写速度非常快。在[计算机体系结构](https://zh.wikipedia.org/wiki/電腦架構)里，寄存器存储在已知时间点所作计算的中间结果，通过快速地访问数据来加速[计算机程序](https://zh.wikipedia.org/wiki/電腦程式)的运行。

寄存器位于[存储器层次结构](https://zh.wikipedia.org/wiki/記憶體階層)的最顶端，也是CPU可以读写的最快的存储器。寄存器通常都是以他们可以保存的[比特](https://zh.wikipedia.org/wiki/位元)数量来计量，举例来说，一个[8位](https://zh.wikipedia.org/wiki/8位元)寄存器或[32位](https://zh.wikipedia.org/wiki/32位元)寄存器。在中央处理器中，包含寄存器的部件有[指令寄存器](https://zh.wikipedia.org/wiki/指令寄存器)（IR）、[程序计数器](https://zh.wikipedia.org/wiki/程序計數器)和[累加器](https://zh.wikipedia.org/wiki/累加器)。寄存器现在都以[寄存器数组](https://zh.wikipedia.org/w/index.php?title=暫存器陣列&action=edit&redlink=1)的方式来实现，但是他们也可能使用单独的[触发器](https://zh.wikipedia.org/wiki/正反器)、高速的[核心存储器](https://zh.wikipedia.org/w/index.php?title=核心記憶體&action=edit&redlink=1)、[薄膜存储器](https://zh.wikipedia.org/w/index.php?title=薄膜記憶體&action=edit&redlink=1)以及在数种机器上的其他方式来实现出来。

**寄存器**也可以指代由一个[指令](https://zh.wikipedia.org/wiki/指令)之输出或输入可以直接索引到的寄存器组群，这些寄存器的更确切的名称为“架构寄存器”。例如，[x86](https://zh.wikipedia.org/wiki/X86)指令集定义八个32位寄存器的集合，但一个实现[x86](https://zh.wikipedia.org/wiki/X86)[指令集](https://zh.wikipedia.org/wiki/指令集)的[CPU](https://zh.wikipedia.org/wiki/CPU)内部可能会有八个以上的寄存器。

## 寄存器的种类

- 资料寄存器

  用来存储[整数](https://zh.wikipedia.org/wiki/整數)数字（参考以下的浮点寄存器）。在某些简单（或旧）的CPU，特别的资料寄存器是用于数学计算的[累加器](https://zh.wikipedia.org/wiki/累加器)。

- 地址寄存器

  持有存储器地址，以及用来访问[存储器](https://zh.wikipedia.org/wiki/記憶體)。在某些简单/旧的CPU里，特别的地址寄存器是[索引寄存器](https://zh.wikipedia.org/w/index.php?title=索引暫存器&action=edit&redlink=1)（可能出现一个或多个）。

- 通用目的寄存器

  （**GPR**s）- 可以保存资料或地址两者，也就是说他们是结合 资料/地址 寄存器的功用。

- 浮点寄存器

  （**FPR**s）- 用来存储[浮点](https://zh.wikipedia.org/wiki/浮点)数字。

- 常量寄存器

  用来持有只读的数值（例如0、1、圆周率等等）。由于“其中的值不可更改”这一特殊性质，这些寄存器未必会有实体的硬件电路相对应，例如将从零常数寄存器读的操作实现为接通目标寄存器的[下拉电阻](https://zh.wikipedia.org/wiki/下拉电阻)。

  一般而言，即使真正在硬件中放置常数寄存器也未必会是出于体系结构理论上的考虑，而很可能是由[硬件描述语言](https://zh.wikipedia.org/wiki/硬件描述语言)为了简化操作而自动生成的电路。

- 向量寄存器

  用来存储由向量处理器运行[SIMD](https://zh.wikipedia.org/wiki/SIMD)指令所得到的资料。

- 特殊目的寄存器

  存储CPU内部的资料，像是[程序计数器](https://zh.wikipedia.org/wiki/程式計數器)（或称为[指令指针](https://zh.wikipedia.org/wiki/指令指针)），[堆栈寄存器](https://zh.wikipedia.org/wiki/堆栈)，以及[状态寄存器](https://zh.wikipedia.org/w/index.php?title=狀態暫存器&action=edit&redlink=1)（或称微处理器状态字组）。**[指令寄存器](https://zh.wikipedia.org/wiki/指令寄存器)** - 存储现在正在被运行的指令**[变址寄存器](https://zh.wikipedia.org/w/index.php?title=变址寄存器&action=edit&redlink=1)** - 是在程序运行时用来更改操作数地址之用。在某些架构下，**模式指示寄存器**（也称为“机器指示寄存器”）存储和设置跟处理器自己有关的资料。由于他们的意图目的是附加到特定处理器的设计，因此他们并不被预期会成微处理器世代之间保留的标准。有关从[随机存取存储器](https://zh.wikipedia.org/wiki/隨機存取記憶體)提取信息的寄存器与CPU（位于不同芯片的存储寄存器集合）[存储器缓冲寄存器](https://zh.wikipedia.org/w/index.php?title=記憶體緩衝寄存器&action=edit&redlink=1)[存储器资料寄存器](https://zh.wikipedia.org/wiki/記憶體資料寄存器)[存储器地址寄存器](https://zh.wikipedia.org/w/index.php?title=記憶體位址寄存器&action=edit&redlink=1)[存储器类型范围寄存器](https://zh.wikipedia.org/w/index.php?title=記憶體型態範圍寄存器&action=edit&redlink=1)

## CPU支持情况

|                           CPU架构                            | 整数 寄存器数量 | [双精度浮点数](https://zh.wikipedia.org/wiki/雙精度浮點數) 寄存器数量 |
| :----------------------------------------------------------: | :-------------: | :----------------------------------------------------------: |
|           [x86](https://zh.wikipedia.org/wiki/X86)           |        8        |                              8                               |
|        [x86-64](https://zh.wikipedia.org/wiki/X86-64)        |       16        |                              16                              |
|    [System/360](https://zh.wikipedia.org/wiki/System/360)    |       16        |                              4                               |
| [z/Architecture](https://zh.wikipedia.org/w/index.php?title=Z/Architecture&action=edit&redlink=1) |       16        |                              16                              |
|       [Itanium](https://zh.wikipedia.org/wiki/Itanium)       |       128       |                             128                              |
|    [UltraSPARC](https://zh.wikipedia.org/wiki/UltraSPARC)    |       32        |                              32                              |
|     [IBM POWER](https://zh.wikipedia.org/wiki/IBM_POWER)     |       32        |                              32                              |
|       [Alpha](https://zh.wikipedia.org/wiki/DEC_Alpha)       |       32        |                              32                              |
|        [6502](https://zh.wikipedia.org/wiki/MOS_6502)        |        3        |                              0                               |
|   [PIC微控制器](https://zh.wikipedia.org/wiki/PIC微控制器)   |        1        |                              0                               |
|    [AVR微控制器](https://zh.wikipedia.org/wiki/Atmel_AVR)    |       32        |                              0                               |
|         [ARM](https://zh.wikipedia.org/wiki/ARM架構)         |       16        |                              16                              |

摘自：[维基百科-寄存器](https://zh.wikipedia.org/wiki/%E5%AF%84%E5%AD%98%E5%99%A8)

## 寄存器的作用

通用寄存器

| 寄存器 |                                   | 简写       | 主要用途                                                     |
| ------ | --------------------------------- | ---------- | ------------------------------------------------------------ |
| EAX    | 累加(Accumulator)寄存器           | AX(AH、AL) | 常用于乘、除法和函数返回值                                   |
| EBX    | 基址(Base)寄存器                  | BX(BH、BL) | 常做内存数据的指针, 或者说常以它为基址来访问内存.            |
| ECX    | 计数器(Counter)寄存器             | CX(CH、CL) | 常做字符串和循环操作中的计数器                               |
| EDX    | 数据(Data)寄存器                  | DX(DH、DL) | 常用于乘、除法和 I/O 指针                                    |
| ESI    | 来源索引(Source Index)寄存器      | SI         | 常做内存数据指针和源字符串指针                               |
| EDI    | 目的索引(Destination Index)寄存器 | DI         | 常做内存数据指针和目的字符串指针                             |
| ESP    | 堆栈指针(Stack Point)寄存器       | SP         | 只做堆栈的栈顶指针; 不能用于算术运算与数据传送               |
| EBP    | 基址指针(Base Point)寄存器        | BP         | 只做堆栈指针, 可以访问堆栈内任意地址, 经常用于中转 ESP 中的数据, 也常以它为基址来访问堆栈; 不能用于算术运算与数据传送 |