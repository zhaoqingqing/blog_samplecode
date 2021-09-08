#! python2
# -*- coding: UTF-8 -*-
"""
感谢nickchen121的脚本，开源地址(https://github.com/nickchen121/cnblogs_automatic_blog_uploading)
原理：使用python 基于 xmlrpc 调用metaweblog API 发送内容到博客园
查看支持的metaweblog API：http://rpc.cnblogs.com/metaweblog/
博客园限制，不能连续不断的发表，所以使用threading间隔60S发一次。
NOTE: 文章从目录中发布正式或草稿后，会删除原文件，所以需要对源md文件进行备份
cnblog2.py work in python2 , cnblog.py work in python3
	1. 61行打开文件会报错
	2.json.dump({},f)报错：TypeError: write() argument 1 must be unicode, not str
"""

import  xmlrpclib
import glob
import os
import sys
import json
import time
import datetime
import ssl
import io
from io import open

ssl._create_default_https_context = ssl._create_unverified_context

# 使用相对路径
# 发布为正式文章
path_publish = "./article_publish/"
# 发布到草稿箱
path_draft = "./article_draft/"
# 博客配置文件
path_cfgfile = "./blog_config.json"
# 备份路径
path_backup = "./article_backup/"
# 获取最近发布文章篇数(经测试数量>=10则出现获取内容解析异常)
recentnum = 150

# -----配置读写操作-----
'''
配置字典：
type | description(example)
str  | metaWeblog url, 博客设置中有('https://rpc.cnblogs.com/metaweblog/zhaoqingqing')
str  | appkey, Blog地址名('zhaoqingqing')
str  | blogid, 这个无需手动输入，通过getUsersBlogs得到
str  | usr, 登录用户名
str  | passwd, 登录密码
'''

import codecs
import warnings

#在py2中兼容py3的写法
def open(file, mode='r', buffering=-1, encoding=None,
		 errors=None, newline=None, closefd=True, opener=None):
	if newline is not None:
		warnings.warn('newline is not supported in py2')
	if not closefd:
		warnings.warn('closefd is not supported in py2')
	if opener is not None:
		warnings.warn('opener is not supported in py2')
	return codecs.open(filename=file, mode=mode, encoding=encoding,
					   errors=errors, buffering=buffering)

def exist_cfg():
	'''
	返回配置是否存在
	'''
	try:
		with open(path_cfgfile, "r", encoding="utf-8") as f:
			try:
				cfg = json.load(f)
				if cfg == {}:
					return False
				else:
					return True
			except json.decoder.JSONDecodeError:  # 文件为空
				return False
	except:
		with open(path_cfgfile, "w", encoding="utf-8") as f:
			t1=f.read()
			t2=t1.decode('utf-8')
			json.dump({}, f)#f.read().decode('utf-8'))
			return False


def create_cfg():
	'''
	创建配置
	'''
	while True:
		cfg = {}
		for item in [("url", "metaWeblog url, 博客设置中有\
			('https://rpc.cnblogs.com/metaweblog/blogaddress')"),
					 ("appkey", "Blog地址名('blogaddress')"),
					 ("usr", "登录用户名"),
					 ("passwd", "登录密码")]:
			cfg[item[0]] = input("输入" + item[1])
		try:
			server = xmlrpclib.ServerProxy(cfg["url"])
			userInfo = server.blogger.getUsersBlogs(
				cfg["appkey"], cfg["usr"], cfg["passwd"])
			print(userInfo[0])
			# {'blogid': 'xxx', 'url': 'xxx', 'blogName': 'xxx'}
			cfg["blogid"] = userInfo[0]["blogid"]
			break
		except:
			print("发生错误！")
	with open(path_cfgfile, "w", encoding="utf-8") as f:
		json.dump(cfg, f, indent=4, ensure_ascii=False)


url = appkey = blogid = usr = passwd = ""
server = None
mwb = None
title2id = {}


def get_cfg():
	'''
	初始化文章参数
	'''
	global url, appkey, blogid, usr, passwd, server, mwb, title2id
	with open(path_cfgfile, "r", encoding="utf-8") as f:
		cfg = json.load(f)
		url = cfg["url"]
		appkey = cfg["appkey"]
		blogid = cfg["blogid"]
		usr = cfg["usr"]
		passwd = cfg["passwd"]
		server = xmlrpclib.ServerProxy(url)
		mwb = server.metaWeblog
		print ("init blogid:{},usr:{},recentnum:{},url:{}".format(blogid, usr, recentnum, url))

#在python2中弃用掉保存最近发表文章,因为open失败了
def save_last():
	#储存博客中文章标题对应的postid
	recentPost = mwb.getRecentPosts(blogid, usr, passwd, recentnum)
	for post in recentPost:
		#print("最近发布文章为:",post["title"])
		# 1.把datetime转成字符串
		dt = post["dateCreated"]
		# post["dateCreated"] = dt.strftime("%Y%m%dT%H:%M:%S")
		post["dateCreated"] = dt.__str__()
		# 2.把字符串转成datetime
		# datetime.datetime.strptime(st, "%Y%m%dT%H:%M:%S")
		# datetime.datetime.fromisoformat(str)
		title2id[post["title"]] = post["postid"]
	# 保存最近发布内容到文件中，文件名：20160320-114539
	# filename = time.strftime("%Y%m%d-%H%M%S", time.localtime())
	# with open(path_backup + filename + ".json", "w", encoding="utf-8") as f:
		# json.dump(recentPost, f, indent=4 ,ensure_ascii=False)

