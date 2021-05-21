rem 此方法在我的电脑上每次都是会完整的拉取整个库，还是使用svn吧，参考：https://www.jianshu.com/p/74a0441ed9b7

cd %~dp0

git init

git remote add -f origin https://github.com/zhaoqingqing/blog_samplecode.git

git config core.sparsecheckout true

echo markdown_blogs/python/* >> .git/info/sparse-checkout

git pull origin master
 
pause