using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance;

    [HideInInspector]
    private string nickname = string.Empty;
    [HideInInspector]
    private string roomName = string.Empty;
    #region UnityLifeCycle
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
            Instance = this;
    }
    #endregion
    #region PhotonAction
    public void ConnectPhoton(string _nickname)
    {
        nickname = _nickname;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void CreateRoom(string _roomName)
    {
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 2;
        roomName = _roomName;
        PhotonNetwork.CreateRoom(_roomName, roomOption);
    }
    public void JoinRoom(string _roomName)
    {
        PhotonNetwork.JoinRoom(_roomName);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion
    #region PhotonCallback
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.LocalPlayer.NickName = nickname;
        DataManager.Instance.nickname = nickname;
        PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster & JoinLobby");
    }
    // 서버에 연결되면 닉네임 동기화, Lobby 레이아웃으로 변경
    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause == DisconnectCause.MaxCcuReached)
            Debug.Log("Server is full, please try again...");
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Lobby);
        Debug.Log("OnJoinedLobby");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        DataManager.Instance.currentRoomList = new List<RoomInfo>(roomList.Count);
        for (int i = 0; i < roomList.Count; ++i)
            DataManager.Instance.currentRoomList.Add(roomList[i]);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        DataManager.Instance.roomName = roomName;
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Room);
        Debug.Log("OnJoinedRoom");
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        DataManager.Instance.roomName = string.Empty;
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Lobby);
        Debug.Log("OnLeftRoom");
    }
    #endregion

}