def newPost(blogid, usr, passwd, post, publish):
	while True:
		try:
			postid = mwb.newPost(blogid, usr, passwd, post, publish)
			break
		except BaseException as e:
			#发布失败
			print ("newPost error ,",e) #Request from client does not contain valid XML
			time.sleep(5)
	return postid

#已经发布的不会重复发布，且未发布目录内容如果为空，会报TypeError: cannot unpack non-iterable NoneType object
def post_art(path, publish=True):
	print ("dopost 1,path={} ,publish={}".format(path,publish))
	title = os.path.basename(path)  # 获取文件名做博客文章标题
	[title, _] = os.path.splitext(title)  # 去除扩展名
	with open(path, "r", encoding="utf-8") as f:
		post = dict(description=f.read(), title=title)
		post["categories"] = ["[Markdown]"]
		succcess= False
		# 判断是否发布
		if not publish:  # 不发布
			# 对于已经发布的文章，直接修改为未发布会报错：
			# xmlrpc.client.Fault: <'published post can not be saved as draft'>
			# 所以先删除这个文章
			# if title in title2id.keys():
			#     server.blogger.deletePost(appkey, title2id[title], usr, passwd, True)
			print ("dopost 2-1")
			if title not in title2id.keys():
				post["categories"].append('[随笔分类]unpublished')  # 标记未发布
				postid = newPost(blogid, usr, passwd, post, publish) #fuck! py2下此接口一直没回包

				print("New Draft:[title=%s][postid=%s][publish=%r]" %(title, postid, publish))
			else:
				postid = title2id[title]
				succcess = mwb.editPost(title2id[title], usr, passwd, post, publish)
				print("Update Draft:[success=%s][title=%s][postid=%s][publish=%r]" % (succcess,title, title2id[title], publish))

			f.close()
			if not postid.strip == "" :
				filepath_ = os.path.join(path_draft, title + '.md') # f在py2不支持
				os.remove(filepath_)
			else:
				print("Send Draf Faild")

			return (title, postid, publish)
		else:  # 发布
			print ("dopost 2-2")
			if title in title2id.keys():  # 博客里已经存在这篇文章
				postid = title2id[title]
				succcess = mwb.editPost(title2id[title], usr, passwd, post, publish)
				print("Update:[success=%s][title=%s][postid=%s][publish=%r]" %(succcess,title, title2id[title], publish))

			else:  # 博客里还不存在这篇文章
				postid = newPost(blogid, usr, passwd, post, publish)
				print("New:[title=%s][postid=%s][publish=%r]" %(title, postid, publish))

			f.close()
			if succcess or (not postid.strip == ""):
				filepath_ = os.path.join(path_publish, title + '.md')
				os.remove(filepath_)
			else:
				print("Send Publish Faild")

			return (title, postid, publish)


def download_art():
	"""下载文章"""
	# 获取最近文章，并获取所有文章信息
	recentPost = mwb.getRecentPosts(blogid, usr, passwd, recentnum)
	for post in recentPost:
		if "categories" in post.keys():
			if '[随笔分类]unpublished' in post["categories"]:
				with open(path_draft + post["title"] + ".md",
						  "w", encoding="utf-8") as f:
					f.write(post["description"])
		else:
			with open(path_publish + post["title"] + ".md",
					  "w", encoding="utf-8") as f:
				f.write(post["description"])


def send_draft():
	'''
	发布到草稿箱
	'''
	for mdfile in glob.glob(path_draft + "*.md"):#py2环境在pycharm中输出中文文件名为乱码，但在powershell下又是正常的
		# print mdfile
		# print unicode(mdfile,'utf-8')
		title, postid, publish = post_art(mdfile, False)

def send_article():
	'''
	发布正式文章
	'''
	for mdfile in glob.glob(path_publish + "*.md"):
		title, postid, publish = post_art(mdfile, True)
		title_postid_dict[title] = postid

if __name__ == "__main__":
	default_encoding = 'utf-8'
	if sys.getdefaultencoding() != default_encoding:
		reload(sys)
		sys.setdefaultencoding(default_encoding)
		print ("set encoding to utf-8")

	# 创建路径 TODO py2不会创建新目录
	for path in [path_publish, path_draft, path_backup]:
		if not os.path.exists(path):
			os.makedirs(path)

	title_postid_dict = dict()

	try:
		# 创建用户配置
		if not exist_cfg():
			create_cfg()

		# 获取文章参数
		get_cfg()

		# 配置用户参数
		if len(sys.argv) > 1:
			print ("do action:{}".format(sys.argv[1]))
			if sys.argv[1] == "download":
				download_art()
			elif sys.argv[1] == "config":
				create_cfg()
				get_cfg()
			elif sys.argv[1] == "unpublished":
				send_draft()
			elif sys.argv[1] == "publish":
				send_article()
			else:
				send_draft()
				# send_article()
		else:#开发环境下调试
			print ("do action dev env")
			send_draft()
			# send_article()

	except BaseException as e:
		#保存操作日志
		# with open('title_postid.json', 'w', encoding='utf8') as fw:
		#     json.dump(title_postid_dict, fw ,ensure_ascii=False)
		print ("error:",e)
	# with open('title_postid.json', 'w', encoding='utf8') as fw:
	#     json.dump(title_postid_dict, fw , ensure_ascii=False)
