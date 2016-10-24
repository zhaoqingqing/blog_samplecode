using System;
using UnityEngine;
using System.Collections;

public class TestPhysicOrder : MonoBehaviour
{
    // Reset to default values
    public void Reset()
    {
        Logs.DoLog();
    }

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        StartCoroutine(YieldOneFrame());
        StartCoroutine(YieldEndOfFrame());
        StartCoroutine(YieldWaitForFixedUpdate());
        Logs.DoLog();
    }

    // This function is called when the object becomes enabled and active
    public void OnEnable()
    {
        Logs.DoLog();
    }

    // Use this for initialization
    void Start()
    {
        Logs.DoLog();
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    public void FixedUpdate()
    {
        Logs.DoLog();
    }

    // Update is called once per frame
    void Update()
    {
        Logs.DoLog();
    }

    IEnumerator YieldWaitForFixedUpdate()
    {
        yield return new WaitForFixedUpdate();
        Logs.DoLog("WaitForFixedUpdate");
    }

    IEnumerator YieldOneFrame()
    {
        yield return 1;
        Logs.DoLog("YieldOneFrame");
    }

    IEnumerator YieldEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        Logs.DoLog("YieldEndOfFrame");
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    public void LateUpdate()
    {
        Logs.DoLog();
    }

    // This function is called when the behaviour becomes disabled or inactive
    public void OnDisable()
    {
        Logs.DoLog();
    }

    // This function is called when the MonoBehaviour will be destroyed
    public void OnDestroy()
    {
        Logs.DoLog();
    }

    // Sent to all game objects when the player gets or looses focus
    public void OnApplicationFocus(bool focus)
    {
        Logs.DoLog();
    }

    // Sent to all game objects when the player pauses
    public void OnApplicationPause(bool pause)
    {
        Logs.DoLog();
    }

    // Sent to all game objects before the application is quit
    public void OnApplicationQuit()
    {
        Logs.DoLog();
    }

}