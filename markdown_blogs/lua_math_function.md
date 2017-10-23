  **ua5.1**中数学库的所有函数如下表：                     	    	    	    
​                                         	    	    	    
  math.pi 为圆周率常量 = 3.14159265358979323846	    	    	    

| 函数名        | 函数功能                                   | 示例                           | 示例结果                             |
| ---------- | -------------------------------------- | ---------------------------- | -------------------------------- |
| abs        | 取绝对值                                   | math.abs(-15)                | 15                               |
| acos       | 反余弦函数                                  | math.acos(0.5)               | 1.04719755                       |
| asin       | 反正弦函数                                  | math.asin(0.5)               | 0.52359877                       |
| atan2      | x / y的反正切值                             | math.atan2(90.0, 45.0)       | 1.10714871                       |
| atan       | 反正切函数                                  | math.atan(0.5)               | 0.463647609                      |
| ceil       | 不小于x的最大整数                              | math.ceil(5.8)               | 6                                |
| cosh       | 双曲线余弦函数                                | math.cosh(0.5)               | 1.276259652                      |
| cos        | 余弦函数                                   | math.cos(0.5)                | 0.87758256                       |
| deg        | 弧度转角度                                  | math.deg(math.pi)            | 180                              |
| exp        | 计算以e为底x次方值                             | math.exp(2)                  | 2.718281828                      |
| floor      | 不大于x的最大整数                              | math.floor(5.6)              | 5                                |
| fmod （mod） | 取模运算                                   | math.mod(14, 5)              | 4                                |
| frexp      | 把双精度数val分解为数字部分（尾数）和以2为底的指数n，即val=x*2n | math.frexp(10.0)             | 0.625    4                       |
| ldexp      | 计算value * 2的n次方                        | math.ldexp(10.0, 3)          | 80 = 10 * (2 ^3)                 |
| log10      | 计算以10为基数的对数                            | math.log10(100)              | 2                                |
| log        | 计算一个数字的自然对数                            | math.log(2.71)               | 0.9969                           |
| max        | 取得参数中最大值                               | math.max(2.71, 100, -98, 23) | 100                              |
| min        | 取得参数中最小值                               | math.min(2.71, 100, -98, 23) | -98                              |
| modf       | 把数分为整数和小数                              | math.modf(15.98)             | 15    98                         |
| pow        | 得到x的y次方                                | math.pow(2, 5)               | 32                               |
| rad        | 角度转弧度                                  | math.rad(180)                | 3.141592654                      |
| random     | 获取随机数                                  | math.random(1, 100)          | 获取1-100的随机数                      |
| randomseed | 设置随机数种子                                | math.randomseed(os.time())   | 在使用math.random函数之前必须使用此函数设置随机数种子 |
| sinh       | 双曲线正弦函数                                | math.sinh(0.5)               | 0.5210953                        |
| sin        | 正弦函数                                   | math.sin(math.rad(30))       | 0.5                              |
| sqrt       | 开平方函数                                  | math.sqrt(16)                | 4                                |
| tanh       | 双曲线正切函数                                | math.tanh(0.5)               | 0.46211715                       |
| tan        | 正切函数                                   | math.tan(0.5)                | 0.5463024                        |

以上内容摘自：https://www.cnblogs.com/whiteyun/archive/2009/08/10/1543040.html

