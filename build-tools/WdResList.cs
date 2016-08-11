using System;
using System.IO;


namespace GetFileList
{
    /// <summary>
    /// 功能：自动生成微端文件列表
    /// 用法：把此程序放在 ylsvn/youlong_product_vn\wd\下
    /// 作者：赵青青
    /// </summary>
    public class WdResList
	{
        private static WdResList instance;
        public static WdResList Instance
        {
            get
            {
                if (instance == null) instance = new WdResList();
                return instance;
            }
        }
        /// <summary>
        /// data目录
        /// </summary>
        const string dataFolderName = @"data\";

		const string versionFileName = "version.txt";
		const string resFileName = "updateResList.txt";
		 string resLastFileName = string.Empty;

		const string wdPre = "wd";
		const string resPre = "res";
		/// <summary>
		/// Assembly-CSharp.dll的路径
		/// </summary>
		const string dllDir = @"Managed\";
		const string dllPath = @"Managed\Assembly-CSharp.dll";

		private  bool isFixedPath = false;

		 public void Main(string[] args)
		{
			//顺序：1.更新res 2.更新verTxt
			UpdateResTxt();
			UpdateVerTxt();

			Console.WriteLine("操作完成，程序将自动退出");
			//Console.ReadKey();
		}

		 void UpdateResTxt()
		{
			var currentDirectory = System.Environment.CurrentDirectory;//当前程序的目录
			var parentDirPath = string.Empty;
			var parentDir = new DirectoryInfo(currentDirectory).Parent;
			if (parentDir != null)
			{
				parentDirPath = Path.Combine(parentDir.FullName ,"youlong_online\\"); //上一级目录+文件夹名
			}
			else
			{
				Console.WriteLine("ERROR：请把此程序放在 data/../xx/getFile.exe ");
			}

			if (isFixedPath)
			{
				parentDirPath = @"e:\ylgame_trunk\youlong_product_vn\youlong_online\";
			}

			var targetPath = parentDirPath + dataFolderName;
			Console.WriteLine("获取文件的路径：{0}", targetPath);
			

			var dllFullPath = parentDirPath + dllPath;
			Console.WriteLine("Assembly-CSharp.dll的路径：{0}", targetPath);

			if (File.Exists(resFileName))
			{
				FileInfo resFileInfo = new FileInfo(resFileName);
				//Console.Write("创建时间：" + resFileInfo.CreationTime + "写入文件的时间" + resFileInfo.LastWriteTime + "访问的时间" + resFileInfo.LastAccessTime);
				resLastFileName = string.Concat(resFileInfo.LastWriteTime.ToString("yyyyMMdd_hhmmss_ffff"), ".txt");
				resFileInfo.MoveTo(resLastFileName);
				File.Delete(resFileName);
				Console.WriteLine("重命名旧的文件：{0}->{1}", resFileName, resLastFileName);
			}

			Console.WriteLine();
			Console.WriteLine("正在生成文件列表文件：{0}，请稍候......", resFileName);
			Int64 fileLine = 0;
			string overflowMsg = string.Empty;
			using (StreamWriter streamWriter = File.CreateText(resFileName))
			{
				//特殊处理dll文件
				var writeDllPath = dllFullPath.Replace(parentDirPath, "");
				//writeDllPath = writeDllPath.Replace(dllDir, "");
				writeDllPath = writeDllPath.Insert(0, dataFolderName);//在路径前添加
				writeDllPath = writeDllPath.Replace(@"\", "/");
				var writeDllStr = string.Concat(writeDllPath, "&", HashHelper.GetSHA1(dllFullPath));
				if (!string.IsNullOrEmpty(writeDllStr))
				{
					streamWriter.WriteLine(writeDllStr);
					Console.WriteLine(writeDllStr);
					if (fileLine < Int64.MaxValue)
					{
						fileLine += 1;
					}
					else
					{
						overflowMsg = "文件行数太多啦，未统计。";
					}
				}

				var fileInfos = FileHelper.GetAllFiles(targetPath);
				var fileMax = fileInfos.Count;
				for (int fileIdx = 0; fileIdx < fileMax; fileIdx++)
				{
					var fileInfo = fileInfos[fileIdx];
					if (fileInfo.Extension != ".meta")
					{
						var filePath = fileInfo.FullName.Replace(parentDirPath, "");
						filePath = filePath.Replace(@"\", "/");
						var writeStr = string.Concat(filePath, "&", HashHelper.GetSHA1(fileInfo.FullName));
						if (!string.IsNullOrEmpty(writeStr))
						{
							streamWriter.WriteLine(writeStr);
							Console.WriteLine(writeStr);
							if (fileLine < Int64.MaxValue)
							{
								fileLine += 1;
							}
							else
							{
								overflowMsg = "文件行数太多啦，未统计。";
							}
						}
					}
				}
			}
			Console.WriteLine("{0}生成成功，共{1}行", resFileName, fileLine);
			Console.WriteLine();
			if (!string.IsNullOrEmpty(overflowMsg)) Console.WriteLine(overflowMsg);
		}

		 void UpdateVerTxt()
		{
			var strNewVer = string.Empty;
			if (File.Exists(versionFileName) == false)
			{
				using (StreamWriter streamWriter = File.CreateText(versionFileName))
				{
					streamWriter.WriteLine(wdPre + "1.0");
					streamWriter.WriteLine(resPre + "1.0");
					strNewVer = "res1.0";
					Console.WriteLine("{0} 创建成功，赋予初始值", versionFileName);
				}
			}
			else
			{
				long lastVerNum = 1;
				if (string.IsNullOrEmpty(versionFileName) || File.Exists(resLastFileName) == false)
				{
					Console.WriteLine("{0} 找不到，version文件不做修改", resLastFileName);
					return;
				}
				Console.WriteLine("正在更新版本号文件：{0}，请稍候......", versionFileName);
				var oldfileText = File.ReadAllText(resLastFileName);
				var newfileText = File.ReadAllText(resFileName);
				//文件内容发生改变，res版本+1
				if (oldfileText != newfileText)
				{
					var readAllLines = File.ReadAllLines(versionFileName);
					if (readAllLines.Length >= 2 && !string.IsNullOrEmpty(readAllLines[1]))
					{
						var wdVer = readAllLines[0];
						var resVer = readAllLines[1].Trim();
						if (resVer.StartsWith(resPre) && resVer.Contains("."))
						{
							var strs = resVer.Replace(resPre, "").Split('.');
							try
							{
								if (strs.Length > 0)
								{
									lastVerNum = Convert.ToInt64(strs[0]);
									lastVerNum += 1;
								}
							}
							catch (Exception exception)
							{
								Console.WriteLine(exception.Message);
							}
						}
						else
						{
							Console.WriteLine("{0}文件内容错误！第二行内容格式为:resint.int", versionFileName);
						}

						strNewVer = string.Concat(resPre, lastVerNum, ".0");

						File.WriteAllText(versionFileName, wdVer + "\n" + strNewVer);
						Console.WriteLine("{0}修改成功，version:{1}->{2}", versionFileName, lastVerNum - 1, lastVerNum);
						Console.WriteLine();
					}
					else
					{
						Console.WriteLine("{0}文件内容错误！正确格式:共2行，wd1.0\nres1.0", versionFileName);
					}
				}
				else
				{
					Console.WriteLine("{0}内容和{1}一致，version文件不做修改", resFileName, resLastFileName);
				}
			}
		}
	}
}
