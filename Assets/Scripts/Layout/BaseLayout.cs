using Photon.Pun;
using UnityEngine;

public class BaseLayout : MonoBehaviourPunCallbacks
{
    public virtual DataManager.LayoutType LayoutType { get; }
}
