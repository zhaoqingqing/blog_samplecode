rem 请核对你的texturepacker安装路径

@echo off
  
path %path%;"C:\Program Files (x86)\CodeAndWeb\TexturePacker\bin"
  
for /f "usebackq tokens=*" %%d in (`dir /s /b *.pvr *.pvr.ccz *.pvr.gz`) do (
	TexturePacker.exe "%%d" --sheet "%%~dpnd.png" --data "%%~dpnd.plist" --opt RGBA8888 --allow-free-size --algorithm Basic --no-trim --dither-fs
)
  
pause