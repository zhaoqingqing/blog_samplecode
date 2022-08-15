## Python反射常用的内置函数

- **type**(obj)：返回对象类型
- **isinstance**(object, classinfo)：判断一个对象是否是一个已知的类型，类似 type()
- **callable**(obj)：对象是否可以被调用
- **dir**([obj])：返回obj属性列表
- **getattr**(obj, attr)：返回对象属性值
- **hasattr**(obj, attr)：判断某个函数或者变量是否存在
- **setattr**(obj, attr, val)：给模块添加属性（函数或者变量）
- **delattr**(obj, attr)：删除模块中某个变量或者函数

## \__import__

比如在运行时才能确定的类型

<br/>

## getattr

可以通过getattr获取函数名，然后执行

在C#中想要动态执行一个函数，方法也是类似的，获取assembly，然后通过namespace - class 再通过方法名执行

## callable与判空的区别

```python
func = message_event.get(msg, None)
if callable(func):
   func()
#callable与这行有什么区别？
if func: func()
```

## 参考资料

[Python反射介绍 | HiYong (hiyongz.github.io)](https://hiyongz.github.io/posts/python-notes-for-reflection/)

[从Python对象的内建属性和方法谈Python的自省（Introspection）和反射机制（Reflection）_天元浪子的博客-CSDN博客](https://blog.csdn.net/xufive/article/details/107607562)
