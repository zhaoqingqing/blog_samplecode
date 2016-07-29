using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Protoc;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Ping = System.Net.NetworkInformation.Ping;
using Random = UnityEngine.Random;

/// <summary>
/// script function
/// 1.网络连接
/// 2.protobuf序列化
/// </summary>
public class UINetConn : MonoBehaviour
{
    public enum LogType
    {
        Normal, Warning, Error
    }

    public class ConnectInfo
    {
        public string ServerIp;
        public int ServerPort;

        public string ToString(bool printLog = false)
        {
            var toString = string.Format("{0}:{1}", ServerIp, ServerPort);
            if (printLog) Debug.LogFormat(toString);
            return toString;
        }
    }

    public C2S_UPDATE_PLAYER.Builder GetPlayer()
    {
        var player = C2S_UPDATE_PLAYER.CreateBuilder();
        player.SetId(Random.Range(1001, 9999).ToString());
        player.SetHp(Random.Range(10, 1000));
        player.SetMp(Random.Range(1, 100));
        return player;
    }

    #region UI控件
    public Button BtnConnect, BtnPing, BtnDisConn, BtnSend, BtnRetry, BtnClearLog;
    public InputField IptSendmsg, IptConnectInfo;
    public Toggle TogCustomServer;
    public Dropdown DropSerList;
    public Text TxtConnInfo;
    public Transform ConnGroup, ConnedGroup;
    public StringBuilder SbLog;
    #endregion

    #region 数据

    public string ChosedServer = string.Empty;
    private bool IsCustomServer = false;
    private bool IsLoopUpdate = true;

    private ConnectInfo m_curConnInfo;
    private ConnectInfo CurConnInfo
    {
        get
        {
            if (m_curConnInfo == null) m_curConnInfo = new ConnectInfo();
            //192.168.1.111:7070
            if (IsCustomServer)
            {
                ChosedServer = IptConnectInfo.text.Trim();
            }
            else
            {
                if (string.IsNullOrEmpty(ChosedServer))
                    ChosedServer = DropSerList.options[0].text.Trim();
            }
            var infos = ChosedServer.Split(':');
            if (infos.Length >= 2)
            {
                m_curConnInfo.ServerIp = infos[0];
                m_curConnInfo.ServerPort = Convert.ToInt32(infos[1]);
            }

            return m_curConnInfo;
        }
    }

    public PackageSocket m_clientConnect;
    public PackageSocket ClientSocket
    {
        get
        {
            if (m_clientConnect == null) m_clientConnect = new PackageSocket();
            return m_clientConnect;
        }
    }
    #endregion

    #region 系统函数
    void Awake()
    {
        ConnGroup = BindTemplte<Transform>("ConnGroup");
        ConnedGroup = BindTemplte<Transform>("ConnedGroup");
        BtnConnect = BindButton("BtnConnect", ConnGroup, OnConnect);
        BtnDisConn = BindButton("BtnDisConn", ConnedGroup, OnDisConn);
        BtnSend = BindButton("BtnSend", ConnedGroup, OnSend);
        BtnRetry = BindButton("BtnRetry", ConnedGroup, OnRetry);
        BtnClearLog = BindButton("BtnClearLog", OnClearLog);
        BtnPing = BindButton("BtnPing", OnPing);

        TogCustomServer = BindTemplte<Toggle>("TogUseInput", ConnGroup);
        TxtConnInfo = BindTemplte<Text>("Image/Text");
        IptConnectInfo = BindTemplte<InputField>("IptConnectInfo", ConnGroup);
        DropSerList = BindTemplte<Dropdown>("DropSerList", ConnGroup);
        IptSendmsg = BindTemplte<InputField>("IptSendMsg", ConnedGroup);

        if (IptConnectInfo) IptConnectInfo.onValueChanged.AddListener(OnInpTxtChange);
        if (TogCustomServer) TogCustomServer.onValueChanged.AddListener(OnTogCustomChange);
        if (DropSerList) DropSerList.onValueChanged.AddListener(OnChoseServer);

        //网络连接事件
        ClientSocket.OnConnect += OnConnectCallback;
        ClientSocket.OnRecvive += OnRecviveCallback;
        ClientSocket.OnDisconnect += OnDisconnectCallback;
    }

