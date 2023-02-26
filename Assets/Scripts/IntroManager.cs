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
        Lobby,
        Room
    }
    PhotonType photonType = PhotonType.Disconnect;
    public void OnClickConnect()
    {
        photonType = PhotonType.Connect;
        PhotonManager.Instance.SetNickname(inputName.text);
        PhotonNetwork.ConnectUsingSettings();
    }
    public void OnClickCreateRoom()
    {
        photonType = PhotonType.Room;
        PhotonNetwork.CreateRoom(inputroomName.text, new RoomOptions { MaxPlayers = 2 });
    }

    public void OnClickJoinRoom()
    {
        photonType = PhotonType.Room;
        PhotonNetwork.JoinRoom(inputName.text);
    }
    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        photonType = PhotonType.Lobby;
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
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        LayoutChange(photonType);
        // Room�� ������ ���̾ƿ� ��ü
    }
    void LayoutChange(PhotonType _type)
    {
        switch(_type)
        {
            case PhotonType.Disconnect:
                break;
            case PhotonType.Connect:
                break;
            case PhotonType.Lobby:
                break;
            case PhotonType.Room:
                break;
        }
    }
    #endregion
}
