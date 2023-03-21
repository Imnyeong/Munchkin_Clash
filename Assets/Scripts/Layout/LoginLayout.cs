using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LoginLayout : BaseLayout
{
    [SerializeField] InputField inputNickname;
    [SerializeField] Button loginButton;
    public override DataManager.LayoutType LayoutType => DataManager.LayoutType.Login;

    void Start()
    {
        loginButton.onClick.RemoveAllListeners();
        loginButton.onClick.AddListener(delegate
        {
            if (inputNickname.text.Equals(string.Empty))
                return;
            // 로딩 추가
            PhotonNetwork.ConnectUsingSettings();
        });
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.LocalPlayer.NickName = inputNickname.text;
        DataManager.Instance.nickname = inputNickname.text;
        PhotonNetwork.JoinLobby();
        Debug.Log("OnConnectedToMaster");
    }
    // 서버에 연결되면 닉네임 동기화, Lobby 레이아웃으로 변경
    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause == DisconnectCause.MaxCcuReached)
            Debug.Log("Server is full, please try again...");
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        IntroManager.Instance.ChangeLayout(DataManager.LayoutType.Lobby);
        Debug.Log("OnJoinedLobby");
    }
}
