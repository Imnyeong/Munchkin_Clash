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
    // Room에 들어와있는지 여부
    void Start() => PhotonManager.Instance.JoinLobby();
    // Lobby 씬에 들어오면 JoinLobby
    public void OnClickCreateRoom() => PhotonManager.Instance.CreateRoom(inputName.text);
    // 이름 입력 받아서 방 생성
    public void OnClickJoinRoom() => PhotonManager.Instance.JoinRoom(inputName.text);
    // 이름 입력 받아서 방 입장
    public void OnClickLeaveRoom()
    {
        PhotonManager.Instance.LeaveRoom();
        // Room에서 나갈 때도 들어오면 레이아웃 교체
    }
    #region PunCallbacks
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for(int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} 번 째 방 이름{roomList[i].Name}");
        }
    }
    // Lobby에 Join되면 받응 수 있는 Callback 방의 List를 받을 수 있다.
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        LayoutChange();
        // Room에 들어오면 레이아웃 교체
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        LayoutChange();
        //Room에서 나가면 레이아웃 교체
    }
    void LayoutChange()
    {
        layoutRoom.SetActive(isRoom);
        layoutLobby.SetActive(!isRoom);
        // Room 과 Lobby 레이아웃 교체
    }
    #endregion
}
