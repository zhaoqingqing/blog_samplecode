### 组合优于继承

ecs的概念很早就有了，最初的主要目的应该还是为了改善设计。

e-c-s三者都有其意义，e-c是组合优于继承，主要用以改善oo的继承耦合过重以及多继承菱形问题。

 oop常见设计里，每个gameobject有父类，子类继承来实现不同类型的对象，很容易产生过多\过深的继承以及多继承，而这两者理论上都不好（依赖、冗余），

继承更应该用来隔离接口与实现（父类提供接口，子类提供实现，调用方只关心父类接口，不关心具体子类实现），而不是用来重用父类的代码。 

<br/>

### Entity抽象成容器

e-c里gameobject是entity，只是个类似容器的抽象概念，entity里包含的component决定了对象是什么

component可以给不同的gameobject重用，通过组合多种component而不是继承来构造不同的对象。

<br/>

### Unity中的EC

unity一直以来都是component based，可以看成e-c，此外还有很多现代引擎也是e-c（ue、cryengine等）.

  对同一类型的component，通常会进行相同的操作(比如用render组件进行渲染)，一个直观的想法就是把这些操作集中在一起，就是system。

一个理想的设计里，包含多种不同的system，每个system只处理一个类型的component，每帧对所有compoent实例进行相同的操作，继而可以做到数据和逻辑分离，component里放纯数据，逻辑在system里。

<br/>

### ECS的好处有几个

1. 逻辑集中在system里，职责单一，读\改\控制（初始化、顺序依赖等等）都方便。 

2. 容易扩展，很容易新增e\c\s. 新增任何entity，这些entity上有各种component，这些component可以（自动）共享现有的system，不需要单独写。 

3. 灵活，e-c-s之间，s-s之间，e-e之间，c-c之间耦合较松，便于读\改\扩展。理想情况下不同的system之间，不同的compoent之间没有任何依赖，但通常很难做到。

4. cache friendly, system会连续对同一类component进行操作，保证了时间上的局部性（连续性），如果这些component能保证空间上的局部性（内存布局连续），则显而易见对缓存是很友好的。

 5. simd, 如果能保证同一个system对大量compoent实例的操作顺序无关，那么很自然的可以并发。 但实际中，component很难完全独立，经常需要和其它component进行交互，也就是system很难做到只负责一类component，通常需要和多种component(甚至其它系统）进行交互，交互的开销，遍历compoent的开销都需要考虑。 

摘自：a(704757217)