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
            PhotonManager.Instance.CreateRoom(inputRoomName.text);
        });
        RoomListUpdate();
    }
    public void RoomListUpdate()
    {
        for (int i = scrollRect.content.childCount - 1; i >= 0; i--)
            GameObject.Destroy(scrollRect.content.GetChild(i).gameObject);

        for (int i = 0; i < DataManager.Instance.currentRoomList.Count; ++i)
        {
            GameObject roomObject = Instantiate(roomUnit.gameObject, scrollRect.content);
            roomObject.GetComponent<RoomUnit>().Init(DataManager.Instance.currentRoomList[i]);
        }
    }
}
