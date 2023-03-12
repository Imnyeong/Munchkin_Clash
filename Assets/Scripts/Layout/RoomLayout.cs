using UnityEngine;
using UnityEngine.UI;

public class RoomLayout : BaseLayout
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    public override PhotonManager.PhotonType PhotonType => PhotonManager.PhotonType.Room;
    void Start()
    {
        startButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();

        startButton.onClick.AddListener(delegate
        {
            PhotonManager.Instance.StartGame();
        });
        exitButton.onClick.AddListener(delegate
        {
            PhotonManager.Instance.LeaveRoom();
        });
    }
}
