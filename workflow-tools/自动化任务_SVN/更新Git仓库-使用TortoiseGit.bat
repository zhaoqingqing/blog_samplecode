rem 在TortoiseGit中更新多个不同的git库，每次更新会弹出窗口pull确认窗口，所以我建议使用git命令行自动化更新

@echo off
@echo ================自动更新git Start===============

@echo off
rem tortoisegit安装目录
SET git_home=C:\Program Files\TortoiseGit\bin

rem git repo目录(请修改对应的目录)
SET blog_samplecode=E:\Code\blog_samplecode
SET code_snippetE:\Code\code_snippet
SET unity_study=E:\Code\unity_study
SET python_study=E:\Code\python_study


rem 执行tortoisegit更新命令,更新对话框不自动关闭
@echo on
"%git_home%"\TortoiseGitProc.exe/command:pull /path:"%blog_samplecode%*%code_snippet%" /notempfile /closeonend:0

echo ==============自动更新git Finish==============