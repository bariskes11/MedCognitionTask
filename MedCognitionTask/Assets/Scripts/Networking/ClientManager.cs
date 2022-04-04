using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    MasterPCIP masterPCIP;
    #endregion

    #region Fields
    private DataHelper datahelper = new DataHelper();
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    #endregion
    #region Unity Methods
    void Start()
    {
        ConnectToTcpServer();
    }
    #endregion
    #region Private Methods
    /// <summary>   
    /// Setup socket connection.    
    /// </summary>  
    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    /// <summary>   
    /// Runs in background clientReceiveThread; Listens for incoming data.  
    /// </summary>     
    /// 
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(masterPCIP.MasterIp, 8074);
            Byte[] bytes = new Byte[512];
            while (true)
            {
                // Get a stream object for reading              
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incoming stream into byte array.
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incomingData = new byte[length];
                        Array.Copy(bytes, 0, incomingData, 0, length);
                        string serverMessage = Encoding.ASCII.GetString(incomingData);
                        //data format {gender}&{clinicIssue}"
                        string[] data = serverMessage.Split('&');
                        EventManager.OnClientGenderSet.Invoke(datahelper.GetGender(data[0]));
                        EventManager.OnClinicIssueChange.Invoke(datahelper.GetPatientClinicIssue(data[1]));
                        Debug.Log("server message received as: " + serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }

        Debug.Log("Exiting...");
    }
    #endregion

}