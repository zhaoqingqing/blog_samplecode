using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR

/// <summary>
/// 添加此脚本给Animator，即可调试当前播放的StateName
/// </summary>
public class GetPlayingAnim : MonoBehaviour
{
    public Animator animator;
    public UnityEditor.Animations.AnimatorController ac;
    public List<string> animNames = new List<string>();

    public string currentPlayingName;
    public bool playingEnd = false;
    public float animPercent = 0.0f;
    public bool isInit = false;

    public static GetPlayingAnim Create(GameObject attachObj)
    {
        if (attachObj == null) return null;
        if (attachObj.GetComponent<Animator>() == null)
        {
            Debug.LogErrorFormat("{0} 没有Animator组件！！！", attachObj.name);
            return null;
        }
        GetPlayingAnim component = attachObj.GetComponent<GetPlayingAnim>() ?? attachObj.AddComponent<GetPlayingAnim>();
        component.GetAllState();
        return component;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInit) return;
        GetCurrentPlay();
    }

    public void GetAllState()
    {
        animator = gameObject.GetComponent<Animator>();
        if (animator == null || animator.runtimeAnimatorController == null)
        {
            Debug.LogErrorFormat("{0} 没有Animator组件或Animator.AnimatorController为空！！！", gameObject.name);
            return;
        }
        ac = animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

        animNames.Clear();
        var clips = ac.animationClips;
        foreach (AnimationClip animationClip in clips)
        {
            animNames.Add(animationClip.name);
            //Debug.Log(animationClip.name);
        }
        isInit = true;
    }

    public void GetCurrentPlay()
    {
        if (animNames != null && animNames.Count > 0)
        {
            var animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animStateInfo.loop)
            {
                animPercent = Mathf.Repeat(animStateInfo.normalizedTime, 1);
            }
            else
            {
                animPercent = animStateInfo.normalizedTime;
            }

            playingEnd = animPercent >= 0.95f;

            foreach (string animName in animNames)
            {
                if (!playingEnd && animStateInfo.IsName(animName))
                {
                    //Log.Debug("current playing:{0}", animName);
                    currentPlayingName = animName;
                    break;
                }
            }

            if (playingEnd)
            {
                //Log.Debug("{0} playing end", currentPlayingName);
                //currentPlayingName = null;
            }
        }
    }
}
#endif