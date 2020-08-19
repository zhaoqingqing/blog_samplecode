using UnityEngine;
using System.Collections;

//bind this scripts to gameobject
public class DoubleClickShow : MonoBehaviour {

    private bool ButtonClicked = false;
    private float ResetTime = 0.0f;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.5f - 40, 10, 80, 50), "Debug"))
        {
            ResetTime = Time.time;
            if (ButtonClicked)
            {
                ButtonClicked = false;
                Debug.Log("It's DoubleClick!");
                ReporterExpand.ShowOrHide();
            }
            else
            {
                ButtonClicked = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (ResetTime + 0.5 < Time.time)
        {
            ButtonClicked = false;
        }
    }
}
