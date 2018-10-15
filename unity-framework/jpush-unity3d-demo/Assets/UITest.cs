using UnityEngine;
using System.Collections;
using JPush;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button btnBack;
    public Button btnSetting;
    public InputField iptSecond;
    public InputField iptPushId;

    private void Awake()
    {
        btnBack.onClick.AddListener(() => { SceneManager.LoadScene("main"); });
        btnSetting.onClick.AddListener(() =>
        {
            var pushId = string.IsNullOrEmpty(iptPushId.text) ? 1 : int.Parse(iptPushId.text);
            var second = string.IsNullOrEmpty(iptSecond.text) ? 1 : int.Parse(iptSecond.text);

            JPushBinding.AddLocalNotification(0, "推送内容", "标题", pushId, second, "");
        });
    }

    // Use this for initialization
    void Start()
    {
        JPushBinding.Init(gameObject.name);
        JPushBinding.SetDebug(true);
    }

}