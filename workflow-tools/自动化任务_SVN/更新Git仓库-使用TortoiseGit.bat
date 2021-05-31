rem TortoiseGit命令行更新多个不同的git库,每次更新会弹出窗口分支确认窗口

@echo off
@echo ================自动更新git Start===============
rem tortoisegit安装目录
SET svn_home=C:\Program Files\TortoiseGit\bin

rem git repo目录(请修改对应的目录)
SET blog_samplecode=E:\Code\blog_samplecode
SET code_snippetE:\Code\code_snippetE
SET unity_study=E:\Code\unity_study
SET python_study=E:\Code\python_study

rem 执行tortoisegit更新命令,更新对话框不自动关闭
"%svn_home%"\TortoiseGitProc.exe/command:pull /path:"%blog_samplecode%*%code_snippet%" /notempfile /closeonend:0

echo ==============自动更新git Finish==============