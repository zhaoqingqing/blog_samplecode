## 请求网络资源

获取网络上的某个的资源，比如保存网上的图片

```python
link = 'https://www.cnblogs.com/images/logo_small.gif'
im = requests.get(link)  # 请求url
if im.status_code == 200:
	open('logo.jpg', 'wb').write(im.content)  # 写入文件
```

获取请求的内容

```python
url = 'https://pvp.qq.com/web201605/js/herolist.json' #英雄列表文件
res = requests.get(url)  # 获取英雄列表json文件
hero_json = json.loads(res.text)
```

## json解析

- **编码**：把一个**Python对象**编码转换成Json字符串   json.dumps()
- **解码**：把Json格式字符串解码转换成**Python对象**   json.loads()