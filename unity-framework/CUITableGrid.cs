using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Table+Grid, 加强版
/// </summary>
#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class CUITableGrid : MonoBehaviour, IEnumerable<Transform>
{

    public int ColumnCount = 5;
    public float CellWidth = 50;
    public float CellHeight = 50;


    private Transform _Transform;

    public Transform this[int index]
    {
        get { return transform.GetChild(index); }
    }

    private UIScrollView _scrollView;

    public int Count
    {
        get { return transform.childCount; }
    }
    protected virtual void Awake()
    {
        _Transform = transform;
        _scrollView = GetComponent<UIScrollView>();
    }


    protected virtual void Start()
    {
        //Reposition();
    }

    /// <summary>
    /// 把一个对象设置进去，传入行列
    /// </summary>
    /// <param name="trans"></param>
    public void SetAsChild(Transform trans, int row, int col)
    {
        CTool.SetChild(trans, _Transform);
        trans.localPosition = new Vector3((col - 1) * CellWidth, -(row - 1) * CellHeight);
    }


    /// <summary>
    /// 必须手动Reposition
    /// </summary>
    /// <param name="startRow"></param>
    public virtual void Reposition(int startRow = 1)
    {
        //fix 预加载没有执行Awake?此_Transform是null
        _Transform = transform;
        int row = startRow;
        int col = 1;
        for (int i = 0; i < _Transform.childCount; i++)
        {
            var trans = _Transform.GetChild(i);
            trans.localPosition = new Vector3((col - 1)*CellWidth, -(row - 1)*CellHeight);

            col++;
            if (col > ColumnCount)
            {
                row++;
                col = 1;
            }
        }

        if (_scrollView != null)
        {
            _scrollView.UpdatePosition();
            _scrollView.ResetPosition();
        }
    }

    public IEnumerator<Transform> GetEnumerator()
    {
        return _GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _GetEnumerator();
    }

    IEnumerator<Transform> _GetEnumerator()
    {
        for (int idx = 0; idx < transform.childCount; idx++)
        {
            Transform trans = transform.GetChild(idx);
            if (trans.gameObject.activeSelf)
                yield return trans;
        }
    }

}

#if UNITY_EDITOR

[CustomEditor(typeof(CUITableGrid))]
public class CUITableGridInspector : Editor
{
    override public void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reposition"))
        {
            var grid = (CUITableGrid)target;
            grid.Reposition();
        }
    }
}
#endif