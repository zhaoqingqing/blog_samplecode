### 一、什么是lua&luaJit

lua（www.lua.org）其实就是为了嵌入其它应用程序而开发的一个脚本语言，
luajit（www.luajit.org）是lua的一个Just-In-Time也就是运行时编译器，也可以说是lua的一个高效版。

### 二、优势

1）lua是一个免费、小巧、简单、强大、高效、轻量级的嵌入式的脚本语言,lua当前的发行版本5.3.1只有276k。
2）它是用C语言开发的项目，所以可以在大部分的操作系统上运行
3）lua是目前速度最快的脚本语言，既可以提升语言的灵活性还可以最大限度的保留速度
4）其语法非常简单，没有特例
5）lua还可以作为C的API来使用

### 三、不足和不同

1）lua没有强大的库，所以很多功能实现起来没有python、perl、ruby等脚本语言简洁
2）lua的异常处理功能饱受争议，虽然其提供了pcall和xpcall的异常处理函数
3）lua原生语言中没有提供对unicode编码的支持，虽然可以通过一些折中的办法实现 http://www.cppblog.com/darkdestiny/archive/2009/04/25/81055.html
4）没有提供在C++中应用很广泛的a?b:c的三元运算符操作
5）没有switch...case...语法，只能通过if..elseif..elseif..else..end的方式折中实现
6)在循环时没有提供continue语法
7）没有C++中应用广泛的a++和a+=1等操作
8）lua的索引是从1开始的，而不是我们熟悉的0（string，table）
9）当你给一个元素赋值为nil时相当于这个元素不存在
10）lua的数值类型只有number是没有int，float，double等之分的
11）lua中没有类的概念，其类是通过table的形式来实现的
12）lua中只有nil和false是表示假的，零在lua中是为真的
13）很多程序需要（）标示才能运行，比如a={["b"]=5},print(a.b)是可运行的，但是 {["b"]=5}.b就会报错，需要（{["b"]=5}）.b才可以

### 四、综述

