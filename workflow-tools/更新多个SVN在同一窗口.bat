rem 在同一个SVN窗口更新多个不同的SVN库
rem 文档：http://www.cnblogs.com/zhaoqingqing/p/4592063.html

@echo off
@echo ================自动更新SVN Start===============
rem SVN安装目录
SET svn_home=C:\Program Files\TortoiseSVN\bin

rem SVN项目目录(请修改对应的目录)
SET svn_work_code=X:\xxgame\xx_code_vn
SET svn_work_gameres=X:\xxgame\xx_scheme_vn
SET svn_work_product=X:\xxgame\xx_product_vn

@echo 正在更新目录 %svn_work_code%,%svn_work_gameres%,%svn_work_product%

rem 根据实际情况：excel和word如果打开状态，当更新时会起冲突，所以要把进程结束(区分wps或office进程)
rem taskkill /f /im et.exe 
rem taskkill /f /im wps.exe
rem Echo 杀死进程完毕

rem 执行SVN更新命令,更新对话框不自动关闭
"%svn_home%"\TortoiseProc.exe/command:update /path:"%svn_work_code%*%svn_work_gameres%*%svn_work_product%" /notempfile /closeonend:0

echo ==============自动更新SVN Finish==============