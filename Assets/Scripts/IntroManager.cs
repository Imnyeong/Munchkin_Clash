using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] InputField inputName;
    public void OnClickConnect() => PhotonManager.Instance.Connect(inputName.text);
}
