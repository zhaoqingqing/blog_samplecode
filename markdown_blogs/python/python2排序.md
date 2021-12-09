示例：

```python
sorted(xxlist, cmp=self.sortFunc)
def sortFunc(self, a, b):
    return a - b
```

返回值代表的顺序和lua与C#是一致的，可见我之前的博客《[c#_sort排序函数的返回值 - 赵青青 - 博客园 (cnblogs.com)](https://www.cnblogs.com/zhaoqingqing/p/11760117.html)》

| 值     | 含义              |
| ------ | ----------------- |
| 小于零 | left在right的前面 |
| 零     | 位置不变          |
| 大于零 | right在left的前面 |



不过在python3却丢弃掉这这种用法了。



对于想把某个数排在最前面，我建议不要用排序了，直接从列表中删除它，再往首位添加才是最快的。因为我试了很多排序方法都没法达到。
