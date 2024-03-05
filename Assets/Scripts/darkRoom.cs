using UnityEngine;
using UnityEngine.SceneManagement;

public class darkRoom : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "witch")
        {
            Debug.Log("Witch detected. Loading darkRoom...");
            GoTodarkRoom();
        }
    }

    void GoTodarkRoom()
    {
        SceneManager.LoadScene("darkRoom");
    }
}
