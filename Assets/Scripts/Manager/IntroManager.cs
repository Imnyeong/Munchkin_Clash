using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager Instance;
    [SerializeField]
    List<GameObject> layoutList;

    private void Start() => ChangeLayout(DataManager.LayoutType.Login);
    public void ChangeLayout(DataManager.LayoutType _type)
    {
        for(int i = 0 ; i < layoutList.Count ; ++i)
            layoutList[i].SetActive(false);

        layoutList.Find(x => x.GetComponent<BaseLayout>().LayoutType.Equals(_type)).SetActive(true);
    }
}
