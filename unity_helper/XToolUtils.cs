using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public partial class XToolUtils
{
	/// <summary>
	/// 转换类型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pObj"></param>
	/// <returns></returns>
	public static T ChangeType<T>(object pObj)
	{
		try
		{
			return (T)System.Convert.ChangeType(pObj, typeof(T));
		}
		catch (Exception ex)
		{
			Debug.LogError("转换类型错误：" + ex);
			return default(T);
		}
	}

	/// <summary>
	/// 切割字符串，获取列表，比如："1,2,3"转换成List<int>{1,2,3}
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pStr"></param>
	/// <param name="pChars"></param>
	/// <returns></returns>
	public static List<T> GetList<T>(string pStr, params char[] pChars)
	{
		List<T> _list = new List<T>();
		if (pChars != null && !string.IsNullOrEmpty(pStr) && pChars.Length > 0)
		{
			string[] _arrays = pStr.Split(pChars, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < _arrays.Length; i++)
			{
				T _temp = ChangeType<T>(_arrays[i]);
				if (_temp != null)
				{
					_list.Add(_temp);
				}
			}
		}
		if (_list.Count == 0)
		{
			Debug.LogError("列表为空！");
		}
		return _list;
	}
	
	//获取当前正在播放的AnimationClip
	 public static string GetCurrentPlayingAnimationClip(GameObject go)
    {
        if (go == null)
        {
            return string.Empty;
        }
        var animation = go.GetComponent<Animation>();
        if (animation == null) return string.Empty;
        foreach (AnimationState anim in animation)
        {
            if (animation.IsPlaying(anim.name))
            {
                return anim.name;
            }
        }
        return string.Empty;
    }
	
	//获取指定AnimationClip的长度
    public static float GetgAnimationClipLength(GameObject go, string animName)
    {
        if (go == null)
        {
            return 0;
        }
        var animation = go.GetComponent<Animation>();
        if (animation == null) return 0;
        var animClip = animation.GetClip(animName);
        if (animation == null) return 0;
        return animClip.length;
    }
}