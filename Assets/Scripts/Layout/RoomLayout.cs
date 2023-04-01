using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomLayout : BaseLayout
{
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button exitButton;
    public override DataManager.LayoutType LayoutType => DataManager.LayoutType.Room;
    void Start()
    {
        startButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();

        startButton.onClick.AddListener(delegate
        {
            Debug.Log($"PhotonNetwork.CurrentLobby.Name = {PhotonNetwork.CurrentLobby.Name}, PhotonNetwork.CurrentRoom.Name = {PhotonNetwork.CurrentRoom.Name}, PhotonNetwork.LocalPlayer.NickName = {PhotonNetwork.LocalPlayer.NickName}");
        });
        exitButton.onClick.AddListener(delegate
        {
            PhotonNetwork.LeaveRoom();
        });
    }
}
