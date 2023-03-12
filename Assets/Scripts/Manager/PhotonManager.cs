using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance;

    [Header("Lobby Layout")]
    [SerializeField] GameObject[] lobbyLayouts;

    [Header("Game Layout")]
    [SerializeField] GameObject[] inGameLayouts;

    [Header("Current Layout")]
    [SerializeField] List<GameObject> currentLayouts;

    [SerializeField] Transform spawnPosition;
    [HideInInspector] public string nickname = string.Empty;

    string LoadingScene = "Loading";
    string LoginScene = "Login";
    string InGameScene = "InGame";
    
    string player = "Player";

    public enum PhotonType
    {
        Disconnect,
        Lobby,
        Room,
        InGame
    }
    public enum SceneType
    {
        Loading,
        Login,
        InGame
    }

    [HideInInspector] public PhotonType photonType = PhotonType.Disconnect;
    [HideInInspector] public SceneType sceneType = SceneType.Loading;

    #region UnityLifeCycle
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
            Instance = this;
        // Singleton

        if (sceneType == SceneType.Loading)
            ChangeScene(SceneType.Login);
    }
    private void Start()
    {
        if (sceneType != SceneType.Loading) 
            Init();
    }
    #endregion
    #region Init
    private void Init()
    {
        currentLayouts.Clear();
        switch (sceneType)
        {
            case SceneType.Login:
                {
                    for (int i = 0; i < lobbyLayouts.Length; ++i)
                    {
                        currentLayouts.Add(GameObject.Instantiate(lobbyLayouts[i]));
                    }
                    break;
                }
            case SceneType.InGame:
                {
                    for (int i = 0; i < inGameLayouts.Length; ++i)
                    {
                        currentLayouts.Add(GameObject.Instantiate(inGameLayouts[i]));
                    }
                    break;
                }
        }
        ChangLayout(photonType);
    }
    #endregion
    #region PhotonNetwork
    public void Connect(string _nickname)
    {
        nickname = _nickname;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void CreateRoom(string _roomName) => PhotonNetwork.CreateRoom(_roomName, new RoomOptions { MaxPlayers = 2 });
    public void JoinRoom(string _roomName) => PhotonNetwork.JoinRoom(_roomName);
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    public void StartGame()
    {
        Debug.Log("게임 시작");
        //SetPhotonType(PhotonType.InGame);
        //LayoutChange(photonType);
        //GameObject go = PhotonNetwork.Instantiate(player, Vector2.zero, Quaternion.identity);
        //go.transform.SetParent(layoutInGame.transform);
        //go.GetComponent<RectTransform>().localScale = Vector3.one;
        //go.GetComponent<RectTransform>().localPosition = spawnPosition.localPosition;
    }
    #endregion
    #region PunCallbacks
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickname;
        SetPhotonType(PhotonType.Lobby);
        ChangLayout(GetPhotonType());
        PhotonNetwork.JoinLobby();
    }
    // 서버에 연결되면 닉네임 동기화, Lobby 레이아웃으로 변경
    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause == DisconnectCause.MaxCcuReached)
            Debug.Log("Server is full, please try again...");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; ++i)
        {
            Debug.Log($"{i.ToString()} 번 째 방 이름{roomList[i].Name}");
        }
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        SetPhotonType(PhotonType.Room);
        ChangLayout(GetPhotonType());
        // Room에 들어오면 레이아웃 교체
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SetPhotonType(PhotonType.Room);
        // Room에 들어오면 레이아웃 교체
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SetPhotonType(PhotonType.Lobby);
    }
    //void LayoutChange(PhotonType _type)
    //{
    //    layoutLogin.SetActive(false);
    //    layoutLobby.SetActive(false);
    //    layoutRoom.SetActive(false);
    //    layoutInGame.SetActive(false);
    //    switch (_type)
    //    {
    //        case PhotonType.Disconnect:
    //            break;
    //        case PhotonType.Lobby:
    //            {
    //                layoutLobby.SetActive(true);
    //                break;
    //            }
    //        case PhotonType.Room:
    //            {
    //                layoutRoom.SetActive(true);
    //                break;
    //            }
    //        case PhotonType.InGame:
    //            {
    //                layoutInGame.SetActive(true);
    //                break;
    //            }
    //    }
    //}
    #endregion
    #region PhotonType
    public PhotonType GetPhotonType()
    {
        Debug.Log("GetPhotonType = " + photonType.ToString());
        return photonType;
    }
    public void SetPhotonType(PhotonType _type)
    {
        Debug.Log("SetPhotonType = " + _type.ToString());
        photonType = _type;
    }
    #endregion
    #region SceneType
    public void ChangeScene(SceneType _scentype)
    {
        sceneType = _scentype;
        switch (_scentype)
        {
            case SceneType.Login:
                {
                    SceneManager.LoadScene(LoginScene);
                    break;
                }
            case SceneType.InGame:
                {
                    SceneManager.LoadScene(InGameScene);
                    break;
                }
        }
    }
    public void ChangLayout(PhotonType _photonType)
    {
        for(int i = 0 ; i < currentLayouts.Count ; ++i)
            currentLayouts[i].SetActive(false);

        currentLayouts.Find(x => x.GetComponent<BaseLayout>().PhotonType == _photonType).SetActive(true);
    }
    #endregion
}
