## cmp

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

## 按key排序

python按key排序，如果要按多个key且按优先级来排，可以像这样写

```python
def sortFunc(value):
	isOldClan = value.get('old', '')#老牌势力
	quality = value.get('quality', 0) # 势力质量
	people = value.get('people', 0) # 势力人数
	open = value.get('open', 0) # 0不接收任何人加入
	return (open,isOldClan, people, quality)

sortedData = sorted(clanData, key=sortFunc, reverse=True)
```



## 排在最前面

对于想把某个数排在最前面，我建议不要用排序了，直接从列表中删除它，再往首位添加才是最快的。因为我试了很多排序方法都没法达到。
