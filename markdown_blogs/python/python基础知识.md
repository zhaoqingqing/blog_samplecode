python中需要特别注意代码的缩进，这是为了可读性，不像 C#，lua ( function do end)，js这样函数范围用{}g表示。

### 变量定义

不需要var 也不要写类型，直接写变量名

### 函数定义

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



### 代码注释

'#' 单行注释

""" 要注释的内容 “”“  多行注释，三个双引号连接



### 输入与输出

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



### 逻辑控制

If和elif后面加冒号:

没有++和--

end=

for else一般很少用，当for循环要退出时要加break



### 常用术语

tuple 元组 

<pre> 
__name__是Python中一个隐含的变量它代表了模块的名字
只有被Python解释器直接执行的模块的名字才是__main__
if __name__ == '__main__':
</pre>





建议参考文章： 

[Python3 与 C# 基础语法对比（就当Python和C#基础的普及吧）](https://www.cnblogs.com/dotnetcrazy/p/9102030.html)

[Python-100-Days](https://github.com/jackfrued/Python-100-Days)

(基础部分看到Day01-15就可以，进阶部分可以选择性看)