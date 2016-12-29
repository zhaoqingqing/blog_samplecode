using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// Detail		:  事件管理器,类似NGUI的UIEventListener
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class EventTriggerListener : EventTrigger
{
    public delegate void VoidDelegate(GameObject sender);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidDelegate onSelect;
    public VoidDelegate onUpdateSelect;

    static public EventTriggerListener AddEeventListener(GameObject sender)
    {
        EventTriggerListener listener = sender.GetComponent<EventTriggerListener>();
        if (listener == null)
            listener = sender.AddComponent<EventTriggerListener>();
        return listener;
    }


    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null)
            onClick(gameObject);
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null)
            onDown(gameObject);
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null)
            onEnter(gameObject);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null)
            onExit(gameObject);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null)
            onUp(gameObject);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null)
            onSelect(gameObject);
    }

    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null)
            onUpdateSelect(gameObject);
    }
}