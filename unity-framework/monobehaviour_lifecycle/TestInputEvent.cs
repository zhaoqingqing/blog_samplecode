using UnityEngine;
using System.Collections;

public class TestInputEvent : MonoBehaviour
{
    // This function is called when the object becomes enabled and active
    public void OnEnable()
    {
        Logs.DoLog();
    }


    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider
    public void OnMouseDown()
    {
        Logs.DoLog();
    }

    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse
    public void OnMouseDrag()
    {
        Logs.DoLog();
    }

    // OnMouseEnter is called when the mouse entered the GUIElement or Collider
    public void OnMouseEnter()
    {
        Logs.DoLog();
    }

    // OnMouseExit is called when the mouse is not any longer over the GUIElement or Collider
    public void OnMouseExit()
    {
        Logs.DoLog();
    }

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider
    public void OnMouseOver()
    {
        Logs.DoLog();
    }

    // OnMouseUp is called when the user has released the mouse button
    public void OnMouseUp()
    {
        Logs.DoLog();
    }

    // OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed
    public void OnMouseUpAsButton()
    {
        Logs.DoLog();
    }
}
