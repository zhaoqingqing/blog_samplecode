using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ExpAnimator : MonoBehaviour {

    public float timed;
    public Transform tr;
    public CanvasGroup canvasGroup;
    public Text txtMsg;

    public void Awake()
    {
        tr = transform;
        canvasGroup = tr.GetComponent<CanvasGroup>();
        if (txtMsg == null)
        {
            txtMsg = GetComponentInChildren<Text>();
        }

        if (canvasGroup == null)
        {
            canvasGroup = tr.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 1;
    }

    public void Init(string msg)
    {
        txtMsg.text = msg;
    }
}
