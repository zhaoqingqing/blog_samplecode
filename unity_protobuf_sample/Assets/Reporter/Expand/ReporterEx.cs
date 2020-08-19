using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public partial class Reporter : MonoBehaviour
{
    //可扩展禁用手势开启
    public bool DisableGsture = false;
    
    public void DoClose()
    {
        show = false;
        ReporterGUI gui = gameObject.GetComponent<ReporterGUI>();
        DestroyImmediate(gui);

        try
        {
            gameObject.SendMessage("OnHideReporter");
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void DoShow()
    {
        doShow();
    }
}