rem Git命令行更新多个不同的git库

@echo off
@echo ================自动更新git Start===============

@echo off
rem git repo目录(请修改对应的目录)
SET blog_samplecode=E:\Code\blog_samplecode
SET code_snippet=E:\Code\code_snippet
SET unity_study=E:\Code\unity_study
SET python_study=E:\Code\python_study


cd e:
cd %blog_samplecode%
@echo on
git pull

cd %code_snippet%
git pull
echo ==============自动更新git Finish==============
pause