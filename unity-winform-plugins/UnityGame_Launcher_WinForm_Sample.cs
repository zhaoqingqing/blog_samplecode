using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using YL.Lanucher;
using YL.Lanucher.Properties;
using Cursor=System.Windows.Forms.Cursor;
//using Timer = System.Windows.Forms.Timer;
using Timer = System.Timers.Timer;
//using Timer = System.Threading.Timer;
public partial class LauncherForm : Form
{
    #region 注册窗体可拖动
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_MOVE = 0xF010;
    public const int HTCAPTION = 0x0002;
    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        MouseDown_Drag(sender, e);
    }

    private void background_MouseDown(object sender, MouseEventArgs e)
    {
        MouseDown_Drag(sender, e);
    }

    private void bottomText_MouseDown(object sender, MouseEventArgs e)
    {
        MouseDown_Drag(sender, e);
    }

    private void MouseDown_Drag(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
    }
    #endregion
    public enum AnimType
    {
        CloseButton, MiniButton, LinkButton
    }

    private Dictionary<AnimType, string> m_animDict;

    private Dictionary<AnimType, string> AnimDict
    {
        get
        {
            if (m_animDict == null)
            {
                //init
                m_animDict = new Dictionary<AnimType, string>();
                m_animDict.Add(AnimType.CloseButton, "close|close2");
                m_animDict.Add(AnimType.MiniButton, "suoxiao|suoxiao2");
                m_animDict.Add(AnimType.LinkButton, "btnboard|button");
            }
            return m_animDict;
        }
    }
    private Dictionary<int, string> m_animDictEx;
    //key=1,2,3,4
    private Dictionary<int, string> AnimDictEx
    {
        get
        {
            if (m_animDictEx == null)
            {
                //init
                m_animDictEx = new Dictionary<int, string>();

                m_animDictEx.Add(1, "url1_1|url1_2");
                m_animDictEx.Add(2, "url2_1|url2_2");
                m_animDictEx.Add(3, "url3_1|url3_2");
                m_animDictEx.Add(4, "url4_1|url4_2");
            }
            return m_animDictEx;
        }
    }
    public void MouseEvent(object sender, EventArgs eventArgs, AnimType animType, bool enter)
    {
        if (AnimDict.ContainsKey(animType) == false)
        {
            return;
        }
        var picArray = AnimDict[animType].Split('|');
        if (picArray.Length < 2)
        {
            return;
        }
        var hoverPicName = enter ? picArray[1] : picArray[0];
        if (sender is PictureBox)
        {
            //FIX PictureBox无法获得图片的Name
            var pictureBox = sender as PictureBox;
            var obj = Resources.ResourceManager.GetObject(hoverPicName);
            if (obj != null)
            {
                pictureBox.Image = obj as Image;
            }
        }
    }
    public void MouseEvent(object sender, EventArgs eventArgs, int animType, bool enter)
    {
        if (AnimDictEx.ContainsKey(animType) == false)
        {
            return;
        }
        var picArray = AnimDictEx[animType].Split('|');
        if (picArray.Length < 2)
        {
            return;
        }
        var hoverPicName = enter ? picArray[1] : picArray[0];
        if (sender is PictureBox)
        {
            //FIX PictureBox无法获得图片的Name
            var pictureBox = sender as PictureBox;

            var obj = Resources.ResourceManager.GetObject(hoverPicName);
            if (obj != null)
            {
                pictureBox.Image = obj as Image;
            }
        }
    }
    public int ButtonGetIdx(PictureBox button)
    {
        int btnIndex = 0;
        //TODO 根据实际需求
        //if (button == btn1 || button == btn1Label) btnIndex = 1;
        //if (button == btn2 || button == btn2Label) btnIndex = 2;
        //if (button == btn3 || button == btn3Label) btnIndex = 3;
        //if (button == btn4 || button == btn4Label) btnIndex = 4;
        return btnIndex;
    }

    private WebBrowser webLogin;
    public void Init()
    {
        webLogin.Navigating += OnWebLogin_Navigating;
        webLogin.Navigated += WebLogin_Navigated;

        List<PictureBox> UrlBtnBg = new List<PictureBox>();
        //UrlBtnBg.Add(btn1);//TODO 根据实际需求
        //UrlBtnBg.Add(btn2);
        //UrlBtnBg.Add(btn3);
        //UrlBtnBg.Add(btn4);
        //按钮文字动画
        List<PictureBox> UrlBtnPic = new List<PictureBox>();
        //UrlBtnPic.Add(btn1Label);//TODO 根据实际需求
        //UrlBtnPic.Add(btn2Label);
        //UrlBtnPic.Add(btn3Label);
        //UrlBtnPic.Add(btn4Label);
        foreach (var button in UrlBtnBg)
        {
            button.MouseEnter += (sender, args) =>
            {
                MouseEvent(sender, args, AnimType.LinkButton, true);
                int urlIndex = ButtonGetIdx(button);
                if (urlIndex - 1 < UrlBtnPic.Count)
                {
                    var background = UrlBtnPic[urlIndex - 1];
                    MouseEvent(background, args, urlIndex, true);
                }
            };
            button.MouseLeave += (sender, args) =>
            {
                MouseEvent(sender, args, AnimType.LinkButton, false);
                int urlIndex = ButtonGetIdx(button);
                if (urlIndex - 1 <= UrlBtnPic.Count)
                {
                    var background = UrlBtnPic[urlIndex - 1];
                    MouseEvent(background, args, urlIndex, false);
                }
            };
            button.MouseClick += (sender, args) =>
            {
                int urlIndex = ButtonGetIdx(button);
                FormController.Instance.NavigateURL(sender, args, urlIndex);
            };
            button.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }

    //更简单的方法对按钮绑定事件？局部变量导致每次点击 index不一致
    //for (int idx = 0; idx<UrlBtnBg.Count; idx++)
    //{
    //	UrlBtnBg[idx].MouseEnter += (sender, args) => { MouseEvent(background, args, idx, true);};
    //  UrlBtnBg[idx].MouseLeave += (sender, args) => { MouseEvent(background, args, idx, false); };
    //	UrlBtnBg[idx].MouseClick += (sender, args) => { FormController.Instance.NavigateURL(sender, args, idx); };
    //}

    void OnWebLogin_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e)
    {
        string info = webLogin.Url.AbsoluteUri;
        //TODO 忽略大小写
        if (info.Contains("username") && info.Contains("Sign") && info.Contains("ts"))
        {
            this.TopMost = false;
            FormController.Instance.StartGame(info);
            //延时几秒再关闭
            //if (CurrentTimer != null)
            //{
            //    CurrentTimer.Start();
            //}
        }
    }

    private void WebLogin_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
        //选服页面，运营自动添加scrollbar，方便服务器列表很长滑动
        string info = webLogin.Url.AbsoluteUri;
        Console.WriteLine(info);
        if (info.Contains("client_login"))
            webLogin.ScrollBarsEnabled = false;
        if (info.Contains("client_start"))
            webLogin.ScrollBarsEnabled = true;
    }
}