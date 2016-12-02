using UnityEngine;
using System.Collections;
using Vuforia;

/// <summary>
/// Detail		:  仅仅是对DefaultTrackableEventHandler添加了OnFound和OnLost事件
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class CustomTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
{
    private TrackableBehaviour _mTrackableBehaviour;
    //识别成功
    public delegate void OnFoundEvent(string trackableName);
    public static event OnFoundEvent OnFound;
    //丢失
    public delegate void OnLostEvent(string trackableName);
    public static event OnLostEvent OnLost;

    void Start()
    {
        _mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (_mTrackableBehaviour)
        {
            _mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    /// <summary>
    /// 识别状态改变调用
    /// </summary>
    /// <param name="previousStatus"></param>
    /// <param name="newStatus"></param>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    /// <summary>
    /// 识别到
    /// </summary>
    private void OnTrackingFound()
    {
        Debug.Log("Trackable " + _mTrackableBehaviour.TrackableName + " found");
        if (OnFound != null) OnFound(_mTrackableBehaviour.TrackableName);
    }


    /// <summary>
    /// 丢失
    /// </summary>
    private void OnTrackingLost()
    {
        Debug.Log("Trackable " + _mTrackableBehaviour.TrackableName + " lost");
        if (OnLost != null) OnLost(_mTrackableBehaviour.TrackableName);
    }

}