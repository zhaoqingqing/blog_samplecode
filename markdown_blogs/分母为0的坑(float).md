### 分母不能为0

对于int 类型，如果分母为0，在程序运行时，会报错。

而对于float 类型，如果分母为0，则不会报错，而是会返回一个infinity(无穷大)，也就是NAN。

因为除一个无穷小的数，返回一个无穷大的值。



对于百分比的运算，因为一般在计算时，都会转成float，要注意这个坑。

示例

```c#
float percent = (float) current/ (float)total;
```

正确示例

```c#
float percent = 1;
if(total>0){
	 percent = (float) current/ (float)total;
}
```

