### 文件处理笔记



对于路径中含有转义字符，在路径字符串前加 r，比如 filepath = r'E:\Code\test.txt'

使用默认的系统函数 open



创建文件夹 os.mkdir



文件拷贝：shutil.copyfile(src_fullpath, path_name)

删除文件：os.remove(file_name)

python调用资源管理器打开某个文件夹：os.startfile(full_path)

进入某个目录，此后的操作是在这个目录下：os.chdir(full_path)