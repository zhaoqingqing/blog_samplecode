using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LogicModule
{
	/// <summary>
	/// HTTP下载
	/// msdn: https://msdn.microsoft.com/zh-cn/library/debx8sh9(v=vs.110).aspx
	/// </summary>
	public class HttpDownloadHelper
	{
		/// <summary>
        /// 下载文件到本地
        /// </summary>
        /// <param name="targetUrl">下载的完整url</param>
        /// <param name="fileName">下载的文件名</param>
        /// <param name="savePath">保存路径</param>
        public static void HttpDownFileToLocal(string targetUrl, string savePath, bool isWriteLog = false)
        {
            if (string.IsNullOrEmpty(targetUrl))
            {
                LogHelper.LogWarning("HttpDownLoadFile url is null.");
                return;
            }

            var splitIdx = targetUrl.LastIndexOf('/');
            string fileName = targetUrl.Substring(splitIdx + 1);
            HttpWebRequest webRequest = HttpWebRequest.Create(targetUrl) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Proxy = null; //取消代理，避免第1次访问很慢
                webRequest.Method = "GET";
                HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
                if (webResponse == null)
                {
                    LogHelper.LogError("download {0} response null", targetUrl);
                    return;
                }
                using (Stream stream = webResponse.GetResponseStream())
                {
                    try
                    {
                        if (stream != null)
                        {
                            DirectoryInfo dirinfo = new DirectoryInfo(savePath);
                            if (dirinfo.Parent != null && !Directory.Exists(dirinfo.Parent.FullName))
                            {
                                Directory.CreateDirectory(dirinfo.Parent.FullName);
                            }
                            if (isWriteLog)
                            {
                                LogHelper.Log("downing ....,savepath={0}", savePath);
                            }

                            if (savePath.EndsWith("json"))
                            {
                                //NOTE Json文件
                                LogHelper.Log("down Json file");
                                StreamReader reader = new StreamReader(stream);
                                string responseFromServer = reader.ReadToEnd();
                                if (isWriteLog)
                                {
                                    LogHelper.Log("responseFromServer:{0}", responseFromServer);
                                }
                                reader.Close();
                                using (StreamWriter sw = new StreamWriter(savePath))
                                {
                                    sw.Write(responseFromServer);
                                }
                            }
                            else
                            {
                                //把文件写进去
                                FileStream filesw = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                int curbyte = stream.ReadByte();
                                while (curbyte != -1)
                                {
                                    filesw.WriteByte((byte)curbyte);
                                    curbyte = stream.ReadByte();
                                }
                            }
                            if (isWriteLog)
                            {
                                LogHelper.Log("down success.{0}", targetUrl);
                            }
                        }
                        else
                        {
                            LogHelper.LogError("webResponse stream null");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogError("download file error:{0}", ex.Message);
                    }
                    webRequest.Abort();
                    webResponse.Close();
                }
            }
            else
            {
                string errorMsg = string.Format("{0} 找不到", targetUrl);
                MessageBox.Show(errorMsg, "更新出错");
                LogHelper.LogError(errorMsg);
            }
        }
	}
}