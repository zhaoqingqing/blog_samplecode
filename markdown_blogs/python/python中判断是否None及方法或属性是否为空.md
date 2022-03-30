## 判断是否None要用is

python中的None是一个独立的类型，可以理解为其他编程语言的 null、nil 或 undefined，要判断一个对象是否None，通过 if xx is None，这样得到的结果才是正确的。

如果通过 if xx == None 或 if not xx 在一些其它情况下并不能判断出是否为真正的None



## python判断tuple、list、dict是否为空

if not xxx:即可判断 tuple、list、dict 的内容是否为空 ，这点和C#中的null是有很大区别的。



```python
list_test = []
if not list_test:
    pass # 因为list内容为空，不成立

if list_test is None:
    pass # list也不是None

# 其它的tuple和dict都是适用的

```

## 判断一个属性或方法是否存在

```python
# 判断某个属性是否存在
if hasattr(self.panel,"xxx")

#获取某个属性，记得添加最后一个None，找不到就使用默认值
if getattr(self.panel,"xxx",None)
```

