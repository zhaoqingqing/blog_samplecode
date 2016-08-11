using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GetFileList
{
    public class ResInfo
    {
        public string Hash;
        public long Version;

        public ResInfo()
        {
        }

        public ResInfo(string hash, long lastVersion)
        {
            this.Hash = hash;
            this.Version = lastVersion;
        }
    }

    /// <summary>
    /// 功能：生成reslist for web
    /// 用法：把此程序放在 ylsvn/youlong_product_vn\youlong_online\下
    /// updatelog:
    ///     只保留文件名，去掉路径
    /// 作者：zhaoqingqing
    /// </summary>
    public class WebResList
    {
        private static WebResList instance;
        public static WebResList Instance
        {
            get
            {
                if (instance == null) instance = new WebResList();
                return instance;
            }
        }
        const string resFileName = "webResList.txt";
        string resFileNameLast = "webResList_last.txt";
        /// <summary>
        /// 调试时，固定本机路径，发布改为false
        /// </summary>
        private bool isDebug = false;

        private Dictionary<string, ResInfo> lastResDict;

        public Dictionary<string, ResInfo> LastResDict
        {
            get
            {
                if (lastResDict == null)
                {
                    lastResDict = new Dictionary<string, ResInfo>();
                    if (File.Exists(resFileNameLast) == false)
                    {
                        return lastResDict;
                    }
                    var allText = File.ReadAllText(resFileNameLast);
                    var lines = allText.Split('|');
                    foreach (var line in lines)
                    {
                        var info = line.Split('&');
                        if (info.Length >= 3)
                        {
                            if (lastResDict.ContainsKey(info[0]) == false)
                            {
                                Int64 version = Convert.ToInt64(info[2]);
                                var resInfo = new ResInfo(info[1], version);
                                lastResDict.Add(info[0], resInfo);
                            }
                        }
                    }
                    Console.WriteLine("last resfile line:{0}", lastResDict.Count);
                    Console.WriteLine();
                }

                return lastResDict;
            }
        }

        public ResInfo GetLastInfo(string path)
        {
            ResInfo resInfo = new ResInfo("", 0);
            if (LastResDict == null) return resInfo;
            //Console.WriteLine("path:{0}", path);
            if (LastResDict.ContainsKey(path))
            {
                return LastResDict[path];
            }
            return resInfo;
        }

        private void GetLastResInfo(string path, ref string lastHash, ref long lastVersion)
        {
            var lastInfo = GetLastInfo(path);
            lastHash = "";
            lastVersion = 0;
            if (lastInfo != null)
            {
                lastHash = lastInfo.Hash;
                lastVersion = lastInfo.Version;
            }
        }

        public void Main(string[] args)
        {
            //只更新reslist.txt
            UpdateResList();

            Console.WriteLine("操作完成，自动退出");
            //Console.ReadKey();
        }

        void UpdateResList()
        {
            var targetPath = Path.Combine(System.Environment.CurrentDirectory, "data\\");//当前程序的目录/data
            if (isDebug)
            {
                targetPath = @"e:\ylgame_trunk\youlong_product_vn\youlong_online\data\";
            }
            if (string.IsNullOrEmpty(targetPath))
            {
                Console.WriteLine("ERROR：请把此程序放在 product/online/xx.exe ");
            }

            Console.WriteLine("获取文件的路径：{0}", targetPath);

            if (File.Exists(resFileName))
            {
                FileInfo resFileInfo = new FileInfo(resFileName);
                //NOTE 如果存在老的res_last，就用res替换掉res_last
                if (File.Exists(resFileNameLast))
                {
                    File.Delete(resFileNameLast);
                }
                resFileInfo.MoveTo(resFileNameLast);
                File.Delete(resFileName);
            }

            Console.WriteLine();
            Console.WriteLine("正在生成文件列表文件：{0}，请稍候......", resFileName);
            Int64 fileLine = 0, adjustLine = 0;
            string overflowMsg = string.Empty;
            using (StreamWriter streamWriter = File.CreateText(resFileName))
            {
                var fileInfos = FileHelper.GetAllFiles(targetPath);
                var fileMax = fileInfos.Count;
                for (int fileIdx = 0; fileIdx < fileMax; fileIdx++)
                {
                    //if (fileLine >= 4) break;//测试情境
                    var fileInfo = fileInfos[fileIdx];
                    if (fileInfo == null) continue;
                    if (fileInfo.Extension != ".meta")
                    {
                        if (fileInfo.Name.Contains("setting_client.ab")) continue;
                        /*
                        NOTE 获取data目录下的所有文件，去掉path,只保留文件名
                        */
                        
                        //var filePath = fileInfo.FullName.Replace(targetPath, "");
                        var filePath = fileInfo.Name;
                     
                        //bug 有的机器上,替换之后前面还会留着一个\,强制把它干掉
                        if (filePath.StartsWith("\\")) filePath = filePath.Substring(1);
                        if (filePath.Contains("\\")) filePath = filePath.Replace("\\", "");

                        var lastHash = "";
                        long lastVersion = 0;
                        GetLastResInfo(filePath, ref lastHash, ref lastVersion);

                        var curHash = HashHelper.GetSHA1(fileInfo.FullName);
                        var curVersion = lastVersion;
                        if (curHash != lastHash)
                        {
                            curVersion = lastVersion + 1;
                            if (adjustLine < Int64.MaxValue) adjustLine += 1;
                        }
                        

                        var writeStr = string.Concat(filePath, "&", curHash, "&", curVersion, "|");
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
            Console.WriteLine();
            Console.WriteLine("{0}生成成功，共{1}行，其中{2}行受到影响", resFileName, fileLine, adjustLine);

            if (!string.IsNullOrEmpty(overflowMsg)) Console.WriteLine(overflowMsg);
        }
    }
}