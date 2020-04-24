echo off
::use amin to run this
cd %~dp0
set bc_path=D:\Tools\Beyond Compare\BCompare.exe
netsh advfirewall firewall add rule name="BC4" program="%bc_path%" action=block dir=out
netsh advfirewall firewall add rule name="BC4" program="%bc_path%" action=block dir=in
pause 