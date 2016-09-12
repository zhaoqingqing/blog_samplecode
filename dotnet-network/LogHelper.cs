using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LogicModule
{
	public enum LogLevel
	{
		Info, // Info, default
		Warning,
		Error,
	}

	public class LogHelper
	{
		private static string logFileName;

		protected static string LogFileName
		{
			get
			{
				if (!string.IsNullOrEmpty(logFileName)) return logFileName;
				logFileName = Application.StartupPath + "\\log.txt";
				return logFileName;
			}
		}
		//日志文件>此值，就会清空之前的
		protected static long MaxLogSizeKb = 10240;

		private static StringBuilder StrbuilderLog;
		private static bool IsDetectLogSize = false;
		private static bool IsInit = false;

		public static void EnSureInit()
		{
			//if (!IsInit)
			{
				if (File.Exists(LogFileName) == false)
				{
					var sw = File.CreateText(LogFileName);
					sw.Flush();
					sw.Close();
				}
				//NOTE 日志超过容量，就新建
				if (!IsDetectLogSize)
				{
					long logSizeKb = FileHelper.GetFileSizeKb(LogFileName);

					Console.WriteLine("log file {0}kb", logSizeKb);
					if (logSizeKb > MaxLogSizeKb)
					{
						File.Delete(LogFileName);
						var sw = File.CreateText(LogFileName);
						sw.Flush();
						sw.Close();
					}
					IsDetectLogSize = true;
				}
				IsInit = true;
			}
		}

		public static StackFrame GetTopStack(int stack = 2)
		{
			StackFrame[] stackFrames = new StackTrace(true).GetFrames();
			StackFrame sf = stackFrames[Math.Min(stack, stackFrames.Length - 1)];
			return sf;
		}

		public static void DoLog(string message, object[] args, LogLevel logLevel)
		{
			EnSureInit();
			string headerFlag = "Info";
			switch (logLevel)
			{
				case LogLevel.Info:
					headerFlag = "Info";
					break;
				case LogLevel.Warning:
					headerFlag = "Warning";
					break;
				case LogLevel.Error:
					headerFlag = "Error";
					break;
				default:
					throw new ArgumentOutOfRangeException("logLevel");
					break;
			}
			
			string newText = args == null || args.Length < 1 ? message : string.Format(message, args);
			using (StreamWriter stream = File.AppendText(LogFileName))
			{
				if (StrbuilderLog == null) StrbuilderLog = new StringBuilder();
				if (stream != null)
				{
					StrbuilderLog.Remove(0, StrbuilderLog.Length);
					StrbuilderLog.AppendFormat("[{0} {1}] {2}", headerFlag, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"), newText);
					StrbuilderLog.AppendLine();
					stream.WriteLine(StrbuilderLog.ToString());

				}
				Console.WriteLine(string.Format(message, args));
			}
		}

		public static void Log(string message, params object[] args)
		{
			DoLog(message, args, LogLevel.Info);
		}

		public static void LogWarning(string message, params object[] args)
		{
			DoLog(message, args, LogLevel.Warning);
		}

		public static void LogError(string message, params object[] args)
		{
			StackFrame sf = GetTopStack(2);
			string log = string.Format("{0}\n\n{1}:{2}\t{3}", message, sf.GetFileName(), sf.GetFileLineNumber(), sf.GetMethod());
			Console.Write(log);
			DoLog(message, args, LogLevel.Error);
		}
	}
}
