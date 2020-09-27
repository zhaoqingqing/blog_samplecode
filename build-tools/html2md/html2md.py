# -*- coding:utf-8 -*-

'''

Desc：html convert to md,需要安装 html2markdown

Time: 2020/9/27 9:53

Author: qingqing-zhao(569032731@qq.com)

'''
import glob
import html2markdown
import sys
import os

#dir_path =r"E:\Code\blog_samplecode\build-tools\html2md\\"
dir_path =r".\\"

def Convert(src_path):
    file_name = os.path.basename(src_path)
    md_name = file_name.replace("html","md")
    with open(src_path, 'r', -1, encoding="utf-8") as sw:
        md_str = html2markdown.convert(sw)
        fo = open(md_name, "w")
        fo.write(md_str)
        fo.close()
        print("conver to {0} done.".format(md_name))

if __name__ == "__main__":
    for mdfile in glob.glob(dir_path + "*.html"):
         Convert(mdfile)
    input("Press Enter")     