using Photon.Pun;
using Photon.Realtime;
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
}
