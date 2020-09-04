# -*- coding:utf-8 -*-

'''

Desc：修改git仓库中的文件日期为提交时间
我的环境：gitpython版本3.1.7，安装 pip install GitPython
参考：https://stackoverflow.com/questions/13104495/get-time-of-last-commit-for-git-repository-files-via-python
Time: 2020/9/1 19:52

Author: qingqing-zhao(569032731@qq.com)

'''

import os
import sys
import git
import time

dir_path = r"E:\Code\blog_samplecode"
#dir_path = r"E:\Code\BlogHelper"

if __name__ == "__main__":

    # try:
    if not os.path.exists(dir_path):
        print("not exist dir", dir_path)

    repo = git.Repo(dir_path)
    repo = git.Repo.init(dir_path)
    tree = repo.tree()  # 这里只会返回根目录下的所有文件，如果是文件夹，则从blobs中取数据
    commit = repo.commit()
    print(commit.tree.traverse())
    for blob in commit.tree.traverse():
        if str.find(blob.abspath, "markdown_blogs") <= 0:
            # print("jump ",blob.abspath," ,dir_name:",blob.path)
            continue
        commit = repo.iter_commits(paths=blob.path).__next__()
        if os.path.isfile(blob.abspath):
            ts = time.strftime("%Y-%m-%d %H:%M", time.localtime(commit.committed_date))
            print("update ",blob.path, ts)
            os.utime(blob.abspath, (commit.committed_date,commit.committed_date))

    input("Finish .Press Any Key ... ")

    #     print(ex)
    # finally:
    #     print("execute end")
