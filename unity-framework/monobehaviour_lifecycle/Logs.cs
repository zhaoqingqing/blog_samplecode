using System;
using System.Diagnostics;

public class Logs  {

    /// <summary>
    /// 打印调用者的方法名
    /// </summary>
    public static void DoLog()
    {
        StackTrace st = new StackTrace(true);
        //获取当前调用的方法名
        StackFrame stackFrame = st.GetFrame(1);
        //var callInfo = string.Format("{0}:{1}.{2}",stackFrame.GetFileName(),stackFrame.GetFileLineNumber(),stackFrame.GetMethod().Name);
        var callInfo = stackFrame.GetMethod().Name.ToString();
        DoLog(callInfo);
    }

    public static void DoLog(string szMsg, params object[] args)
    {
        string log = string.Format("[{0}]{1}", DateTime.Now.ToString("HH:mm:ss.ffff"), string.Format(szMsg, args));
        UnityEngine.Debug.Log(log);
    }
}