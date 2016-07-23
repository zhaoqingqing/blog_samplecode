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
/// unity call winform api
/// how to useage
/// 1. copy System.Windows.Forms.dll to unity project/Assets/Plugins/
///	2. change player settings - api compatibillity Level to .NET2.0
/// 3. using System.Windows.Forms;
/// 4. now you can call winform api in unity code
/// by https://github.com/zhaoqingqing
/// </summary>
public class Sample_Unity_WinForm : MonoBehaviour
{
    public void ConfirmQuit()
    {
        var dialogResult = MessageBox.Show("really want exit game ?", "system message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (dialogResult == DialogResult.OK)
        {
            Application.CancelQuit();
            //TODO write you logic method

            Application.Quit();
        }
    }
}