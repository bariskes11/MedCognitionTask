using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtStatus;
    #endregion

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        this.txtStatus.text = "Waiting For Local Connection.....";
    }
    #region Photon Override Methods
    public override void OnConnectedToMaster()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Sending message");
            
            SendMessage();
        }
        
    }
     string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
    private void ListenForIncomingRequests()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), 8080);
            tcpListener.Start();
            Debug.Log("Server is listening");
            Byte[] bytes = new Byte[1024];
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
=======
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        this.txtStatus.text = "Connected To Internet";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        this.txtStatus.text = "Disconnected from Network";
>>>>>>> parent of ea9d336 (Networking Changes and improvements.)
    }
    public override void OnJoinedLobby()
    {
        this.txtStatus.text = "Joined Lobby";
        JoinOrCreateRoom();
    }
    public override void OnJoinedRoom()
    {
        this.txtStatus.color = Color.green;
        this.txtStatus.text = "Connection Established..";
    }
    #endregion
    #region Private Methods
    void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        // there will always be one room
        PhotonNetwork.JoinOrCreateRoom(PublicCommons.ROOMNAME, roomOptions, TypedLobby.Default);
    }
    #endregion
}