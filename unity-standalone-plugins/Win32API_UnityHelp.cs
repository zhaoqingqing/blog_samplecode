using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;

/// <summary>
/// unity调用windows平台的功能
/// unity调用winform接口
/// 1. 导入System.Windows.Forms
///	2. player settings中api compatibillity Level改为.NET2.0
///	by 赵青青
/// </summary>
public class WdHelper
{
    private static WdHelper instance;

    public static WdHelper Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = new WdHelper();
            return instance;
        }
    }
    // Use DllImport to import the Win32 MessageBox function.
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    // Call the MessageBox function using platform invoke.
    //MessageBox(new IntPtr(0), "Hello World!", "Hello Dialog", 0);
    public void UnityPingSeverRespone(string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            return;
        }

        //网页的处理方式：1.弹出错误码; 2.导航到游戏主页
        //alert(arg);
        //window.location.href = 'http://yl.49you.com/';

        //微端处理方式：1.弹出错误码; 2.关闭游戏窗口，打开登录器
        //MessageBox.Show(arg, "系统提示");
        var startFile = System.AppDomain.CurrentDomain.BaseDirectory + "\\fileUpdate.exe";
        var startFile2 = System.Windows.Forms.Application.StartupPath + "\\fileUpdate.exe";
        var startFile3 = Process.GetCurrentProcess().MainModule.ModuleName + "\\fileUpdate.exe";
        var startFile4 = Directory.GetCurrentDirectory() + "\\fileUpdate.exe";
        var startFile5 = System.AppDomain.CurrentDomain.DynamicDirectory + "\\fileUpdate.exe";

        Debug.Log(string.Format("wd:{0},{1},{2},{3}",startFile,startFile2,startFile3,startFile4));
        Debug.Log(string.Format("wd:{0},{1},{2},{3}",startFile,startFile2,startFile3,startFile4));
        if (File.Exists(startFile) == false)
        {
            //TODO 文件找不到
            MessageBox(new IntPtr(0), startFile + "找不到！", "系统提示", 0);
            //if (MessageBox.Show(startFile + "找不到！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                //KillCurrentProcess();
            }
        }
        else
        {
            Process launcher = new Process();
            launcher.StartInfo.FileName = startFile;
            launcher.Start();
            KillCurrentProcess();
        }
    }


    private void KillCurrentProcess()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            var curProcess = Process.GetCurrentProcess();
            var closeResult = curProcess.CloseMainWindow();
            if (closeResult == false) curProcess.Kill();
        }

        //Application.Quit();

    }



    private bool m_CanQuit = false;
    public void ConfirmQuit()
    {
        //var dialogResult = MessageBox.Show("真的要退出游戏吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //if (dialogResult == DialogResult.OK)
        //{
        //    Application.CancelQuit();

        //    //NOTE 微端下向网络发送断开
        //    if (MainFramework.m_Client != null)
        //    {
        //        MainFramework.m_Client.UnInitNetWork();
        //        Debug.Log("winstand:gameclient.UnInitNetWork");
        //    }
        //    else
        //    {
        //        Debug.Log("app quit:m_Client is null");
        //    }
        //    Application.Quit();
        //}
    }
}
