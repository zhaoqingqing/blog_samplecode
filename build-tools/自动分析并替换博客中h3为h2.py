"""
Author: qingqing-zhao(569032731@qq.com)
Date: 2020/4/26 22:42
Desc:
"""
# -*- coding: utf-8 -*-
import os
import logging

blog_path = r'E:\Code\blog_samplecode\markdown_blogs'
test_blog = r'E:\Code\blog_samplecode\markdown_blogs\LoopScrollRect循环滑动列表不卡顿.md'


# str_log = ""
# def log(str):


# 分析blog

def analysisBlog(file):
    with open(file,'r',-1,encoding="utf-8") as sw:
        h2_num = 0
        if sw:
            print("本篇blog中h1~h6如下：")
            for line in sw:
                if line.startswith("#"):
                    print(line)
                if line.startswith("##") and not line.startswith("###"):
                    h2_num +=1
            sw.close();

            # 如果整篇文章中没有一处h2，则自动进行替换，否则手动处理
            if h2_num <=0:
                print("本篇没有h2标签可以自动处理")
                print("========== begin 执行替换操作###->## ========")
                str_blog = ""
                num = 0
                with open(file, 'r', -1, encoding="utf-8") as sw:
                    for line in sw:
                        if line.startswith("###"):
                            line = line.replace("###", "##")
                            num += 1
                        str_blog += line

                #执行写入操作
                with open(file,"w",encoding="utf-8") as sw:
                    sw.write(str_blog)
                print("========== end 执行完毕，共替换{0}个 ========".format(num))

            else:
                print("此篇有{0}个h2标签，请手动处理".format(h2_num))

if __name__ =="__main__":
    analysisBlog(test_blog)