using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{ 
    [SerializeField] InputField inputName;
    [SerializeField] GameObject layoutLobby;
    [SerializeField] GameObject layoutRoom;

    bool isRoom = false;
    // Room�� �����ִ��� ����
    void Start() => PhotonManager.Instance.JoinLobby();
    // Lobby ���� ������ JoinLobby
    public void OnClickCreateRoom() => PhotonManager.Instance.CreateRoom(inputName.text);
    // �̸� �Է� �޾Ƽ� �� ����
    public void OnClickJoinRoom() => PhotonManager.Instance.JoinRoom(inputName.text);
    // �̸� �Է� �޾Ƽ� �� ����
    public void OnClickLeaveRoom()
    {
        PhotonManager.Instance.LeaveRoom();
        // Room���� ���� ���� ������ ���̾ƿ� ��ü
    }
    #region PunCallbacks
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for(int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} �� ° �� �̸�{roomList[i].Name}");
        }
    }
    // Lobby�� Join�Ǹ� ���� �� �ִ� Callback ���� List�� ���� �� �ִ�.
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        LayoutChange();
        // Room�� ������ ���̾ƿ� ��ü
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        LayoutChange();
        //Room���� ������ ���̾ƿ� ��ü
    }
    void LayoutChange()
    {
        layoutRoom.SetActive(isRoom);
        layoutLobby.SetActive(!isRoom);
        // Room �� Lobby ���̾ƿ� ��ü
    }
    #endregion
}
