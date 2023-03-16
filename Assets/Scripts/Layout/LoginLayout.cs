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
            //PhotonManager.Instance.Connect(inputNickname.text);
        });
    }
}
