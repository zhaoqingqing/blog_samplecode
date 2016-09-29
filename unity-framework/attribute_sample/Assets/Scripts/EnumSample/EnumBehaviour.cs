using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Detail		:  枚举Attribute使用示例
/// Author		:  qingqing-zhao@outlook.com
/// CreateTime  :  #CreateTime#
/// </summary>
public class EnumBehaviour : MonoBehaviour
{
    public PropertiesEnum CurProperties;

    public void OnGUI()
    {
        GUILayout.Label("以下描述从Enum中读取显示");
        var max = Enum.GetValues(typeof(PropertiesEnum)).Length;
        //从1开始
        for (int idx = 1; idx <= max; idx++)
        {
            PropertiesEnum _enum = (PropertiesEnum)idx;
            var desc = PropertiesUtils.GetDescByType(_enum);
            if (GUILayout.Button(desc))
            {
                Debug.Log(string.Format(desc));
            }
        }
        GUILayout.Label("详细请查看代码");

    }
}
