using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ReporterMessageReceiver : MonoBehaviour
{
    public EventSystem UGUIEvent;
    Reporter reporter;
    void Start()
    {
        reporter = gameObject.GetComponent<Reporter>();
        UGUIEvent = EventSystem.current;
    }

    void OnPreStart()
    {
        //To Do : this method is called before initializing reporter, 
        //we can for example check the resultion of our device ,then change the size of reporter
        if (reporter == null)
            reporter = gameObject.GetComponent<Reporter>();

        if (Screen.width < 1000)
            reporter.size = new Vector2(32, 32);
        else
            reporter.size = new Vector2(48, 48);

        reporter.UserData = "Put user date here like his account to know which user is playing on this device";
    }
    void OnHideReporter()
    {
        //TO DO : resume your game
        //NOTE if use ngui enable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = true;
        //    UICamera.eventHandler.useTouch = true;
        //}
        if (UGUIEvent)
        {
            UGUIEvent.enabled = true;
        }
    }

    void OnShowReporter()
    {
        //TO DO : pause your game and disable its GUI
        //NOTE if use ngui disable input
        //if (UICamera.eventHandler != null)
        //{
        //    UICamera.eventHandler.useMouse = false;
        //    UICamera.eventHandler.useTouch = false;
        //}
        if (UGUIEvent)
        {
            UGUIEvent.enabled = false;
        }
    }

    void OnLog(Reporter.Log log)
    {
        //TO DO : put you custom code 
    }



}
