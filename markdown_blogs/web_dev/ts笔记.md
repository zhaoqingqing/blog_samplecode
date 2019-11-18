### 数据类型

number，和lua一样

tuple元组，和python一样

any 可以表示不确定的类型





当你指定了`--strictNullChecks`标记，`null`和`undefined`只能赋值给`void`和它们各自。 这能避免 *很多*常见的问题。

### 关于`let`

你可能已经注意到了，我们使用`let`关键字来代替大家所熟悉的JavaScript关键字`var`。 `let`关键字是JavaScript的一个新概念，TypeScript实现了它。 我们会在以后详细介绍它，很多常见的问题都可以通过使用`let`来解决，所以尽可能地使用`let`来代替`var`吧。



### 定时器

setTimeout和setInterval

```ts
function setInterval(handler: TimerHandler, timeout?: number, ...arguments: any[]): number;

function setTimeout(handler: TimerHandler, timeout?: number, ...arguments: any[]): number;
```

setInterval 第二个参数：5000 表示延时，毫秒，5000毫秒=5秒，即执行完本次后，隔5秒再次执行

两个函数的主要区别在：setTimeout函数只会执行一次，而setInterval函数会反复执行。

查看《JavaScript 高级程序设计》，在某些情况下setInterval会被跳过，所以推荐使用链式setTimeout

### 推荐链式setTimeout

以下代码会每秒执行一次

arguments.callee会获取当前函数的引用

```ts
//推荐嵌套settimeout
function test(){
    console.log('hello ')
}
setTimeout(() => {
    test()
// @ts-ignore
    setTimeout(arguments.callee,1000);
    }, 1000);

```



