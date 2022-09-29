【中文】这两字在不同字符集编码如下：

- GBK编码：\xd6\xd0\xce\xc4

- UTF编码：\xe4\xb8\xad\xe6\x96\x87

为什么相同汉字长度看起来不一样？这是因为一个汉字在GBK编码占两个字节，而UTF-8占3个字节

在python2下可以直接打印gbk编码，而python3却是不行

```powershell
Python 2.7.18 (v2.7.18:8d21aa21f2, Apr 20 2020, 13:19:08) [MSC v.1500 32 bit (Intel)] on win32
Type "help", "copyright", "credits" or "license" for more information.
>>> print ('\xd6\xd0\xce\xc4')
中文
>>> print('\xe4\xb8\xad\xe6\x96\x87')
涓枃
>>> "中文".encode('gbk')
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
UnicodeDecodeError: 'ascii' codec can't decode byte 0xd6 in position 0: ordinal not in range(128)
>>> "中文".decode('gbk')
u'\u4e2d\u6587'
>>> '\xd6\xd0\xce\xc4'.decode('gbk')
u'\u4e2d\u6587'
>>> '\xd6\xd0\xce\xc4'.encode('gbk')
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
UnicodeDecodeError: 'ascii' codec can't decode byte 0xd6 in position 0: ordinal not in range(128)
>>>
```

从上面的输出也验证这者是等价的：\xd6\xd0\xce\xc4 == 中文

python3的输出如下：

```powershell
Python 3.8.10 (tags/v3.8.10:3d8993a, May  3 2021, 11:48:03) [MSC v.1928 64 bit (AMD64)] on win32
Type "help", "copyright", "credits" or "license" for more information.
>>> print('\xd6\xd0\xce\xc4')
ÖÐÎÄ
>>> \xe4\xb8\xad\xe6\x96\x87
  File "<stdin>", line 1
    \xe4\xb8\xad\xe6\x96\x87
                           ^
SyntaxError: unexpected character after line continuation character
>>> print('\xe4\xb8\xad\xe6\x96\x87')
ä¸­æ
```

## python dict内都是编码

如果要显示中文，建议用字符串拼接，而不要用dict。

```python
t={1:"中",2:"hi"} #打印结果 {1: '\xe4\xb8\xad', 2: 'hi'}
t2={1:"china",2:"hi"} #打印结果：{1:"china",2:"hi"}
```
