"""
Author: zhaoqingqing(569032731@qq.com)
Date: 2019/11/26 17:20$
Desc: 爬取王者荣耀全英雄皮肤壁纸，壁纸规则参考:https://zhuanlan.zhihu.com/p/93752180
壁纸分辨率为1920x882 单张大小在200kb左右
"""
import os
import requests
import json

save_path="d:\\王者荣耀全英雄皮肤壁纸\\" #保存路径
url = 'https://pvp.qq.com/web201605/js/herolist.json' #英雄列表文件
res = requests.get(url)  # 获取英雄列表json文件

# 下载图片
def downloadPic():
    if not os.path.exists(save_path):
        os.mkdir(save_path)

    hero_json = json.loads(res.text)
    for j in range(len(hero_json)):
        hero = hero_json[j]
        # 创建文件夹
        full_path = save_path + hero["cname"]
        if not os.path.exists(full_path):
            os.mkdir(full_path)
        # 进入创建好的文件夹
        os.chdir(full_path)
        if "skin_name" not in hero:
            print("英雄%s没有皮肤"%(hero["cname"]))
            return
        skins = hero["skin_name"].split("|")
        #备注：图片索引从1开始
        for k in range(len(skins)):
            # 拼接url
            onehero_link = 'http://game.gtimg.cn/images/yxzj/img201606/skin/hero-info/' + str(hero["ename"])+ '/' + str(hero["ename"]) + '-bigskin-' + str(k+1) + '.jpg'
            print(skins[k],onehero_link)
            save_name = skins[k]+".jpg"
            if not os.path.exists(save_name):
                im = requests.get(onehero_link)  # 请求url
                if im.status_code == 200:
                    open(skins[k] + '.jpg', 'wb').write(im.content)  # 写入文件
            else:
                print("%s已存在，跳过"%(save_name))
        print("%s皮肤壁纸共%s个\n" % (hero["cname"], len(skins)))

if __name__ =="__main__":
    downloadPic()
    os.startfile(save_path)
    print("下载完成")