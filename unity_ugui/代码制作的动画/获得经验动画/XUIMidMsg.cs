using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using KEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// 飘字动画
/// 需要导入Dotween
/// </summary>
public class XUIMidMsg : MonoBehaviour
{
    public float waitTime = 0.3333f; //如果之前的还显示，等待多长时间播放下一个
    private float calcTime = 0.3333f;

    private Stack<XUIMidMsgAnimator> m_MsgTempllatePool; // 内存池
    [HideInInspector]
    public Stack<string> m_WaitingMsgList;

    public GameObject MsgTemplate;

    private bool IsInit = false;

    private static XUIMidMsg instance;

    public static XUIMidMsg Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(XUIMidMsg)) as XUIMidMsg;
                if (instance == null)
                {
                    //                    GameObject obj = new GameObject("XUIMidMsg");
                    //                    instance = obj.AddComponent<XUIMidMsg>();
                    //                    instance.OnInit();
//                    Log.Error("找不到XUIMidMsg");
                }
            }
            return instance;
        }
    }

    /// <summary>
    ///  静态方法， 快速弹信息
    /// </summary>
    /// <param name="msgStr"></param>
    public static void QuickMsg(string msgStr, params object[] args)
    {
        if (Instance != null)
        {
            Instance.OnInit();
            instance.ShowMsg(string.Format(msgStr, args));
        }
        else
        {
            Debug.LogWarning("飘字失败，实例为空");
        }
    }

    public void Awake()
    {
        OnInit();
        Debuger.Assert(MsgTemplate);
        MsgTemplate.SetActive(false);
    }

    public void Update()
    {
        if (m_WaitingMsgList.Count >= 1)
        {
            if (calcTime <= 0)
            {
                XUIMidMsgAnimator msgInstance = PoolGet();
                msgInstance.StartAnimate(m_WaitingMsgList.Pop());
                calcTime = waitTime;
            }
            calcTime -= Time.deltaTime;
        }
    }

    public void OnInit()
    {
        if (!IsInit)
        {
            m_MsgTempllatePool = new Stack<XUIMidMsgAnimator>();
            m_WaitingMsgList = new Stack<string>();

            IsInit = true;
        }
    }

    public void ShowMsg(string msgStr)
    {
        Debug.Assert(MsgTemplate);
        if (gameObject.activeSelf == false) gameObject.SetActive(true);

        m_WaitingMsgList.Push(msgStr);
        //        Log.Info("总数量={0}", m_WaitingMsgList.Count);
    }

    public void Clear()
    {
        m_WaitingMsgList.Clear();
    }

    public void PoolDelete(XUIMidMsgAnimator msgInstance)
    {
        msgInstance.gameObject.SetActive(false);
        m_MsgTempllatePool.Push(msgInstance);
    }

    public XUIMidMsgAnimator PoolGet()
    {
        XUIMidMsgAnimator msgInstance = null;
        if (m_MsgTempllatePool.Count > 0)
        {
            msgInstance = m_MsgTempllatePool.Pop();
        }

        if (msgInstance == null)
        {
            GameObject newGameObj = GameObject.Instantiate(MsgTemplate) as GameObject;
            msgInstance = newGameObj.GetComponent<XUIMidMsgAnimator>();
            if (msgInstance == null)
            {
                msgInstance = newGameObj.AddComponent<XUIMidMsgAnimator>();
            }
            msgInstance.transform.SetParent(this.transform);
            msgInstance.UICtrler = this;
        }

        KTool.ResetLocalTransform(msgInstance.transform);
        msgInstance.gameObject.SetActive(true);

        return msgInstance;
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(XUIMidMsg))]
public class XUIMidMsgEditor : Editor
{
    public float testCount = 0;
    private XUIMidMsg obj;
    public override void OnInspectorGUI()
    {
        obj = target as XUIMidMsg;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("1.运行  2.点击开始");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("开始"))
        {
            XUIMidMsg.QuickMsg("测试文字" + testCount);
            testCount += 1;
        }
        if (GUILayout.Button("开始多个"))
        {
            for (int idx = 0; idx < 10; idx++)
            {
                XUIMidMsg.QuickMsg("测试文字" + testCount);
                testCount += 1;
            }

        }
        if (GUILayout.Button("清空"))
        {
            obj.Clear();
        }
        EditorGUILayout.EndHorizontal();
    }
}
#endif