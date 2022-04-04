using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using UnityEngine;

[RequireComponent(typeof(ViewerManager))]
public class ClientManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    MasterPCIP masterPCIP;
    #endregion

    #region Fields
    DataHelper datahelper = new DataHelper();
    TcpClient socketConnection;
    Timer timer;
    ViewerManager viewerManager;
    #endregion
    #region Unity Methods
    void Start()
    {
        // setup ping rate
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += _timer_Elapsed;
        timer.Start();
        viewerManager = this.GetComponent<ViewerManager>();
        
    }
    private void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        ListenForData();
    }
    #endregion
    #region Private Methods
  
    /// <summary>   
    /// Runs in background clientReceiveThread; Listens for incoming data.  
    /// </summary>     
    /// 
    private void ListenForData()
    {
        try
        {
            Debug.Log($"Checking Data");
            
            socketConnection = new TcpClient(masterPCIP.MasterIp, 8074);
            Byte[] bytes = new Byte[512];
            
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
                        viewerManager.GenderSet(datahelper.GetGender(data[0]));
                        //EventManager.OnClientGenderSet.Invoke();
                        //EventManager.OnClinicIssueChange.Invoke(datahelper.GetPatientClinicIssue(data[1]));
                        Debug.Log("server message received as: " + serverMessage);
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