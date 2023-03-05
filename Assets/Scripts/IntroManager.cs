using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviourPunCallbacks
{
    [Header("InputField")]
    [SerializeField] InputField inputName;
    [SerializeField] InputField inputroomName;

    [Header("Layout")]
    [SerializeField] GameObject layoutIntro;
    [SerializeField] GameObject layoutLobby;
    [SerializeField] GameObject layoutRoom;

    public enum PhotonType
    {
        Disconnect,
        Connect,
        Room
    }
    PhotonType photonType = PhotonType.Disconnect;

    public void OnClickConnect() => PhotonNetwork.ConnectUsingSettings();
    public void OnClickCreateRoom() => PhotonNetwork.CreateRoom(inputroomName.text, new RoomOptions { MaxPlayers = 2 });
    public void OnClickJoinRoom() => PhotonNetwork.JoinRoom(inputroomName.text);
    public void OnClickLeaveRoom() => PhotonNetwork.LeaveRoom();
    public void OnClickStartGame() => SceneManager.LoadScene("InGame");

    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        photonType = PhotonType.Connect;
        PhotonNetwork.LocalPlayer.NickName = inputName.text;
        PhotonNetwork.JoinLobby();
    }
    // 서버에 연결되면 닉네임 동기화, Lobby 레이아웃으로 변경
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} 번 째 방 이름{roomList[i].Name}");
        }
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        LayoutChange(photonType);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        photonType = PhotonType.Room;
        LayoutChange(photonType);
        // Room에 들어오면 레이아웃 교체
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        photonType = PhotonType.Room;
        LayoutChange(photonType);
        // Room에 들어오면 레이아웃 교체
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        photonType = PhotonType.Connect;
        LayoutChange(photonType);
    }
    void LayoutChange(PhotonType _type)
    {
        layoutIntro.SetActive(false);
        layoutLobby.SetActive(false);
        layoutRoom.SetActive(false);
        switch (_type)
        {
            case PhotonType.Disconnect:
                break;
            case PhotonType.Connect:
                {
                    layoutLobby.SetActive(true);
                    break;
                }
            case PhotonType.Room:
                {
                    layoutRoom.SetActive(true);
                    break;
                }
        }
    }
    #endregion
}
