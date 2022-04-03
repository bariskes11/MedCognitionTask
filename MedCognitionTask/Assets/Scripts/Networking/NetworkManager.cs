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
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        this.txtStatus.text = "Connected To Internet";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        this.txtStatus.text = "Disconnected from Network";
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