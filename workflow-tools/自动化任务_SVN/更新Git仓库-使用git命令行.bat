rem Git�����и��¶����ͬ��git��

@echo off
@echo ================�Զ�����git Start===============


rem git repoĿ¼(���޸Ķ�Ӧ��Ŀ¼)
SET blog_samplecode=E:\Code\blog_samplecode
SET code_snippet=E:\Code\code_snippet
SET unity_study=E:\Code\unity_study
SET python_study=E:\Code\python_study

cd e:
cd %blog_samplecode%
git pull

cd %code_snippet%
git pull
echo ==============�Զ�����git Finish==============
pause