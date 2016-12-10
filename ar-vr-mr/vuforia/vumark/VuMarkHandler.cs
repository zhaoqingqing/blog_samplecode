/*===============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.

Confidential and Proprietary - Protected under copyright and other laws.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Vuforia;


/// <summary>
/// A custom handler which uses the vuMarkManager.
/// </summary>
public class VuMarkHandler : MonoBehaviour
{
    #region PRIVATE_MEMBER_VARIABLES

    private PanelShowHide mIdPanel;
    private VuMarkManager mVuMarkManager;
    private VuMarkTarget mClosestVuMark;
    private VuMarkTarget mCurrentVuMark;

    #endregion // PRIVATE_MEMBER_VARIABLES


    #region UNTIY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        mIdPanel = GetComponent<PanelShowHide>();

        // register callbacks to VuMark Manager
        mVuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        mVuMarkManager.RegisterVuMarkDetectedCallback(OnVuMarkDetected);
        mVuMarkManager.RegisterVuMarkLostCallback(OnVuMarkLost);
    }

    void Update()
    {
        UpdateClosestTarget();
    }

    void OnDestroy()
    {
        // unregister callbacks from VuMark Manager
        mVuMarkManager.UnregisterVuMarkDetectedCallback(OnVuMarkDetected);
        mVuMarkManager.UnregisterVuMarkLostCallback(OnVuMarkLost);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// This method will be called whenever a new VuMark is detected
    /// </summary>
    public void OnVuMarkDetected(VuMarkTarget target)
    {
        Debug.Log("New VuMark: " + GetVuMarkString(target));
    }

    /// <summary>
    /// This method will be called whenever a tracked VuMark is lost
    /// </summary>
    public void OnVuMarkLost(VuMarkTarget target)
    {
        Debug.Log("Lost VuMark: " + GetVuMarkString(target));

        if (target == mCurrentVuMark)
            mIdPanel.ResetShowTrigger();
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS

    void UpdateClosestTarget()
    {
        Camera cam = DigitalEyewearBehaviour.Instance.PrimaryCamera ?? Camera.main;

        float closestDistance = Mathf.Infinity;

        foreach (var bhvr in mVuMarkManager.GetActiveBehaviours())
        {
            Vector3 worldPosition = bhvr.transform.position;
            Vector3 camPosition = cam.transform.InverseTransformPoint(worldPosition);

            float distance = Vector3.Distance(Vector2.zero, camPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                mClosestVuMark = bhvr.VuMarkTarget;
            }
        }

        if (mClosestVuMark != null &&
            mCurrentVuMark != mClosestVuMark)
        {
            var vuMarkId = GetVuMarkString(mClosestVuMark);
            var vuMarkTitle = GetVuMarkDataType(mClosestVuMark);
            var vuMarkImage = GetVuMarkImage(mClosestVuMark);
            
            mCurrentVuMark = mClosestVuMark;
            mIdPanel.Hide();
            StartCoroutine(ShowPanelAfter(0.5f, vuMarkTitle, vuMarkId, vuMarkImage));
        }
    }

    private IEnumerator ShowPanelAfter(float seconds, string vuMarkTitle, string vuMarkId, Sprite vuMarkImage)
    {
        yield return new WaitForSeconds(seconds);

        mIdPanel.Show(vuMarkTitle, vuMarkId, vuMarkImage);
    }

    private string GetVuMarkDataType(VuMarkTarget vumark)
    {
        switch (vumark.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return "Bytes";
            case InstanceIdType.STRING:
                return "String";
            case InstanceIdType.NUMERIC:
                return "Numeric";
        }
        return "";
    }

    private string GetVuMarkString(VuMarkTarget vumark)
    {
        switch (vumark.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return vumark.InstanceId.HexStringValue;
            case InstanceIdType.STRING:
                return vumark.InstanceId.StringValue;
            case InstanceIdType.NUMERIC:
                return vumark.InstanceId.NumericValue.ToString();
        }
        return "";
    }

    private Sprite GetVuMarkImage(VuMarkTarget vumark)
    {
        var instanceImg = vumark.InstanceImage;
        if (instanceImg == null)
        {
            Debug.Log("VuMark Instance Image is null.");
            return null;
        }

        // First we create a texture
        Texture2D texture = new Texture2D(instanceImg.Width, instanceImg.Height, TextureFormat.RGBA32, false);
        texture.wrapMode = TextureWrapMode.Clamp;
        instanceImg.CopyToTexture(texture);
        texture.Apply();

        // Then we turn the texture into a Sprite
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        return Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
    }

    #endregion // PRIVATE_METHODS
}

