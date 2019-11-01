### 数据类型

number，和lua一样

tuple元组，和python一样

any 可以表示不确定的类型





当你指定了`--strictNullChecks`标记，`null`和`undefined`只能赋值给`void`和它们各自。 这能避免 *很多*常见的问题。

### 关于`let`

你可能已经注意到了，我们使用`let`关键字来代替大家所熟悉的JavaScript关键字`var`。 `let`关键字是JavaScript的一个新概念，TypeScript实现了它。 我们会在以后详细介绍它，很多常见的问题都可以通过使用`let`来解决，所以尽可能地使用`let`来代替`var`吧。