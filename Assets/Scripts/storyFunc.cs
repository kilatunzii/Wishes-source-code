using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storyFunc : MonoBehaviour
{
    public void ReturnButton()
    {
        SceneManager.LoadScene("start");


    }
    public void ExploreShop()
    {
        SceneManager.LoadScene("shop");
    }
}
