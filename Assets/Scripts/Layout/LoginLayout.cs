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
            // �ε� �߰�
            PhotonManager.Instance.ConnectPhoton(inputNickname.text);
        });
    }
}
