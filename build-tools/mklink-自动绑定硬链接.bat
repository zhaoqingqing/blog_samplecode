@echo off
cls

:Check
::执行前检查
if exist youlong_online/data (
	color 02
	echo √找到Youlong_Online/data客户端产品库！
) else (
	color 04
	echo ×找不到Youlong_Online!  客户端不在当前目录下
	goto ErrorEnding
)
echo.
if exist ../setting_client (
	color 02
	echo √找到youlong_scheme_vn/gameres策划库！
) else (
	color 04
	echo ×找不到youlong_scheme_vn策划库, 请将youlong_online和youlong_scheme_vn放在同一个目录下
	goto ErrorEnding
)

:: 源代码
if exist ../youlong (
	color 02
	echo √找到youlong_code_vn/client客户端程序库！
	cd run_helper
	junction ../../youlong/Assets/Resources/setting_client ../../setting_client
	junction ../../youlong/Assets/data ../youlong_online/data
	echo.
	echo 客户端程序代码绑定成功！
) else (
	color 02
	echo ×找不到youlong_code_vn客户端程序库, 忽略
)

echo.


echo. 
echo ##########################
echo ### 全部目录硬链接成功！ ###
echo ##########################

goto HappyEnding


:ErrorEnding
echo. 
echo ##########################
echo ### 出现问题了！请确保你的youlong_scheme_vn和youlong_product_vn放在同一目录下。 ###
echo ##########################
ping 127.0.0.1 -n 5 >nul
exit

:HappyEnding
::结束, 等待5秒
echo.
::ping 127.0.0.1 -n 6 >nul
::exit
pause