"""
Author: zhaoqingqing(569032731@qq.com)
Date: 2021/5/19 14:13
Desc:删除当前目录及其子目录下所有的meta文件
    在python3.7.4+win10下测试通过
"""

# coding=utf-8
import os
import sys


if __name__ == "__main__":
    try:
        print("参数列表：", str(sys.argv))
        start_path = sys.argv[0]
        # start_path = r'E:\Code\art_data\\'
        start_path = os.path.abspath(os.path.dirname(start_path))
        print("正在检查目录下的文件",start_path)
        if not os.path.exists(start_path):
            print("目录不存在，程序退出", start_path)
            # return
        else:
            del_count = 0
            for fpathe, dirs, fs in os.walk(start_path):
                #NOTE 这里忽略不了目录
                # for dir in dirs:
                #     if ignoreDirs and ignoreDirs.index(dir) >= 0:
                #         print("忽略目录", dir)
                #         continue
                for f in fs:
                    filepath = os.path.join(fpathe, f)
                    dir = os.path.dirname(filepath)
                    if dir.endswith(".git"):
                        continue
                    if os.path.isfile(filepath):
                        file_name, file_type = os.path.splitext(filepath)
                        if len(file_type) > 0 and file_type.endswith(".meta"):
                            print("正在删除", filepath)
                            del_count=del_count+1
                            os.remove(filepath)
            print("共删除{0}个文件".format(del_count))

    except Exception as ex:
        print
        'Exception:\r\n'
        print
        ex
    os.system("pause")
