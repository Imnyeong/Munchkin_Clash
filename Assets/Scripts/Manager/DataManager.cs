using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [HideInInspector]
    public string nickname = string.Empty;
    [HideInInspector]
    public string LoadingScene = "Loading";
    [HideInInspector]
    public string LoginScene = "Login";
    [HideInInspector]
    public string InGameScene = "InGame";
}