综上，lua是一个简单、高效的语言，所以在游戏逻辑开发和[服务器](https://www.baidu.com/s?wd=%E6%9C%8D%E5%8A%A1%E5%99%A8&tn=24004469_oem_dg&rsv_dl=gh_pl_sl_csd)开发中（ngx_lua）得到广泛的应用。

## luajit官方性能优化指南和注解

[luajit官方性能优化指南和注解](https://www.cnblogs.com/zwywilliam/p/5992737.html)

luajit是目前最快的脚本语言之一，不过深入使用就很快会发现，要把这个语言用到像宣称那样高性能，并不是那么容易。实际使用的时候往往会发现，刚开始写的一些小test case性能非常好，经常毫秒级就算完，可是代码复杂度一上去了，动辄几十上百毫秒的情况就会出现，性能表现非常飘忽。

为此luajit的mailling list也是有不少人咨询，作者mike pall的一篇比较完整的回答被放在了官方wiki上：

 

<http://wiki.luajit.org/Numerical-Computing-Performance-Guide>

 

不过原文说了很多怎么做，却基本没有解释为什么。

 

所以这篇文章不是简单的翻译官方这个优化指南，最主要还是让大家了解luajit背后的一些原理，因为原文中只有告诉你怎么做，却没说清楚为什么，导致做了这些优化，到底影响多大，原因是啥，十分模糊。了解背后的原因往往对我们有很大的帮助。

另外，原生lua、luajit的jit模式（pc和安卓可用）、luajit的interpreter模式（ios下只能运行这个），他们执行lua的原理是有很大的不同的，也导致一些lua优化技巧并不见得是通用的。而这篇文章主要针对luajit的jit模式。

 

 

#### 1.Reduce number of unbiased/unpredictable branches.

#### 减少不可预测的分支代码

分支代码就是根据条件会跳转的代码（最典型就是if..else），那什么是不可预测的分支代码？简单说：

if 条件1 then

elseif 条件2 then

假如条件1或者条件2其中一方达成的概率非常高（>95%），那我们认为这是可预测的分支代码。

这是被mike pall放到第一位的性能优化点（事实上确实应该如此），究其原因是luajit使用了trace compiler的特性，为了生成的机器码尽可能高效，它会根据代码的运行情况进行一些假设，比如上面的例子如果luajit发现，条件2的达成概率非常高，那么luajit会生成按条件2达成执行最快的代码。

有一点可能大家会问，luajit真的能知道运行过程中的一些情况？

是的

这也是trace compiler的特征：先运行字节码，针对热点代码做profile，了解了可以优化的点后再优化出最高效的机器码。这就是luajit目前的做法。

为什么要这样呢？给一个比较好理解的例子：luajit是动态类型语言，面对一个a+b，你根本不知道a和b是什么类型，如果a+b只是两个整数相加，那么编译机器码做求和速度自然是飞快的。可是如果你无法确认这点，结果你只能假定它是任意类型，先去动态检查类型（看看到底是两个表，还是两个数值，甚至是其他情况），再跳根据类型做相应的处理，想想都知道比两个整数相加慢了几十倍。

所以luajit为了极限级的性能，就会大胆进行假设，如果发现a+b就是两个数值相加，就编译出数值求和的机器码。

但是如果某一时刻a+b不是数值相加，而是变成了两个表相加呢？这机器码岂不是就导致错误了？因此每次luajit做了假设时，都会加上一段守护代码（guard），检查假设是不是对的，如果不对，就会跳转出去，再根据情况，来决定要不要再编译一段新的机器码，来适配新的情况。

这就是为什么你的分支代码一定要可预测，因为如果经常不符合luajit假设的东西，就会经常从编译好的机器码中跳出来，甚至会因为好几次假设失败而连跳好几次。所以，luajit是一个对分支情况极度敏感的语言。

这是luajit的第一性能大坑，作者建议可以借助math.min/max或者bitop来绕过if else这样的分支代码。不过实际情况往往更复杂，所有涉及到跳转代码的地方，都是潜在的性能坑。

另外，在interpreter模式下（ios的情况），luajit就变成了老老实实动态检查动态跳转的执行模式，对分支预测反而并不敏感，并不需要过分注重这方面的优化。

 

 

#### 2.Use FFI data structures.

#### 如果可以，将你的数据结构用ffi实现，而不是用lua table实现

luajit的ffi是一个常被大家忽略的功能，或者只被当做一个更好用的c导出库，但事实上这是一个超级性能利器。

 

比如要实现unity中的Vector3，分别用lua table和用ffi实现，我们测试下来，内存占用是10:1，运算x+y+z的耗时也是大概8:1，优化效率惊人。

代码如下：

```lua

local ffi = require("ffi")
ffi.cdef [[
    typedef struct { float x, y, z; } vector3c;
    ]]
local count = 100000
local function test1()
    local startTime = os.time()
    -- lua table的代码
    local vecs = {}
    for i = 1, count do
        vecs[i] = { x = 1, y = 2, z = 3 }
    end
    local total = 0
    -- gc后记录下面for循环运行时的时间和内存占用，这里省略
    for i = 1, count do
        total = total + vecs[i].x + vecs[i].y + vecs[i].z
    end
    local diffTime = os.time() - startTime
    print("lua table 耗时：", diffTime)
end

local function test2()
    local startTime = os.time()
    -- ffi的代码
    local vecs = ffi.new("vector3c[?]", count)
    for i = 1, count do
        vecs[i] = { x = 1, y = 2, z = 3 }
    end

    local total = 0
    -- gc后记录下面for循环运行时的时间和内存占用，这里省略
    for i = 1, count do
        total = total + vecs[i].x + vecs[i].y + vecs[i].z
    end
    local diffTime = os.time() - startTime
    print("ffi 耗时：", diffTime)
end

test1()
test2()
```



为何有这么大的差距？因为lua table本质是一个hash table，在hash table访问字段固然是缓慢的并且要存储大量额外的东西。而ffi可以做到只分配xyz三个float的空间就能表示一个Vector3，自然内存占用要低得多，而且jit会利用ffi的信息，实现访问xyz的时候直接读内存，而不是像hash table那样走一次key hash，性能也高得多。

不幸的是ffi只在有jit模式的时候才能有很好的运行速度，现在做手游基本都要做ios，而ios下由于只能运行解释模式，ffi的性能很差（比纯table反而更慢），仅仅内存优势得到保留，所以如果要考虑ios这样的平台，这个优化点基本可以忽略，或者只在安卓下针对少数核心代码进行优化。

 

 

#### 3.Call C functions only via the FFI.

#### 尽可能用ffi来调用c函数。

同样的，ffi也可以用于调用已经extern c的c函数。大家表面上都以为这样做只是省掉了用tolua之类的工具做导出的麻烦，但ffi更大的好处，是在于性能上质的提升。

这是因为，使用ffi导出c函数，你需要提供c函数的原型，有了c函数的原型信息，luajit可以知道每个参数的准确类型，返回值的准确类型。了解编译器知识的同学都知道函数调用和返回一般都是用栈来实现的，而要做到这点必须要知道整个参数列表和返回值类型，才能生成出出栈入栈的代码。因此luajit在拥有这些信息之后就可以生成机器码，跟c编译器一样做到无缝的调用，而不需要像标准的lua与c交互那样需要调用pushint等等函数来传参了。

如果不通过ffi调用c导出函数，那么因为luajit缺乏这个函数的信息，无法生成用于调用c函数的jit代码，自然会降低性能。而且在2.1.0版本之前，这会直接导致jit失败，整段相关的代码都无法jit化，性能会收到极大的影响。

 

 

#### 4.Use plain 'for i=start,stop,step do ... end' loops.

#### 实现循环时，最好使用简单的for i = start, stop, step do这样的写法，或者使用ipairs，而尽量避免使用for k,v in pairs(x) do

首先，直到目前最新的luajit2.1.0beta2，for k,v in pairs(t) do end是不支持jit的（即无法生成机器码运行）。至于这个坑的存在主要还是因为按kv遍历table的汇编比较难写，但至少可以知道，目前如果想高效遍历数组或者做for循环，直接使用数值做索引是最佳的方法。

其次，这样的写法更利于做循环展开。

 

 

#### 5.Find the right balance for unrolling.

#### 循环展开，有利有弊，需要自己去平衡

在早期的c++时代，手工将循环代码展开成顺序代码是一种常见的优化方法，但是后来编译器都集成了一定的循环展开优化能力，代替手工做这种事情。而luajit本身也带有这块的优化（可以参考其实现函数lj_opt_loop），可以对循环进行展开。

不过这个展开是在运行时做的，所以也有利有弊。作者举例，如果在一个两层循环中，内循环的循环次数不够10次，这个部分会被尝试展开，但是由于嵌套在外部的大循环，外部大循环可能会导致内部循环多次进入，多次展开，导致展开次数过大，最终jit会取消展开。

至于这方面的性能未做深入测试，作者也只是给出了一些比较感性的优化建议（最后来了一句，You may have to experiment a bit），有了解的同学欢迎交流。

 

 

 

#### 6.Define and call only 'local' (!) functions within a module.

#### 7.Cache often-used functions from other modules in upvalues.

这两点都可以拿到一起说，即调用任何函数的时候，保证这个函数是local function，性能会更好，比如：

```lua
local ms = math.sin
function test()
  math.sin(1)
  ms(1)
end

```



这两行调用math.sin有什么区别呢？

事实上math是一个表，math.sin本身就做了一次表查找，key是sin，这里消耗了一次。而math又是一个全局变量，那还要在全局表中做一次查找（_G[math]）

而local ms缓存过之后，math.sin查找就可以省掉了，另外，对于function上一层的变量，lua会有一个upvalue对象进行存储，在找ms这个变量的时候就只需要在upvalue对象内找，查找范围更小更快捷

当然，jit化后的代码有可能会进一步优化这个过程，但是更好的办法依然是自行local缓存

总之，如果某个函数只在本文件内用到，就将其local，如果是一个全局函数，用之前用local缓存一下。

 

 

#### 8.Avoid inventing your own dispatch mechanisms.

#### 避免使用你自己实现的分发调用机制，而尽量使用內建的例如metatable这样的机制

编程的时候为了结构优雅，常常会引入像消息分发这样的机制，然后在消息来的时候根据我们给消息定义的枚举来调用对应的实现，过去我们也习惯写成：

if opcode == OP_1 then

elesif opcode == OP_2 then

...

但在luajit下，更建议将上面实现成table或者metatable

local callbacks = {}

callbacks[OP_1] = function() ... end

callbacks[OP_2] = function() ... end

这是因为表查找和metatable查找都是可以参与jit优化的，而自行实现的消息分发机制，往往会用到分支代码或者其他更复杂的代码结构，性能上反而不如纯粹的表查找+jit优化来得快

 

 

#### 9.Do not try to second-guess the JIT compiler.

#### 无需过多去帮jit编译器做手工优化。

作者举了一个例子

z = x[a+b] + y[a+b]，这在luajit是性能ok的写法，不需要先local c = a+b然后z = x[c] + y[c]

后面的写法其实本身没什么问题，但是luajit的另一个坑，即为了提升运算效率，local变量会尽可能用cpu寄存器存储，这样比频繁读内存要快得多（现代cpu这可以达到几百倍的差距），但luajit在这方面不完善，一旦local变量太多，可能会找不到足够的寄存器分配（这个问题在armv7上非常明显，在调用层次深的时候，几个变量就会炸掉），然后jit会直接放弃编译。这里要说明一点是，很多local变量可能只是声明了放在那里没有用，但是luajit的编译器不一定能够准确确定这个变量是否可以不再存储，所以适当控制一个函数作用域内的local变量的数量是必须的。

当然，不得不说这样写代码还要猜luajit的行为确实比较痛苦，一般来说进行profile然后对性能热点代码做针对测试和优化基本已经可以。

 

 

 

#### 10.Be careful with aliasing, esp. when using multiple arrays.

#### 变量的别名可能会阻止jit优化掉子表达式，尤其是在使用多个数组的时候。

作者举了一个例子

x[i] = a[i] + c[i]; y[i] = a[i] + d[i]

我们可能会认为两a[i]是同一个东西，编译器可以优化成

local t = a[i]; x[i] = t + c[i]; y[i] = t + d[i]

实则不然，因为可能会出现，x和a就是同一个表，这样，x[i] = a[i] + c[i]就改变了a[i]的值，那么y[i] = a[i] + d[i]就不能再使用之前的a[i]的值了

这里跟优化点9描述的情形的本质区别是，优化点9里头z/a/b都是值类型，而这里x/a都是引用类型，引用类型就有引用同一个东西的可能（变量别名），因此编译器会放弃这样的优化。

 

 

#### 11.Reduce the number of live temporary variables.

#### 减少存活着的临时变量的数量

原因在9中已经说明，即过多的存活着的临时变量可能会耗尽寄存器导致jit编译器无法利用寄存器做优化。这里注意live temporary variables是指存活的临时变量，假如你提前结束了临时变量的生命周期，编译器还是会知道这一点的。比如：

```lua
function foo()
  do
   local a = "haha"
  end
  print(a)
end
```



这里print是会print出nil，因为a离开了do ... end就结束了生命周期，通过这种方式可以避免过多临时变量同时存活。

此外，有一个很常见的陷阱，例如我们实现了一个Vector3的类型用于表达立体空间中的矢量，常常会重载他的一些元函数，比如__add

```lua
Vector3.__add = function(va, vb)
    return Vector3.New(va.x + vb.x, va.y + vb.y, va.z + vb.z)
end
```



然后我们就会在代码中大肆地使用a + b + c来对一堆的Vector3做求和运算。

这其实对luajit是有很大的隐患的，因为每个+都产生了一个新的Vector3，这将会产生大量的临时变量，且不考虑这里的gc压力，光是为这些变量分配寄存器就已经十分容易出问题。

所以这里最好在性能和易用性上进行权衡，每次求和如果是将结果写会到原来的表中，那么压力会小很多，当然代码的易用性和可读性上就可能要牺牲一些。

 

#### 12.Do not intersperse expensive or uncompiled operations.

#### 减少使用高消耗或者不支持jit的操作

这里要提到一个luajit文档中的属于：NYI（not yet implement），意思就是，作者还没有把这个功能做完。。

luajit快是快在能把代码编译为机器码执行，但是并非所有代码都可以jit化，除了前面提到的for in pairs外，还有很多这样的东西，最常见的有：

for k, v in pairs(x)：主要是pairs是无jit实现的，尽可能用ipairs替代。

print()：这个是非jit化的，作者建议用io.write。

字符串连接符：打日志很容易会写log("haha "..x)这样的方式，然后通过屏蔽log的实现来避免消耗。事实上真的可以屏蔽掉吗？然并卵。因为"haha"..x这个字符串链接依然会被执行。在2.0.x的时候这个代码还不支持jit，2.1.x虽然终于支持了，但是多余的连接字符串运算以及内存分配依然发生了，所以想要屏蔽，可以用log("haha %s", x)这样的写法。

table.insert：目前只有从尾部插入才是jit实现的，如果从其他地方插入，会跳转到c实现。



关于在Unity中提升Lua的性能，参考文章：[https://www.cnblogs.com/zwywilliam/](https://www.cnblogs.com/zwywilliam/)



本文转自：[https://blog.csdn.net/qq_35624156/article/details/77455670](https://blog.csdn.net/qq_35624156/article/details/77455670) 部分排版有修改