using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLayout : BaseLayout
{
    [SerializeField] InputField inputRoomName;
    [SerializeField] Button createButton;
    [SerializeField] Button joinButton;
    public override DataManager.LayoutType LayoutType => DataManager.LayoutType.Lobby;
    // Start is called before the first frame update
    void Start()
    {
        createButton.onClick.RemoveAllListeners();
        joinButton.onClick.RemoveAllListeners();

        createButton.onClick.AddListener(delegate
        {
            if (inputRoomName.text.Equals(string.Empty))
                return;
            PhotonNetwork.CreateRoom(inputRoomName.text);
        });
        joinButton.onClick.AddListener(delegate
        {
            if (inputRoomName.text.Equals(string.Empty))
                return;
            PhotonNetwork.JoinRoom(inputRoomName.text);
        });
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        DataManager.Instance.roomName = inputRoomName.text;
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Room);
        Debug.Log("OnJoinedRoom");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        for (int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} 번째 방 이름 : {roomList[i].Name}");
        }
    }
}
