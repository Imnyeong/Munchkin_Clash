using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] Canvas canvas;

    string player = "Player";

    void Start()
    {
        Debug.Log($"CurrentRoom = {PhotonNetwork.CurrentRoom}, NickName = {PhotonNetwork.NickName}");
        GameObject go = PhotonNetwork.Instantiate(player, Vector2.zero, Quaternion.identity);
        go.transform.SetParent(canvas.transform);
        go.GetComponent<RectTransform>().localScale = Vector3.one;
        go.GetComponent<RectTransform>().localPosition = spawnPosition.localPosition;
    }
}
