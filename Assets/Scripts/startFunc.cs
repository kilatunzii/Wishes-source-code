
using UnityEngine;
using UnityEngine.SceneManagement;

public class startFunc : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();


    }



    public void StartGame()
    {
        SceneManager.LoadScene("story");
    }

}
