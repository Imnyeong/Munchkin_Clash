using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
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
    public void OnClickConnect()
    {
        PhotonManager.Instance.SetNickname(inputName.text);
        PhotonNetwork.ConnectUsingSettings();
    }
    public void OnClickCreateRoom()
    {
        PhotonManager.Instance.SetRoomname(inputroomName.text);
        PhotonNetwork.CreateRoom(inputroomName.text, new RoomOptions { MaxPlayers = 2 });
    }
    public void OnClickJoinRoom()
    {
        PhotonManager.Instance.SetRoomname(inputroomName.text);
        PhotonNetwork.JoinRoom(inputroomName.text);
    }
    public void OnClickLeaveRoom()
    {
        PhotonManager.Instance.SetRoomname(string.Empty);
        PhotonNetwork.LeaveRoom();
    }
    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        photonType = PhotonType.Connect;
        PhotonNetwork.LocalPlayer.NickName = inputName.text;
        PhotonNetwork.JoinLobby();
    }
    // ������ ����Ǹ� �г��� ����ȭ, Lobby ���̾ƿ����� ����
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} �� ° �� �̸�{roomList[i].Name}");
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
        // Room�� ������ ���̾ƿ� ��ü
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        photonType = PhotonType.Room;
        LayoutChange(photonType);
        // Room�� ������ ���̾ƿ� ��ü
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
