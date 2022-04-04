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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class NetworkManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    MasterPCIP masterPCIP;
    [SerializeField]
    TextMeshProUGUI txtStatus;
    #endregion
    #region Fields
    TcpListener tcpListener;
    Thread tcpListenerThread;
    TcpClient connectedTcpClient;
    #endregion
    #region Unity Methods
    void Start()
    {
        tcpListenerThread = new Thread(new ThreadStart(ListenForIncomingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
        EventManager.OnSelectedItem.AddListener(SelectedPatient);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectedPatient(PatientGender.Female, PatientClinicIssueType.None);
        }
    }
    #endregion

    #region Private Methods
    void ListenForIncomingRequests()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse(masterPCIP.MasterIp), 8074);
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
    void SelectedPatientClinicIssue(PatientGender gender, PatientClinicIssueType clinicIssue)
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
                SendData(stream,$"{gender}&{clinicIssue}");
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
