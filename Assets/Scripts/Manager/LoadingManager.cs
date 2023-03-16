using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    private void Start() => SceneManager.LoadScene(DataManager.Instance.IntroScene);
}