using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance;

    [HideInInspector] public string nickname;
    [HideInInspector] public string roomName;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        // Singleton
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetNickname(string _nickname) => nickname = _nickname;
    // PhotonManager �� nickname ����
    public void SetRoomname(string _roomName) => roomName = _roomName;
    // PhotonManager �� roomname ����
}
