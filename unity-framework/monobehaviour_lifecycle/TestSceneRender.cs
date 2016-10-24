using System;
using UnityEngine;
public class TestSceneRender : MonoBehaviour
{

    // OnPreCull is called before a camera culls the scene
    public void OnPreCull()
    {
        Logs.DoLog();
    }

    // OnPreRender is called before a camera starts rendering the scene
    public void OnPreRender()
    {
        Logs.DoLog();

    }

    // Callback that is sent if an associated RectTransform has it's dimensions changed
    public void OnRectTransformDimensionsChange()
    {
        Logs.DoLog();
    }

    // Callback that is sent if an associated RectTransform is removed
    public void OnRectTransformRemoved()
    {
        Logs.DoLog();
    }

    // OnRenderImage is called after all rendering is complete to render image
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Logs.DoLog();
    }

    // OnRenderObject is called after camera has rendered the scene
    public void OnRenderObject()
    {
        Logs.DoLog();
    }


    // OnWillRenderObject is called once for each camera if the object is visible
    public void OnWillRenderObject()
    {
        Logs.DoLog();
    }

    // Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected
    public void OnDrawGizmos()
    {
        Logs.DoLog();
    }

    // OnGUI is called for rendering and handling GUI events
    public void OnGUI()
    {
        Logs.DoLog();
    }
}