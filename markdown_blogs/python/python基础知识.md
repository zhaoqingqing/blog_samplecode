## 前言

python中需要特别注意代码的缩进，这不是为了可读性而是正确性，不像 C#，lua ( function do end)，js等语言的函数范围用{}表示。

对于判断是否包含尽量使用in，而不使用for，具体参考：《Python编程惯例.md》

## Non-ASCII character

python报错“Non-ASCII character '\xe5' ”

解决方法：

在Python源文件的最开始一行，加入一句

```python
# coding=UTF-8
#或者
# coding:UTF-8 --
```

(手册链接：https://docs.python.org/3.5/whatsnew/3.0.html#pep-3101-a-new-approach-to-string-formatting)

python 2.x 不默认支持 UTF-8 编码，而 python 3.x 默认支持 UTF-8 编码。

## 变量定义

不需要var 也不要写类型，直接写变量名，全局和局部变量都不需要写类型

**变量的定义需要放在使用的前面**，可以理解为像C那样顺序执行的，而不像C#。

假如全局和局部名相同，而要特殊声明使用的是全局变量，则在变量明名前加上 global

```python
x = 100
def func():
    global x
    print(x)
    x = 2
    print(x)
func()
print(x)

```

输出结果为：

100 2 2

关于变量的详细可参考这篇文章《[python变量（全局、局部）：global、nonlocal、locals](https://blog.csdn.net/weixin_43178406/article/details/96478339)》

## 函数定义

```python
def 函数名:
	函数内容
```

**返回值**

```python
def sum(a,b):
    return a+b,a-b

test1,test2=sum(2,1)
print(test1,test2)
#输出 3 1
```

多返回值，通过，分隔，这点用lua的写法一样

**可变参数**

或者定义成如下： def add(*args):

```python
#可变参数
def calcTotal(nums):
    total = 0;
    for num  in nums:
        total = total + num
    return total

print(calcTotal((1,2,3)))

#输出 6
```



## 代码注释

```python
# 单行注释

""" 要注释的内容
多行注释，三个双引号连接
""" 
```





## 输入与输出

```python
name=input("请输入帐号")
pwd=input("请输入密码")
print("name:%s,pwd:%s"%(name,pwd))
#输出
请输入帐号111
请输入密码222
name:111,pwd:222

#用空格连接
print(name,pwd)
111 222
#输出
```

【**注意引号后面没有，也没有空格**】

转义字符后接 %()

## 数据结构-dict 

判断字典中不存在key

```python
if "skin_name" not in hero:
    print("数据异常")
    return
```

## 数据结构-list

遍历列表

```python
for k in range(len(skins)):
```

## 逻辑控制

If和elif后面加冒号:

没有++和--



for else一般很少用，当for循环要退出时要加break

## for循环

```python
for i in range (0,2):
    print(i)#打印0,1
```



## 类

python类中的方法，需要传入self，这点和原生的Lua是一样的。

## py文件执行完不直接退出

在python文件的未尾添加一行输入符，等待用户按下任意键才会退出

## python执行

python test.py 和python -m test.py 这两者的区别？

直接运行会将该脚本所在目录添加至`sys.path`
当做模块启动则会将当前运行命令的路径添加至`sys.path`

## end=

end=，对于文本中文字本来就是有换行的，如果想在输出时不换行，可以写end=""，如果不加，那么会多出换行

```python
filepath = r'E:\Code\test.txt'
with open(filepath, mode="r", encoding="utf-8") as f:
    for line in f:
        print(line)

"""
不加 end=""
第一行

第二行

共三行
"""

"""
加上end=""
第一行
第二行
共三行
"""
```



## 常见代码

tuple 元组 

<pre> 
__name__是Python中一个隐含的变量它代表了模块的名字
只有被Python解释器直接执行的模块的名字才是__main__
if __name__ == '__main__':
</pre>


善于使用in运算符。

```Python
if x in items: # 包含
for x in items: # 迭代
```

in的使用示例：

```Python
name = 'Hao LUO'
if 'L' in name:
    print('The name has an L in it.')
```



## 参考资料

[Python3 与 C# 基础语法对比（就当Python和C#基础的普及吧）](https://www.cnblogs.com/dotnetcrazy/p/9102030.html)

[Python-100-Days](https://github.com/jackfrued/Python-100-Days)     (基础部分看到Day01-15就可以，进阶部分可以选择性看)