using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance;

    string nickname;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        // Singleton
        DontDestroyOnLoad(this.gameObject);
    }
    public void Connect(string _nickname)
    {
        nickname = _nickname;
        PhotonNetwork.ConnectUsingSettings();
    }
    // 포톤 서버에 연결
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    // 포톤 로비에 접속
    public void DisConnect() => PhotonNetwork.Disconnect();
    // 연결 끊기

    public void CreateRoom(string _roomName) => PhotonNetwork.CreateRoom(_roomName, new RoomOptions { MaxPlayers = 2 });
    // 이름 입력 받아서 방 생성, 최대 입장 가능 플레이어 수는 2명
    public void JoinRoom(string _roomName) => PhotonNetwork.JoinRoom(_roomName);
    // 기존에 있는 방에 접속
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // 방 떠나기
    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickname;
        SceneManager.LoadScene("Lobby");
    }
    // 서버에 연결되면 닉네임 동기화, Lobby 씬으로 이동
    #endregion
}
