rem ��TortoiseGit�и��¶����ͬ��git�⣬ÿ�θ��»ᵯ������pullȷ�ϴ��ڣ������ҽ���ʹ��git�������Զ�������

@echo off
@echo ================�Զ�����git Start===============

@echo off
rem tortoisegit��װĿ¼
SET git_home=C:\Program Files\TortoiseGit\bin

rem git repoĿ¼(���޸Ķ�Ӧ��Ŀ¼)
SET blog_samplecode=E:\Code\blog_samplecode
SET code_snippetE:\Code\code_snippet
SET unity_study=E:\Code\unity_study
SET python_study=E:\Code\python_study


rem ִ��tortoisegit��������,���¶Ի����Զ��ر�
@echo on
"%git_home%"\TortoiseGitProc.exe/command:pull /path:"%blog_samplecode%*%code_snippet%" /notempfile /closeonend:0

echo ==============�Զ�����git Finish==============