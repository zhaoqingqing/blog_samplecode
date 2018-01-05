using UnityEngine;
using System.Collections.Generic;
using XLua;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreatureGizmosHelper : MonoBehaviour
{
    public Vector3 TargetPos { get; set; }
    public LuaTable LuaRef;
    private static GUIStyle gui;

#if UNITY_EDITOR

    private void Start()
    {
        if (gui == null)
            gui = new GUIStyle();
        gui.normal.textColor = Color.red;
        gui.fontSize = 15;
    }

    void OnDrawGizmosSelected()
    {
        DrawDumpFunc();
        DrawNavMeshLine();
    }

    void DrawDumpFunc()
    {
        if (LuaRef != null)
        {
            var func = LuaRef.Get<LuaFunction>("Dump");
            if (func != null)
            {
                object[] objs = func.Call(LuaRef);
                if (objs != null && objs.Length > 0)
                {
                    Handles.Label(Position, (string) objs[0], gui);
                    if (objs.Length > 1 && objs[1] != null)
                    {
						//如果有更多的数据返回，进行处理
                        var posArr = objs[1] as LuaTable;
                        posArr.ForEach<int, Vector3>((index, pos) =>
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawSphere(pos, 1f);
                        });
                    }           
                }
            }
        }
    }

    void DrawNavMeshLine()
    {
        var nav = GetComponent<NavMeshAgent>();
        if (nav == null || nav.path == null)
            return;

        var line = this.GetComponent<LineRenderer>();
        if (line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.SetWidth(1.5f, 1.5f);
            line.SetColors(Color.yellow, Color.yellow);
        }

        var path = nav.path;

        line.SetVertexCount(path.corners.Length);
//        Debug.Log(path.corners.Length);
        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
    }
#endif
}
