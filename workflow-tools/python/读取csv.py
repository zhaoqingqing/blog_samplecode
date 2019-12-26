# coding:utf-8
import csv
# 读取csv文件方式1
csvFile = open("csvData.csv", "r")
reader = csv.reader(csvFile) # 返回的是迭代类型
data = []
for item in reader:
  print(item)
  data.append(item)
print(data)
csvFile.close()
# 读取csv文件方式2
with open("csvData.csv", "r") as csvfile:
  reader2 = csv.reader(csvfile) # 读取csv文件，返回的是迭代类型
  for item2 in reader2:
    print(item2)
csvFile.close()
# 从列表写入csv文件
csvFile2 = open('csvFile2.csv','w', newline='') # 设置newline，否则两行之间会空一行
writer = csv.writer(csvFile2)
m = len(data)
for i in range(m):
  writer.writerow(data[i])
csvFile2.close()
# 从字典写入csv文件
dic = {'张三':123, '李四':456, '王二娃':789}
csvFile3 = open('csvFile3.csv','w', newline='')
writer2 = csv.writer(csvFile3)
for key in dic:
  writer2.writerow([key, dic[key]])
csvFile3.close()