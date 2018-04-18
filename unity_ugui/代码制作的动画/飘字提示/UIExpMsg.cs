using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using KEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class UIExpMsg : MonoBehaviour
{
    public float upTime = 1.1f; //上升时间
    public bool selfDestroy = true;

    public float totalTime = 1.3f; //存在时长

    //消失时间
    public float fadeOutTime = 0.2f;


    public float labelHeight = 20.0f;//单行的高度
    public float sortTime = 0.6f;
    public float speed = 1.0f;
    public Transform prefab;
    public Transform mount;
    public UnityAction oncomplete;
    List<ExpAnimator> floating = new List<ExpAnimator>();
    public bool canFloating = false;

    void Update()
    {
        var t = Time.deltaTime;

        for (var i = 0; i < floating.Count; ++i)
        {
            var tl = floating[i];
            tl.timed += t;

            var delta = GetYdelta(tl.timed);
            var ops = tl.tr.localPosition;
            //上升阶段
            if (tl.timed < upTime)
            {
                ops.y += delta;
            }

            if (tl.timed >= fadeOutTime)
            {
                tl.canvasGroup.alpha -= Time.deltaTime;
            }
            //            Log.Info("{0}", ops.y);

            //大于生命周期
            if (tl.timed >= totalTime)
            {
                Complete(i--);
                continue;
            }

            tl.tr.localPosition = ops;
        }
    }

    private void Complete(int i)
    {
        if (selfDestroy)
        {
            Destroy(floating[i].tr.gameObject);
        }

        floating.RemoveAt(i);
        if (oncomplete != null)
        {
            oncomplete();
        }
    }

    private float GetYdelta(float timed)
    {
        if (speed > 0)
        {
            return speed;
        }
        return 2;
    }

    public void Append(ExpAnimator newly, string msg)
    {
        newly.transform.SetParent(mount);
        newly.gameObject.SetActive(true);
        newly.transform.localScale = Vector3.one;
        newly.transform.localPosition = Vector3.zero;
        newly.Init(msg);
        floating.Add(newly);

        var y1 = newly.transform.localPosition.y;


        for (var i = floating.Count; --i >= 0;)
        {
            var old = floating[i];
            var ops = old.tr.localPosition;
            var y0 = ops.y;
            var gap = y0 - y1;

            if (gap >= (labelHeight))
            {
                break;
            }

            ops.y += labelHeight - gap;
            y1 = ops.y;
            old.tr.localPosition = ops;
//            old.tr.DOLocalMove(ops, 0.6f);
        }
    }

    public void Clear()
    {
        if (oncomplete != null)
        {
            oncomplete();
        }
        floating.Clear();
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(UIExpMsg))]
public class UIExpMsgEditor : Editor
{
    public float testCount = 0;
    private UIExpMsg obj;

    public override void OnInspectorGUI()
    {
        obj = target as UIExpMsg;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("1.运行  2.点击开始");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("开始"))
        {
            var clone = GameObject.Instantiate(obj.prefab);
            obj.Append(clone.GetComponent<ExpAnimator>(), "测试文字" + testCount);
            testCount += 1;
        }
        if (GUILayout.Button("开始多个"))
        {
            for (int idx = 0; idx < 10; idx++)
            {
                var clone = GameObject.Instantiate(obj.prefab);
                obj.Append(clone.GetComponent<ExpAnimator>(), "测试文字" + idx);
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