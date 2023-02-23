using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{ 
    void Start() => PhotonManager.Instance.JoinLobby();
    // Lobby 씬에 들어오면 JoinLobby
}
