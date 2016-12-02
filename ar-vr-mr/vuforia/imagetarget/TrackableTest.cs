using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;

/// <summary>
/// Detail		:  多个ImageTarget识别的尝试
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class TrackableTest : MonoBehaviour
{

    private Dictionary<string, TrackableBehaviour> Name2TrackDict = new Dictionary<string, TrackableBehaviour>();
    public float ImageOffsetX = 1.45f;

    void Awake()
    {
        //NOTE vuforia 打印创建成功的log之后,才可以获取到所有的ImageTarget
        VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback(OnInitFinish);
    }

    void OnInitFinish()
    {
        InitImageTarget();
    }

    // Use this for initialization
    void InitImageTarget()
    {
        //获取所有的可识别对象
        IEnumerable<TrackableBehaviour> trackableBehaviours = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        if (trackableBehaviours != null)
        {
            Debug.LogFormat("共有 {0} 个识别图", trackableBehaviours.Count());
            Vector3 pos = new Vector3(0, 0, 0);

            foreach (TrackableBehaviour trackableBehaviour in trackableBehaviours)
            {
                if (trackableBehaviour == null) continue;
                trackableBehaviour.gameObject.AddComponent<CustomTrackableEventHandler>();

                trackableBehaviour.transform.localPosition = pos;
                trackableBehaviour.gameObject.layer = 8;

                ImageTargetBehaviour targetBehaviour = trackableBehaviour.gameObject.GetComponent<ImageTargetBehaviour>();
                //NOTE 不建议手动设置ImageTargetBehaviour的Size,设置之后会导致计算出的位置不对
                //NOTE 多个ImageTarget之间要有间隙,可以理解为平铺开来
                pos += new Vector3(targetBehaviour.GetSize().y, pos.y, pos.z);
                ImageOffsetX = targetBehaviour.GetSize().y;
                trackableBehaviour.gameObject.name = string.Concat("ImageTarget_", trackableBehaviour.TrackableName);
                if (!Name2TrackDict.ContainsKey(trackableBehaviour.TrackableName))
                {
                    Name2TrackDict.Add(trackableBehaviour.TrackableName, trackableBehaviour);
                }
            }
            Debug.Log("所有识别图都已生成完成");
        }

        CustomTrackableEventHandler.OnFound += CustomTrackableEventHandler_OnFound;
        CustomTrackableEventHandler.OnLost += CustomTrackableEventHandler_OnLost;
    }

    public void CustomTrackableEventHandler_OnFound(string trackableName)
    {
        if (Name2TrackDict.ContainsKey(trackableName))
        {
            TrackableBehaviour trackableBehaviour = Name2TrackDict[trackableName];
            if (trackableBehaviour != null)
            {
                //TODO OnFund
            }
        }
    }

    private void CustomTrackableEventHandler_OnLost(string trackableName)
    {
        if (Name2TrackDict.ContainsKey(trackableName))
        {
            //Fix: 重设位置到初始值 否则多次丢失之后位置会发生错乱
            TrackableBehaviour trackableBehaviour = Name2TrackDict[trackableName];
            //ID 就是图片在xml中的index,从1开始
            var posX = trackableBehaviour.Trackable.ID * ImageOffsetX;
            trackableBehaviour.transform.localPosition = new Vector3(posX, 0, 0);
            trackableBehaviour.transform.localRotation = Quaternion.identity;
        }

    }

    void OnDestory()
    {
        CustomTrackableEventHandler.OnFound -= CustomTrackableEventHandler_OnFound;
        CustomTrackableEventHandler.OnLost -= CustomTrackableEventHandler_OnLost;
    }

}