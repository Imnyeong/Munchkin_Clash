using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody2D rigidBody;
    public PhotonView photonView;
    public Image image;
    public Text name;

    bool isJump = false;

    void Awake()
    {
        if (photonView.IsMine)
        {
            image.color = Color.green;
            name.text = PhotonNetwork.NickName;
        }
        else
            image.color = Color.red;
    }
    void Update()
    {
        if (photonView.IsMine)
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7.0f, 0.0f));
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
