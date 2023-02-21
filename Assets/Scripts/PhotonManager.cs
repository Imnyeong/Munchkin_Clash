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
    // ������ ����Ǹ� �г��� ����ȭ
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    // ���� ������ ����
    public void DisConnect() => PhotonNetwork.Disconnect();
    // ���� ����
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    // �κ� ����
    public void CreateRoom() => PhotonNetwork.CreateRoom(inputRoom.text, new RoomOptions { MaxPlayers = 2 });
    // �� ����� inputfield �� text�� �� �̸�, �ִ� ���� ���� �÷��̾� ���� 2��
    public void JoinRoom() => PhotonNetwork.JoinRoom(inputRoom.text);
    // ������ �ִ� �濡 ����
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        {
            Debug.Log(PhotonNetwork.PlayerList[i].NickName + " ");
        }
    }
    // �濡 ���ٴ� �ݹ��� ���� �� ���� �÷��̾�� �г��� ���
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    // �� ������
}
