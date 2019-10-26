对于私有属性和方法添加__(双下划线)

但依旧可以通过暴力方法访问到：_类名__属性名，建议你不要这样做。

定义类

```python
# 类名首字母大写
class Student(object):
    """创建一个学生类"""
    # 没有属性定义，直接使用即可
    # 定义一个方法，方法里面必须有self（相当于C#的this）
    def show(self):
        print("name:%s age:%d"%(self.name,self.age))
        
# 实例化一个张三
zhangsan=Student()
# 给name，age属性赋值
zhangsan.name="张三"        
```



静态方法使用 `@staticmethod` 

```python
   # 静态方法
    @staticmethod
    def say_hello():
        print("hello")
        #test.xxx 访问本类属性
```

