using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] InputField inputName;
    public void OnClickJoin() => PhotonManager.Instance.Connect(inputName.text);
}
