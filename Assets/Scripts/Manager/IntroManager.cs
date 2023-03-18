using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;
    [SerializeField]
    List<GameObject> layoutList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void ChangeLayout(DataManager.LayoutType _type)
    {
        for(int i = 0 ; i < layoutList.Count ; ++i)
            layoutList[i].SetActive(false);

        layoutList.Find(x => x.GetComponent<BaseLayout>().LayoutType.Equals(_type)).SetActive(true);
    }
}
