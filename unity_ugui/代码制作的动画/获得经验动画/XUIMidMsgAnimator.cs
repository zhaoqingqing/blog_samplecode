using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using DG.Tweening;


/// <summary>
/// Detail		:  自动绑定在MsgTemplate上，单个MsgTemplate的行为
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class XUIMidMsgAnimator : MonoBehaviour
{
    public XUIMidMsg UICtrler;
    public Text msgLabel;
    public CanvasGroup msgCanvas;
    public RectTransform mRectTransform;
    public float MSG_TIME = 1.2f; // 持续时间
    public float FADE_IN = 0.23f; // 出现渐变效果时间
    public float FADE_OUT = 0.43f; // 消失渐变效果时间
    public float MSG_HEIGHT = 100f; // 向上的位移
    public Ease MSG_EASE = Ease.Linear;


    public void Awake()
    {
        mRectTransform = transform.GetComponent<RectTransform>();
        if (msgLabel)
        {
            msgLabel.text = "";
        }
    }

    /// <summary>
    /// 当打开其它界面时，这个会被隐藏，协程也会被停止，但不能直接从队列中移除，因为动画未播放完
    /// </summary>
    private void OnDisable()
    {

    }

    public void StartAnimate(string msgStr)
    {
        if (msgLabel == null)
        {
            msgLabel = GetComponentInChildren<Text>(true);
        }
        if (msgCanvas == null)
        {
            msgCanvas = GetComponent<CanvasGroup>();
        }
        Debug.Assert(msgLabel);
        Debug.Assert(msgCanvas);
        msgLabel.text = msgStr;
        GameLauncher.Instance.StartCoroutine(MsgCoroutine());

    }

    // 出现动画
    IEnumerator MsgCoroutine()
    {
        //淡入
        msgCanvas.alpha = 0;
        msgCanvas.DOFade(1, FADE_IN);

        mRectTransform.DOAnchorPosY(MSG_HEIGHT, MSG_TIME).SetEase(MSG_EASE);

        yield return new WaitForSeconds(MSG_TIME - FADE_OUT);   // 等待淡入和上升

        yield return GameLauncher.Instance.StartCoroutine(WaitMsgDelete());
    }

    public IEnumerator WaitMsgDelete()
    {
        msgCanvas.DOFade(0, FADE_OUT);
        yield return new WaitForSeconds(FADE_OUT);  // 等待淡出动画
        msgLabel.text = "";
        StopAnimate();
        UICtrler.PoolDelete(this);
    }

    public void StopAnimate()
    {
        StopAllCoroutines();
        msgCanvas.DOKill();
        mRectTransform.DOKill();

        var childs = gameObject.GetComponents<Transform>();
        // 清理残留动画
        for (int index = 0; index < childs.Length; index++)
        {
            childs[index].DOKill();
        }
    }
}
