//-----------------------------------------------------------------------
//github:https://github.com/dpull/UnityUtils/blob/master/PackageSocket.cs
//document:http://www.dpull.com/blog/2015-10-08-csharp_unity_socket
//-----------------------------------------------------------------------

using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

public enum PackageSocketError
{
	None,
	SocketShutdown,
	RecviveBufferNotEnough,
	RecviveTimeout,
}

public class PackageSocket 
{
	enum State
	{
		Closed,
		Connecting,
		Connected,
		UserClosed,
		Error,
	}

	public delegate void ConnectCallback(bool connected);
	public delegate void RecviveCallback(byte[] data, int start, int length);
	public delegate void DisconnectCallback(SocketError socketError, PackageSocketError packageSocketError);

	public ConnectCallback OnConnect;
	public RecviveCallback OnRecvive;
	public DisconnectCallback OnDisconnect;
	public int ConnectTimeoutSetting = 3000;
	public int ReceiveTimeoutSetting = 10000;
	public int AutoSendPingSetting = 10000 / 3;
	
	private State CurState;
	private DateTime CheckTimeout;
	
	private Socket CurSocket; 
	private SocketError LastSystemSocketError;
	private PackageSocketError LastPackageSocketError;

	private Queue<byte[]> SendQueue;
	private int SendQueueStartIndex;

	private byte[] RecvBuffer;
	private int RecvBufferBeginIndex;
	private int RecvBufferEndIndex;

	private byte[] PingBuffer;
	private DateTime NextSendPingTime;
	
	const int MaxSizePerSend = 1024 * 4;		
	
	public PackageSocket()
	{
		SendQueue = new Queue<byte[]>();
		RecvBuffer = new byte[(int)ushort.MaxValue + 2];
		Reset();
	}

	public void Connect(string ip, int port)
	{
		Reset();

		CurSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		CurSocket.Blocking = false;
		
		try
		{
			var ipAddress = IPAddress.Parse(ip);
			CurSocket.Connect(ipAddress, port);
		}
		catch (SocketException e)
		{
			if (e.SocketErrorCode != SocketError.WouldBlock && e.SocketErrorCode != SocketError.InProgress)
				throw e;
		}

		CurState = State.Connecting;
		CheckTimeout = DateTime.Now.AddMilliseconds(ConnectTimeoutSetting);
	}

	public void Close()
	{
		if (CurState != State.Closed)
		{
			CurState = State.UserClosed;
		}
	}

	public void Update()
	{
		switch (CurState) 
		{
		case State.Closed:
			return;

		case State.Connecting:
			ProcessConnect();
			break;

		case State.Connected:
			ProcessSend();
			ProcessReceive();
			break;

		case State.Error:
			Reset();
			OnDisconnect(LastSystemSocketError, LastPackageSocketError);
			break;

		case State.UserClosed:
			Reset();
			break;
		}
	}

	public void Send(Byte[] buffer, int start, int length)
	{
		var headerLen = GetHeaderLength();
		var data = new byte[headerLen + length];

		EncodeHeader(length, data, 0);
		Array.Copy(buffer, start, data, headerLen, length);
		SendQueue.Enqueue(data);

		if (CurState == State.Connected)
			ProcessSend();	
	}

	public void SendPing()
	{
		if (PingBuffer == null) 
		{
			var headerLen = GetHeaderLength();
			PingBuffer = new byte[headerLen];
			EncodeHeader(0, PingBuffer, 0);
		}
		SendQueue.Enqueue(PingBuffer);
		ProcessSend();
	}

	void ProcessConnect()
	{
		var now = DateTime.Now;

		// http://www.dpull.com/blog/csharp_socket/
		CurSocket.Poll(0, SelectMode.SelectWrite);

		if (!CurSocket.Connected && CheckTimeout < now) 
		{
			Reset();
			OnConnect(false);
		}
		else if (CurSocket.Connected)
		{
            OnConnect(true);
            CurState = State.Connected;
			CheckTimeout = now.AddMilliseconds(ReceiveTimeoutSetting);
        }
    }
    
	void ProcessSend()
	{
		if (!CurSocket.Poll(0, SelectMode.SelectWrite))
			return;

		while (CurState == State.Connected && SendQueue.Count > 0) 
		{
			var buffer = SendQueue.Peek();
			int leftLength = buffer.Length - SendQueueStartIndex;
			
			while (leftLength > 0)
			{
				var trySend = Math.Min(MaxSizePerSend, leftLength);
				SocketError error;
				
				var send = CurSocket.Send(buffer, SendQueueStartIndex, trySend, SocketFlags.None, out error); 
                Debug.LogFormat("dosend:bufferLength:{0},SendQueueStartIndex:{1},trySend:{2},status:{3}", buffer.Length, SendQueueStartIndex, trySend,   error); 
				if (error != SocketError.Success)
				{
					if (error != SocketError.WouldBlock && error != SocketError.Interrupted &&  error != SocketError.TryAgain)
					{
                        SetError(error, PackageSocketError.None);
                        return;
                    }
                    break;
                }
                
				SendQueueStartIndex += send;
				leftLength -= send;
			}

			if (leftLength == 0)
			{
				SendQueue.Dequeue();
				SendQueueStartIndex = 0;
			}
		}
	}
    
