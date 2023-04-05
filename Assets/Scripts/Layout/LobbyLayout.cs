using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLayout : BaseLayout
{
    [SerializeField] 
    InputField inputRoomName;
    [SerializeField] 
    Button createButton;
    [SerializeField] 
    ScrollRect scrollRect;
    [SerializeField] 
    GameObject roomUnit;
    public override DataManager.LayoutType LayoutType => DataManager.LayoutType.Lobby;
    // Start is called before the first frame update
    void Start()
    {
        createButton.onClick.RemoveAllListeners();
        createButton.onClick.AddListener(delegate
        {
            if (inputRoomName.text.Equals(string.Empty))
                return;
            RoomOptions roomOption = new RoomOptions();
            roomOption.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(inputRoomName.text, roomOption);
        });
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        DataManager.Instance.currentRoomList = new List<RoomInfo>(roomList.Count);
        for (int i = scrollRect.content.childCount - 1; i >= 0; i--)
            GameObject.Destroy(scrollRect.content.GetChild(i).gameObject);
        for(int i = 0; i < roomList.Count; ++i) 
            DataManager.Instance.currentRoomList.Add(roomList[i]);
        for (int i = 0; i < DataManager.Instance.currentRoomList.Count; ++i)
        {
            GameObject roomObject = Instantiate(roomUnit.gameObject, scrollRect.content);
            roomObject.GetComponent<RoomUnit>().Init(DataManager.Instance.currentRoomList[i]);
        }
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        DataManager.Instance.roomName = inputRoomName.text;
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Room);
        Debug.Log("OnJoinedRoom");
    }
}
