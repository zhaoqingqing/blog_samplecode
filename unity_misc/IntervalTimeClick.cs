using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 指定时间内只能点击一次
/// </summary>
public class IntervalTimeClick : MonoBehaviour
{
    //每一次点击的间隔
    private const float IntervalTime = 1.0f;
    private float OpenIntervalTime = 0f;
    private Button BtnOpen;

    // Use this for initialization
    void Start()
    {
        BtnOpen.onClick.AddListener(OnClickOpen);
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenIntervalTime > 0)
        {
            OpenIntervalTime -= Time.deltaTime;
        }
    }

    void OnClickOpen()
    {
        if (OpenIntervalTime > 0)
        {
            return;
        }
        OpenIntervalTime = IntervalTime;
        Debug.Log("click open");

        /**
        example output
        [15:08:20.5775]click open
        [15:08:21.7617]click open
        [15:08:22.7718]click open
        */
    }
}
