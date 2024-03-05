
using UnityEngine;
using UnityEngine.SceneManagement;

public class completeWish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "witch")
        {
            Debug.Log("Wish completed. loading story end");
            SceneManager.LoadScene("storyEnd");
        }
    }
}
