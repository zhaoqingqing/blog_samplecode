

 set hour=%time:~,2%
if "%time:~,1%"==" " set hour=0%time:~1,1%

:: 字符串拼接是直接连接
set log_file = log_%date:~0,4%-%date:~5,2%-%date:~8,2%_%hour%-%time:~3,2%-%time:~6,2%.log
::格式如下：log_2017-03-21_10-29-02.log 
echo %log_file%
pause