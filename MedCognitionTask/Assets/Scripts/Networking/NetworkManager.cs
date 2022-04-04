using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;
using System.Text;
using static PublicCommons;

/// <summary>
/// Main server sends data to connected clients
/// Made singleton to not lose instance over scenes
/// </summary>
public class NetworkManager : CreateSingleton<NetworkManager>
{
    #region Unity Fields
    [SerializeField]
    MasterPCIP masterPCIP;
    #endregion
    #region Fields
    TcpListener tcpListener;
    Thread tcpListenerThread;
    TcpClient connectedTcpClient;
    #endregion
    #region Unity Methods
    void Start()
    {
        StartThread();
        
        EventManager.OnSelectedItem.AddListener(SelectedPatient);
    }

    private void StartThread()
    {
   
        tcpListenerThread = new Thread(new ThreadStart(ListenForIncomingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }
    #endregion

    #region Private Methods
    void ListenForIncomingRequests()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse(masterPCIP.MasterIp), masterPCIP.MasterPort);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[512];
            while (true)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {
                    using (NetworkStream stream = connectedTcpClient.GetStream())
                    {
                        int length;
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incomingData = new byte[length];
                            Array.Copy(bytes, 0, incomingData, 0, length);
                            string clientMessage = Encoding.ASCII.GetString(incomingData);
                            Debug.Log("client message received as: " + clientMessage);
                        }
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("SocketException " + socketException.ToString());
        }

        Debug.Log("Exiting...");
    }
    void SelectedPatient(PatientGender gender, PatientClinicIssueType clinicIssueType)
    {
        if (connectedTcpClient == null)
        {
            return;
        }
        try
        {
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite)
            {
                SendData(stream, $"{gender}&{clinicIssueType}");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
    private static void SendData(NetworkStream stream, string r)
    {
        byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(r);
        stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
        Debug.Log("Server sent his message - should be received by client");
    }
    #endregion
}
