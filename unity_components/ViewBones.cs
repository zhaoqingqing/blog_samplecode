using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(ViewBones))]
public class ViewBonesEditor : Editor
{
    private ViewBones compt = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        compt = target as ViewBones;
        if (GUILayout.Button("查看骨骼数"))
        {
            if (compt != null) compt.Show();
        }
    }
}


#endif
/// <summary>
/// 查看骨骼数
/// </summary>
[ExecuteInEditMode]
public class ViewBones : MonoBehaviour
{
    [ContextMenu("查看骨骼数")]
    public void Show()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            Transform[] bones = skinnedMeshRenderer.bones;
            if (bones != null)
            {
                Debug.LogFormat("{0} 有{1}根骨骼", transform.parent.name, bones.Length);
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }


}