	void ProcessReceive()
	{
		var now = DateTime.Now;
		if (!CurSocket.Poll(0, SelectMode.SelectRead)) 
		{
			if (NextSendPingTime < now)
			{
				//SendPing();
				NextSendPingTime = now.AddMilliseconds(AutoSendPingSetting);
			}

            if (CheckTimeout < now)
				SetError(SocketError.Success, PackageSocketError.RecviveTimeout);
			return;
		}

		while (CurState == State.Connected) 
		{
			var leftBufferSize = RecvBuffer.Length - RecvBufferEndIndex;
			SocketError error;
			var receive = CurSocket.Receive(RecvBuffer, RecvBufferEndIndex, leftBufferSize, SocketFlags.None, out error);
			if (error != SocketError.Success)
			{
				if (error != SocketError.WouldBlock && error != SocketError.Interrupted &&  error != SocketError.TryAgain)
					SetError(error, PackageSocketError.None);
				break;
			}

			RecvBufferEndIndex += receive;
			ProcessPackage();
			
			if (receive == 0)
			{
				SetError(error, PackageSocketError.SocketShutdown);
				break;
			}

			CheckTimeout = now.AddMilliseconds(ReceiveTimeoutSetting);
			NextSendPingTime = now.AddMilliseconds(AutoSendPingSetting);
		}
	}

	void ProcessPackage()
	{
		while (CurState == State.Connected)
		{
			var bufferLen = RecvBufferEndIndex - RecvBufferBeginIndex;
			var dataLen = 0;
			var headerLen = DecodeHeader(RecvBuffer, RecvBufferBeginIndex, bufferLen, ref dataLen);
			if (headerLen == 0)
			{
				headerLen = GetHeaderLength();
				if (RecvBufferBeginIndex + headerLen > RecvBuffer.Length)
					MemmoveRecvBuffer();
				break;
			}

			var packageLen = headerLen + dataLen;
			if (packageLen > RecvBuffer.Length)
			{
				SetError(SocketError.Success, PackageSocketError.RecviveBufferNotEnough);
				break;
			}
			
			if (packageLen <= bufferLen)
			{
				if (dataLen > 0)
					OnRecvive(RecvBuffer, RecvBufferBeginIndex + headerLen, dataLen);
				RecvBufferBeginIndex += packageLen;
				continue;
			}

			if (RecvBufferBeginIndex + packageLen > RecvBuffer.Length)
				MemmoveRecvBuffer();

			break;
		}
	}

	public void MemmoveRecvBuffer()
	{
		var bufferLen = RecvBufferEndIndex - RecvBufferBeginIndex;
		Array.Copy(RecvBuffer, RecvBufferBeginIndex, RecvBuffer, 0, bufferLen);
		RecvBufferBeginIndex = 0;
		RecvBufferEndIndex = bufferLen;
    }
    
    void SetError(SocketError socketError, PackageSocketError packageSocketError)
	{
		LastSystemSocketError = socketError;
		LastPackageSocketError = packageSocketError;
		CurState = State.Error;
	}

	void Reset()
	{
		CurState = State.Closed;
		CurSocket = null;
		RecvBufferBeginIndex = 0;
		RecvBufferEndIndex = 0;
		SendQueue.Clear();
		SendQueueStartIndex = 0;
	}

	protected virtual int DecodeHeader(byte[] buffer, int start, int length, ref int dataLength)
	{
		if (length < 2)
			return 0;
		
		dataLength = buffer[start] << 8 | buffer[start + 1];
		return 2;
	}



	protected virtual void EncodeHeader(int length, byte[] buffer, int start)
	{
		String type = "COM";
		byte[] byte_type = System.Text.Encoding.Default.GetBytes ( type ); 

		byte[] byte_length = new byte[4];
		ConverIntToByteArray(length,ref byte_length);

		System.Buffer.BlockCopy(byte_type,0,buffer,0,byte_type.Length);

		System.Buffer.BlockCopy(byte_length,0,buffer,byte_type.Length,byte_length.Length);

		//int32位即4byte,先将9-16位的数据右移到末8位，再与11111111做与运算过滤掉高位，仍然保留末8位数据，这是为了获取int n的9-16位的byte值
//        buffer[start + 0] = (byte)((length >> 8) & 0xff);
        //接收int末8位数据
//        buffer[start + 1] = (byte)(length & 0xff);
    }

	static bool ConverIntToByteArray(Int32 m,ref byte[] arr){
		if(arr==null) return false;
		if(arr.Length < 4) return false;
		arr[0] = (byte)(m & 0xFF);
		arr[1] = (byte)((m & 0xFF00 )>> 8);
		arr[2] = (byte)((m & 0xFF0000 )>> 16);
		arr[3] = (byte)((m >> 24) & 0xFF);

		return true;

	}

	protected virtual int GetHeaderLength()
	{
		return 7;
	}	

	public override string ToString ()
	{
		return string.Format("State:{0} SendQueue:{1}", CurState, SendQueue.Count);
    }
}
