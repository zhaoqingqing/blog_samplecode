using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KEngine;

/// <summary>
/// Detail		:  简单的绘制实现，鼠标按下并拖动即可画线段，重新按下画新线段
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class PaintController : MonoBehaviour
{
    private Vector3 DrawPosition;
    //索引  
    private int DrawIndex = 0;
    //端点数  
    private int LengthOfLineRenderer = 0;
    private bool IsDrawIng = false;
    private int LineCount = 0;
    private float LastPosX, LastPosY;

    private List<LineRenderer> DrawLines = new List<LineRenderer>();
    public LineRenderer CurLineRenderer;

    void Update()
    {
        //鼠标左击  
        if (Input.GetMouseButtonDown(0))
        {
            Log.Info("click down");
            if (CurLineRenderer == null)
            {
                CurLineRenderer = CreateLine();
            }
            IsDrawIng = true;
        }
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        else if(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
        {
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            Log.Info("click up");
            DrawIndex = 0;
            LengthOfLineRenderer = 0;
            CurLineRenderer = null;
            IsDrawIng = false;
        }

        if (IsDrawIng)
        {
            //将鼠标点击的屏幕坐标转换为世界坐标，然后存储到position中  
            if (Input.mousePosition.x == LastPosX && Input.mousePosition.y == LastPosY)
            {
                return;
            }
            if (CurLineRenderer == null)
            {
                CurLineRenderer = CreateLine();
            }

            DrawPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            LastPosX = Input.mousePosition.x;
            LastPosY = Input.mousePosition.y;

            //端点数+1  
            LengthOfLineRenderer++;
            //设置线段的端点数  
            CurLineRenderer.SetVertexCount(LengthOfLineRenderer);
            //连续绘制线段  
            while (DrawIndex < LengthOfLineRenderer)
            {
                //两点确定一条直线，所以我们依次绘制点就可以形成线段了  
                CurLineRenderer.SetPosition(DrawIndex, DrawPosition);
                Log.Info("paint,DrawIndex:{0},DrawPosition:{1}", DrawIndex, DrawPosition);
                DrawIndex++;
            }
        }
    }

    void OnGUI()
    {
        GUILayout.Label("当前鼠标X轴位置：" + Input.mousePosition.x);
        GUILayout.Label("当前鼠标Y轴位置：" + Input.mousePosition.y);
        if (GUILayout.Button("Back"))
        {
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(100, 100, 100, 40), "Clear"))
        {
            ClearLine();
        }
    }

    void ClearLine()
    {
        if (DrawLines != null && DrawLines.Count > 0)
        {
            foreach (LineRenderer lineRenderer in DrawLines)
            {
                Destroy(lineRenderer.gameObject);
            }
            DrawLines.Clear();
        }
    }

    LineRenderer CreateLine()
    {
        var obj = new GameObject("line" + LineCount);
        LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();
        //设置材质  
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //设置颜色  
        lineRenderer.SetColors(Color.red, Color.yellow);
        //设置宽度  
        lineRenderer.SetWidth(0.02f, 0.02f);
        LineCount += 1;
        DrawLines.Add(lineRenderer);
        return lineRenderer;
    }


}
