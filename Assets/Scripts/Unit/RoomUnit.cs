using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomUnit : MonoBehaviour
{
    [SerializeField]
    Text roomName;
    [SerializeField]
    Text playerCount;
    public void Init(string _roomName, int _playerCount)
    {
        roomName.text = _roomName;
        playerCount.text = _playerCount.ToString();
    }
}
