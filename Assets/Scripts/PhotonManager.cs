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
    // ���� ������ ����
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    // ���� �κ� ����
    public void DisConnect() => PhotonNetwork.Disconnect();
    // ���� ����

    public void CreateRoom(string _roomName) => PhotonNetwork.CreateRoom(_roomName, new RoomOptions { MaxPlayers = 2 });
    // �̸� �Է� �޾Ƽ� �� ����, �ִ� ���� ���� �÷��̾� ���� 2��
    public void JoinRoom(string _roomName) => PhotonNetwork.JoinRoom(_roomName);
    // ������ �ִ� �濡 ����
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // �� ������
    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickname;
        SceneManager.LoadScene("Lobby");
    }
    // ������ ����Ǹ� �г��� ����ȭ, Lobby ������ �̵�
    #endregion
}
