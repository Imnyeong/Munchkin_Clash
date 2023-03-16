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
            //PhotonManager.Instance.CreateRoom(inputRoomName.text);
        });
        joinButton.onClick.AddListener(delegate
        {
            //PhotonManager.Instance.JoinRoom(inputRoomName.text);
        });
    }
}
