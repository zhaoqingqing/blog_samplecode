using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UI事件点击事件监听器，不包含Drag事件
/// 避免在ScrooRect中Drag事件被拦截
/// </summary>
public class UIClickListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler,  IPointerEnterHandler,IPointerClickHandler
{
    //按住持续多长时间触发长按事件
    public float durationThreshold = 1.0f;

    public Action onLongPress;
    public Action PointerUpEvent;
    public Action PointerEnterEvent;
    public Action PointerExitEvent;
    public Action onClick;

    private bool isPointerDown = false;
    public bool IsPointerDown
    {
        get { return isPointerDown; }
        private set { isPointerDown = value; }
    }
    private bool longPressTriggered = false;
    private float timePressStarted;

    public static UIClickListener Get(GameObject go)
    {
        if (go == null) return null;
        UIClickListener listener = go.GetComponent<UIClickListener>();
        if (listener == null)
            listener = go.AddComponent<UIClickListener>();
        return listener;
    }

    public static UIClickListener Get(Component go)
    {
        if (go == null) return null;
        return Get(go.gameObject);
    }

    private void Update()
    {
        if (IsPointerDown && !longPressTriggered)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                //longPressTriggered = true; //测试时注释这行
                if (onLongPress != null) onLongPress.Invoke();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timePressStarted = Time.time;
        IsPointerDown = true;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPointerDown = false;
        if (PointerUpEvent != null) PointerUpEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (PointerExitEvent != null) PointerExitEvent.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PointerEnterEvent != null) PointerEnterEvent.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //OnPointerDownon和OnPointerClick只触发一个
        if (onClick != null) onClick.Invoke();
    }
}