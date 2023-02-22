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
    // 포톤 서버에 연결

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickname;
        PhotonNetwork.JoinLobby();
    }
    // 서버에 연결되면 닉네임 동기화 + 로비에 바로 접속
    public override void OnJoinedLobby()
    {
        base.OnJoinedRoom();
        //for (int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        //{
        //    Debug.Log(PhotonNetwork.PlayerList[i].NickName + " ");
        //}
        SceneManager.LoadScene("Lobby");
    }
    // 로비에 들어갔다는 콜백이 오면 로비 씬으로 이동

    public void DisConnect() => PhotonNetwork.Disconnect();
    // 연결 끊기

    //public void CreateRoom() => PhotonNetwork.CreateRoom(inputRoom.text, new RoomOptions { MaxPlayers = 2 });
    // 방 만들기 inputfield 의 text를 방 이름, 최대 입장 가능 플레이어 수는 2명
    //public void JoinRoom() => PhotonNetwork.JoinRoom(inputRoom.text);
    // 기존에 있는 방에 접속

    //public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // 방 떠나기
}