    // Use this for initialization
    void Start()
    {
        SetConnState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLoopUpdate)
        {
            ClientSocket.Update();
        }
    }

    // This function is called when the MonoBehaviour will be destroyed
    public void OnDestroy()
    {
        ClientSocket.OnConnect -= OnConnectCallback;
        ClientSocket.OnRecvive -= OnRecviveCallback;
        ClientSocket.OnDisconnect -= OnDisconnectCallback;
    }

    public void OnApplicationQuit()
    {
        ClientSocket.Close();
    }


    #endregion

    #region 网络相关
    public void OnConnectCallback(bool connected)
    {
        //TODO 连接成功之后显示界面
        SetConnState(connected);
        PrintLog("{0} connect result:{1}", CurConnInfo.ToString(), connected);
    }

    public void OnRecviveCallback(byte[] data, int start, int length)
    {
        PrintLog("recv—>byteLength:{0},start:{1},length:{2}", data.Length, start, length);
        //TODO 业务逻辑划分
        //TODO 反序列化数据
        var pkg = PbPkg.ParseFrom(data);
        if (pkg.HasData)
        {
            Debug.LogFormat("recv:id={0}", pkg.Id);
            var player = PbPkg.ParseFrom(pkg.Data).ToBuilder();
            var isPlayer = player is C2S_UPDATE_PLAYER;
            if (player != null)
            {
                PrintLog("recvParse——>type:{0},id:{1},isPlayer:{2}", player.DefaultInstanceForType, player.Id, isPlayer);
            }
        }
        else
        {
            PrintLog("recv data not parse");
            Debug.Log("recv data not parse");
        }
    }

    public void OnDisconnectCallback(SocketError socketError, PackageSocketError packageSocketError)
    {
        //TODO 断开连接
        PrintLog("disconnect:{0},{1}", socketError.ToString(), packageSocketError.ToString());
        SetConnState(false);
    }

    public static bool TestNetConnect(string ip, int port)
    {
        try
        {
            TcpClient tcpClient = new TcpClient(ip, port);
            return tcpClient.Connected;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
    }

    #endregion

    #region UI处理相关
    void SetConnState(bool connected)
    {
        if (ConnGroup) ConnGroup.gameObject.SetActive(!connected);
        if (ConnedGroup) ConnedGroup.gameObject.SetActive(connected);
    }

    public void PrintLog(string msg, params object[] args)
    {
        if (SbLog == null) SbLog = new StringBuilder();
        SbLog.AppendLine(string.Format(msg, args));
        if (TxtConnInfo != null) TxtConnInfo.text = SbLog.ToString();
        Debug.LogFormat(msg, args);
    }
    //TODO print error

    public void ClearPrint()
    {
        if (SbLog != null)
        {
#if UNITY_ANDROID
            SbLog.Clear();
#elif UNITY_STANDALONE
            SbLog = SbLog.Remove(0,SbLog.Length);
#endif
            if (TxtConnInfo != null) TxtConnInfo.text = SbLog.ToString();
        }
    }
    #endregion

    #region 事件区
    void OnChoseServer(int selIdx)
    {
        if (selIdx < DropSerList.options.Count)
        {
            ChosedServer = DropSerList.options[selIdx].text;
            Debug.LogFormat("select server:{0}", ChosedServer);
        }
    }

    void OnInpTxtChange(string val)
    {
        if (IptConnectInfo && !string.IsNullOrEmpty(IptConnectInfo.text))
        {
            ChosedServer = IptConnectInfo.text;
            Debug.LogFormat("select server:{0}", ChosedServer);
        }
    }

    void OnTogCustomChange(bool check)
    {
        if (check && IptConnectInfo && !string.IsNullOrEmpty(IptConnectInfo.text))
        {
            var txt = IptConnectInfo.text.Replace(".", "").Replace(":", "");
            //if (IsNumeric(txt))
            {
                ChosedServer = IptConnectInfo.text;
                IsCustomServer = true;
                Debug.LogFormat("select server:{0}", ChosedServer);
            }
        }
        else
        {
            IsCustomServer = false;
        }
    }

    void OnConnect()
    {
        ClientSocket.Connect(CurConnInfo.ServerIp, CurConnInfo.ServerPort);
        PrintLog("try connect to->{0}:{1}", CurConnInfo.ServerIp, CurConnInfo.ServerPort);
    }

    void OnPing()
    {
        var success = TestNetConnect(CurConnInfo.ServerIp, CurConnInfo.ServerPort);
        PrintLog("connect to->{0},{1}", CurConnInfo.ToString(), success);
        Debug.LogFormat("connect to ->{0},{1}", CurConnInfo.ToString(), success);
    }

    void OnDisConn()
    {
        PrintLog("break connect from:{0}", CurConnInfo.ToString());
        ClientSocket.Close();
    }

    void OnSend()
    {
        if (IptSendmsg && !string.IsNullOrEmpty(IptSendmsg.text))
        {
            PrintLog(IptSendmsg.text);
        }

        //TODO 发送
        var player = GetPlayer();
        byte[] bytes;
        using (MemoryStream stream = new MemoryStream())
        {
            player.Build().WriteTo(stream);
            bytes = stream.ToArray();
        }

        var pkg = PbPkg.CreateBuilder();
        pkg.Id = 1001;
        pkg.Data = player.Build().ToByteString();
        var pkgBytes = pkg.Build().ToByteArray();

        ClientSocket.Send(pkgBytes, 0, pkgBytes.Length);
        Debug.LogFormat("start send->pkgBytes.Length{0}", pkgBytes.Length);
    }

    void OnRetry()
    {
        OnConnect();
        ClientSocket.SendPing();
    }

    void OnClearLog()
    {
        ClearPrint();
    }

    #endregion

    #region 公用函数

    void BindButton(Button btn, UnityAction clickEvent)
    {
        if (btn != null)
        {
            btn.onClick.AddListener(clickEvent);
        }
    }

    Button BindButton(string path, UnityAction clickEvent)
    {
        var btn = BindTemplte<Button>(path);
        if (btn != null)
        {
            btn.onClick.AddListener(clickEvent);
            return btn;
        }
        return null;
    }

    void BindButton(string path, GameObject parent, UnityAction clickEvent)
    {
        if (parent != null)
        {
            BindButton(path, parent.transform, clickEvent);
        }
    }

    Button BindButton(string path, Transform parent, UnityAction clickEvent)
    {
        var btn = BindTemplte<Button>(path, parent);
        if (btn != null)
        {
            btn.onClick.AddListener(clickEvent);
            return btn;
        }
        return null;
    }

    T BindTemplteObj<T>(string path, GameObject parent = null) where T : Component
    {
        Transform trans = null;
        if (parent != null) trans = parent.transform;

        return BindTemplte<T>(path, trans);
    }

    T BindTemplte<T>(string path, Transform parent = null) where T : Component
    {
        if (parent == null) parent = transform;
        var child = parent.FindChild(path);
        if (child != null)
        {
            var component = child.GetComponent<T>();
            return component;
        }
        return default(T);
    }

    static bool IsNumeric(object value)
    {
        if (value is sbyte) return true;
        if (value is byte) return true;
        if (value is short) return true;
        if (value is ushort) return true;
        if (value is int) return true;
        if (value is uint) return true;
        if (value is long) return true;
        if (value is ulong) return true;
        if (value is float) return true;
        if (value is double) return true;
        if (value is decimal) return true;
        return false;
    }

    #endregion

    #region protobuf序列/反序列化Demo
    public string PlayerDataFile
    {
        get
        {
            var filePath = Path.Combine(Application.dataPath, @"Scritps\NetTest\player.data");
            return filePath;
        }
    }

    public void EnCodePlayer()
    {
        if (File.Exists(PlayerDataFile) == false)
        {
            File.Create(PlayerDataFile);
            Debug.LogFormat("create file {0}", PlayerDataFile);
        }
        var player = GetPlayer();

        using (FileStream stream = File.OpenWrite(PlayerDataFile))
        {
            player.Build().WriteTo(stream);
        }
    }
    public void DeCodePlayer()
    {
        if (File.Exists(PlayerDataFile) == false)
        {
            Debug.LogErrorFormat("{0} 找不到", PlayerDataFile);
        }
        using (Stream stream = File.OpenRead(PlayerDataFile))
        {
            C2S_UPDATE_PLAYER player = C2S_UPDATE_PLAYER.ParseFrom(stream);
            PrintPlayer(player);
        }
    }

    public void PrintPlayer(C2S_UPDATE_PLAYER player)
    {
        if (player == null)
        {
            Debug.LogError("player is null");
            return;
        }
        Debug.LogFormat("{0}", player.ToString());
        Debug.LogFormat("id:{0},hp:{1},mp:{2}", player.Id, player.Hp, player.Mp);
    }

    void OnGUI()
    {
        if (GUILayout.Button("proto encode", GUILayout.Width(100), GUILayout.Height(40)))
        {
            EnCodePlayer();
        }

        if (GUILayout.Button("proto dencode", GUILayout.Width(100), GUILayout.Height(40)))
        {
            DeCodePlayer();
        }
        if (GUILayout.Button("IsLoopUpdate-1", GUILayout.Width(100), GUILayout.Height(40)))
        {
            IsLoopUpdate = true;
        }
        if (GUILayout.Button("IsLoopUpdate-0", GUILayout.Width(100), GUILayout.Height(40)))
        {
            IsLoopUpdate = false;
        }
    }
    #endregion
}