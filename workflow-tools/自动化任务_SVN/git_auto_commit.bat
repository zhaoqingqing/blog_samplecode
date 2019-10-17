REM cd %~dp0
rem 在计划任务中使用
cd /d %~dp0
cd .\..\
REM git commit –m "你的注释"
git add .
git commit -m "auto sync"
git push origin
REM git commit -a

REM 你的更新到远程服务器,语法为 git push [远程名] [本地分支]:[远程分支]
git push origin master
