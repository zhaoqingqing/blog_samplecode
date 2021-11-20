平时判断对象是否为空，使用if not xx:就可以了。

在print中判断界面是否为空：xx is not None

```python
def printDebug(*arg):
	if XXEngine.isPublishedVersion():
		return
	is_me = os.getenv("is_me")
```



```
 class Test():
    # def __bool__(self):
    #     return False   #不能返回整形，
    def __len__(self):
        return 0   #可以返回int和布尔值（特例）
```

python中的None是一个独立的类型，可以理解为其他编程语言的 null、nil 或 undefined

参考资料：

[深入理解Python中的None - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/65193194)



# python判断tuple、list、dict是否为空

if not xxx:即可判断 tuple、list、dict 是否 **为空** ，而直接使用if xxx则会判断失败。

测试代码：

```python
tuple_test = ()
assert not tuple_test

list_test = []
assert not list_test

dict_test = {}
assert not dict_test
```

