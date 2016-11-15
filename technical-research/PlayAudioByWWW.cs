using System;
using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Detail		:  使用WWW播放音频文件
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class PlayAudioByWWW : MonoBehaviour
{
    private AudioSource curAudioSource;
    public AudioSource CurAudioSource
    {
        get
        {
            if (curAudioSource != null) return curAudioSource;
            curAudioSource = gameObject.GetComponent<AudioSource>();
            if (curAudioSource == null)
            {
                curAudioSource = gameObject.AddComponent<AudioSource>();
                curAudioSource.playOnAwake = false;
                curAudioSource.maxDistance = 1.1f;
            }
            return curAudioSource;
        }
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(100, 200, 150, 90), "Stop"))
        {
            if (CurAudioSource != null) CurAudioSource.Stop();
        }
        if (GUI.Button(new Rect(300, 200, 150, 90), "Play-MP3"))
        {
            string audioPath = "/storage/emulated/0/music/千里之外.mp3";

            PlayLocalFile(audioPath);
        }

        if (GUI.Button(new Rect(100, 300, 150, 90), "Play-OGG"))
        {
            string audioPath = "/storage/emulated/0/music/爱上你万岁.ogg";
            PlayLocalFile(audioPath);
        }

        if (GUI.Button(new Rect(300, 300, 150, 90), "Play-wav"))
        {
            string audioPath = "/storage/emulated/0/music/梁静茹_宁夏.wav";
            PlayLocalFile(audioPath);
        }
    }

    void PlayLocalFile(string audioPath)
    {
        var exists = File.Exists(audioPath);
        Debug.LogFormat("{0}，存在:{1}", audioPath, exists);
        StartCoroutine(LoadAudio(audioPath, (audioClip) =>
        {
            CurAudioSource.clip = audioClip;
            CurAudioSource.Play();
        }));
    }

    IEnumerator LoadAudio(string filePath, Action<AudioClip> loadFinish)
    {
        //安卓和PC上的文件路径
        filePath = "file:///" + filePath;
        Debug.LogFormat("local audioclip :{0}", filePath);
        WWW www = new WWW(filePath);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            AudioClip audioClip = null;
            //OGG文件会报：Streaming of 'ogg' on this platform is not supported
            //if (filePath.EndsWith("ogg"))
            //{
            //    audioClip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
            //}
            //else
            {
                audioClip = www.audioClip;
            }
            loadFinish(audioClip);
        }
        else
        {
            Debug.LogErrorFormat("www load file error:{0}", www.error);
        }
    }
}
