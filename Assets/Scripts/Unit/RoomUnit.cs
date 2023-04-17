using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomUnit : MonoBehaviour
{
    [SerializeField]
    Text roomNameText;
    [SerializeField]
    Text playerCount;
    [SerializeField] 
    Button joinButton;

    private string roomName = string.Empty;
    public void Init(RoomInfo _room)
    {
        roomName = _room.Name;
        roomNameText.text = _room.Name;
        playerCount.text = _room.PlayerCount.ToString() + " / " + _room.MaxPlayers.ToString();
        joinButton.onClick.AddListener(delegate
        {
            PhotonManager.Instance.JoinRoom(_room.Name);
        });
    }

}
