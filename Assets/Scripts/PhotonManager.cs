using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Text statusText;
    [SerializeField] InputField inputName;
    [SerializeField] InputField inputRoom;

    //public void Update() => statusText.text = PhotonNetwork.NetworkClientState.ToString();
    public override void OnConnectedToMaster() => PhotonNetwork.LocalPlayer.NickName = inputName.text;
    // 서버에 연결되면 닉네임 동기화
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    // 포톤 서버에 연결
    public void DisConnect() => PhotonNetwork.Disconnect();
    // 연결 끊기
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    // 로비에 접속
    public void CreateRoom() => PhotonNetwork.CreateRoom(inputRoom.text, new RoomOptions { MaxPlayers = 2 });
    // 방 만들기 inputfield 의 text를 방 이름, 최대 입장 가능 플레이어 수는 2명
    public void JoinRoom() => PhotonNetwork.JoinRoom(inputRoom.text);
    // 기존에 있는 방에 접속
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        {
            Debug.Log(PhotonNetwork.PlayerList[i].NickName + " ");
        }
    }
    // 방에 들어갔다는 콜백이 오면 방 안의 플레이어들 닉네임 출력
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // 방 떠나기
}
