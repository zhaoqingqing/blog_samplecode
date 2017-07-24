REM cd %~dp0
REM 在windows 7/10，subversion(svn) 1.9.4 下测试通过

svn add * --no-ignore --force

svn ci -m "[test svn commit]"