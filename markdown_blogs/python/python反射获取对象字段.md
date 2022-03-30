## class

对于一个class，使用dir(xx)打印所有的方法

使用ins.\__dict__可以打印所有的字段名+值

如果有重写\___str__，那么在调用print(ins)时就会指向\__str__方法

## 扩展点

实际游戏项目内的自定义类型，非继承自object的，如何拿到所有的字段名？



## dict

而对于一个dict，如何获取所有的key，

```python
data={'comment': '\xd2\xbb\xb6\xce\xb2\xe2\xca\xd4\xb6\xcc\xc6\xc0-2021-10-19 17:26:34', 't_when': 1634635594, 'role': '\xc5\xcb\xc5\xcb\xcf\xeb\xcb\xaf\xbe\xf5', 'uuid': '2f077b78-fe3f-11eb-b9d2-525400da9cc3', 'storyid': 1, 'commentid': 'a7234432-30be-11ec-b552-525400da9cc3', '_id': '616e8f4a16d918028e042303', 'like': 0}
print data["t_when"],getattr(data,"t_when",None),data.keys()
```

## print的改进版

支持python2和python3：[gruns/icecream: 🍦 Never use print() to debug again. (github.com)](https://github.com/gruns/icecream)

国人开发的一个库 objprint：[objprint, 让你轻松打印python object - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/355996663)

## dir()

打印某个对象所有的方法

## help()

以文档的形式打印类型的用法，或者方法
