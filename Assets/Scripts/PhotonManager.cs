using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

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

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickname;
        PhotonNetwork.JoinLobby();
    }
    // ������ ����Ǹ� �г��� ����ȭ + �κ� �ٷ� ����
    public override void OnJoinedLobby()
    {
        base.OnJoinedRoom();
        //for (int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        //{
        //    Debug.Log(PhotonNetwork.PlayerList[i].NickName + " ");
        //}
        SceneManager.LoadScene("Lobby");
    }
    // �κ� ���ٴ� �ݹ��� ���� �κ� ������ �̵�

    public void DisConnect() => PhotonNetwork.Disconnect();
    // ���� ����

    //public void CreateRoom() => PhotonNetwork.CreateRoom(inputRoom.text, new RoomOptions { MaxPlayers = 2 });
    // �� ����� inputfield �� text�� �� �̸�, �ִ� ���� ���� �÷��̾� ���� 2��
    //public void JoinRoom() => PhotonNetwork.JoinRoom(inputRoom.text);
    // ������ �ִ� �濡 ����

    //public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // �� ������
}
