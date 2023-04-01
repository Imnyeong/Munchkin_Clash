using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomUnit : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Text roomNameText;
    [SerializeField]
    Text playerCount;
    [SerializeField] 
    Button joinButton;

    private string roomName;
    public void Init(RoomInfo _room)
    {
        roomName = _room.Name;
        roomNameText.text = _room.Name;
        playerCount.text = _room.PlayerCount.ToString() + " / " + _room.MaxPlayers.ToString();
        joinButton.onClick.AddListener(delegate
        {
            PhotonNetwork.JoinRoom(_room.Name);
        });
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        DataManager.Instance.roomName = roomName;
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Room);
        Debug.Log("OnJoinedRoom");
    }
}
