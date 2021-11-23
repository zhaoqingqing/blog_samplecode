## PyCharm中新建python文件的模板

用途：每次在pycharm中新建python文件时，在新建文件中带上特定的信息，比如公司信息或作者信息。

1. 在Pycharm中按快捷键 **Ctrl+Alt+S**，打开Settings
2. **File**——**Settings**——**Editor**——**File and Code Templates**——**Python Script**，粘贴下面内容

```python
# -*- coding:utf-8 -*-
"""
@Author: qingqing.zhao(569032731@qq.com)
@Time: ${DATE} ${TIME}
@Desc：${NAME}
"""
class ${NAME}(object):
	def __init__(self):
        pass
```

3. 按快捷键 **Alt+Insert**，选择**Python File**即可新建一个Python文件

## 更多预定义变量

```shell
${PROJECT_NAME} - 当前项目的名称。
${NAME} - 在文件创建过程中在“新建文件”对话框中指定的新文件的名称。
${USER} - 当前用户的登录名。
${DATE} - 当前的系统日期。
${TIME} - 当前系统时间。
${YEAR} - 今年。
${MONTH} - 当月。
${DAY} - 当月的当天。
${HOUR} - 目前的小时。
${MINUTE} - 当前分钟。
${PRODUCT_NAME} - 将在其中创建文件的IDE的名称。
${MONTH_NAME_SHORT} - 月份名称的前3个字母。 示例：一月，二月等
${MONTH_NAME_FULL} - 一个月的全名。 示例：一月，二月等
```

