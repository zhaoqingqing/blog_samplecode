using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/*
## 文件说明
- AssemblyInfo_Wd.txt
	exe程序集信息

- AssemblyInfo_Web.txt
	web程序集信息

## 实现原理
未通过反射，而是通过替换Properties/AssemblyInfo.cs达到更新程序集信息目地

## 使用方法
AssemblyInfo.cs是在运行时被替换的，所以要在下次运行生效
如需生成不同exe，可在release之前替换一次
*/

namespace GetFileList
{
   public class UpdateAssembly//Program
   {
		private static bool ReleaseWeb = true;
		private static bool updateAssemblyInfo = false;
		static void Main(string[] args)
		{
			//NOTE 修改程序集信息，下次生效
			if (updateAssemblyInfo)
			{
				var startDir = new DirectoryInfo(System.Environment.CurrentDirectory);
				if (startDir.Parent != null && startDir.Parent.Parent != null)
				{
					var sourceFileName = ReleaseWeb ? "configs/AssemblyInfo_Web.txt" : "configs/AssemblyInfo_Wd.txt";
					var sourceAssemFile = Path.Combine(startDir.Parent.Parent.FullName, sourceFileName);
					var targetAssemFile = Path.Combine(startDir.Parent.Parent.FullName, "Properties/AssemblyInfo.cs");
					if (File.Exists(sourceAssemFile) && File.Exists(targetAssemFile))
					{
						var sourceText = File.ReadAllText(sourceAssemFile);
						File.WriteAllText(targetAssemFile, sourceText);
					}
				}
			}

			if (ReleaseWeb)
			{
				WebResList.Instance.Main(args);
			}
			else
			{
				WdResList.Instance.Main(args);
			}
		}
    }
}
