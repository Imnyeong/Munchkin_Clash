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
        loginButton.onClick.AddListener(delegate { PhotonNetwork.ConnectUsingSettings(); });
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        DataManager.Instance.nickname = inputNickname.text;
    }
}
