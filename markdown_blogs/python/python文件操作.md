记录在我使用python过程中用到的文件操作，我使用python主要是用来解决自动化的问题，不仅仅是工作上的问题也有解决我自己自动化的工具，python是可以跨平台的而bat脚本只能在windows上跑

## 路径转义符

对于路径中含有转义字符，在路径字符串前加 r，比如 `filepath = r'E:\Code\test.txt'`

从相对路径或含../的路径获取完整路径： `os.path.abspath(xxx)`

## 文本读取和修改

使用默认的系统函数 open，并添加encoding，使用with 代替try finally 切保一定会调用close释放文件，示例

```python
    with open(test_blog,'r',-1,encoding="utf-8") as sw:
```

逐行读取并替换内容

```python
def alter(file,old_str,new_str):
    """
    替换文件中的字符串
    :param file:文件名
    :param old_str:就字符串
    :param new_str:新字符串
    :return:
    
    """
    file_data = ""
    with open(file, "r", encoding="utf-8") as f:
        for line in f:
            if old_str in line:
                line = line.replace(old_str,new_str)
            file_data += line
    with open(file,"w",encoding="utf-8") as f:
        f.write(file_data)
 
alter("file1", "09876", "python")
```

### 写入内容

```python
# 打开一个文件
fo = open("foo.txt", "w")
fo.write( "www.runoob.com!\nVery good site!\n")
 
# 关闭打开的文件
fo.close()
```



参考：  [python-修改文件内容并保存的3种方法](https://blog.csdn.net/qq_30068487/article/details/90297814)

## 文件和目录操作

创建文件夹：`os.mkdir`

文件拷贝：`shutil.copyfile(src_fullpath, path_name)`

删除文件：`os.remove(file_name)`

python调用资源管理器打开某个文件夹：`os.startfile(full_path)`

进入某个目录，此后的操作是在这个目录下：`os.chdir(full_path)`

### 文件夹拷贝

如果目录存在需要先删除，否则会报目录不为空不可访问

```python
if os.path.exists(dst_path):
	print("exist path,delete", dst_path)
	shutil.rmtree(dst_path)

shutil.copytree(src_path, dst_path)
```

