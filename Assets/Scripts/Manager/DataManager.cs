using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [HideInInspector]
    public string nickname = string.Empty;
    [HideInInspector]
    public string roomName = string.Empty;
    [HideInInspector]
    public string LoadingScene = "Loading";
    [HideInInspector]
    public string IntroScene = "Intro";
    [HideInInspector]
    public string InGameScene = "InGame";

    public enum LayoutType
    {
        Login,
        Lobby,
        Room,
        InGame
    }
    #region UnityLifeCycle
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
            Instance = this;
    }
    #endregion
}
