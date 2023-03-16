using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private void Start() => SceneManager.LoadScene(DataManager.Instance.IntroScene);
}
