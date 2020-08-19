using UnityEngine;
using System.Collections;

/// <summary>
/// 对reporter的扩展
/// 通过Reporter的菜单栏来创建Reporter，用到的图片脚本中已进行赋值
/// </summary>
public class ReporterExpand
{
    public Reporter reporter;
    public bool IsInit = false;

    public ReporterExpand()
    {
        if (reporter == null)
        {
            reporter = GameObject.FindObjectOfType<Reporter>();
        }
    }

    /// <summary>
    /// 显示或隐藏
    /// </summary>
    public static void ShowOrHide()
    {
        ReporterExpand reporter = new ReporterExpand();
        if (reporter.reporter == null)
        {
            Debug.LogError("reporter显示失败，场景中没有Reporter组件！");
        }
        else
        {
            if (reporter.reporter.show)
            {
                reporter.reporter.DoClose();
            }
            else
            {
                reporter.reporter.DoShow();
            }
        }
    }

    public static void Close()
    {
        ReporterExpand reporter = new ReporterExpand();
        if (reporter.reporter == null)
        {
            Debug.LogError("reporter关闭失败，场景中没有Reporter组件！");
        }
        else
        {
            reporter.reporter.DoClose();
        }
    }
}