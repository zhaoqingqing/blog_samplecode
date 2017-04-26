using UnityEngine;
using System.Collections;

/// <summary>
/// 对reporter的扩展
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
                reporter.reporter.doShow();
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

public class DoubleGUIButton : MonoBehaviour
{
    private bool ButtonClicked = false;
    private float ResetTime = 0.0f;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 80, 50), "双击"))
        {
            ResetTime = Time.time;
            if (ButtonClicked)
            {
                print("It's DoubleClick!");
                ButtonClicked = false;
            }
            else
            {
                ButtonClicked = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (ResetTime + 0.5 < Time.time)
        {
            ButtonClicked = false;
        }
    }
}