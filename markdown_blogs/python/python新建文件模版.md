## PyCharm设置python文件创建模板

1. 在Pycharm中按快捷键Ctrl+Alt+S进入Settings

2. File——Settings——Editor——File and Code Templates——Python Script，填入下列内容

3. 按Alt+Insert选择Python File即可新建一个Python文件

```python
# -*- coding:utf-8 -*-

'''

Desc：${NAME} 

Time: ${DATE} ${TIME}

Author: qingqing-zhao(569032731@qq.com)

'''
```

更多可以选填的内容

```
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

