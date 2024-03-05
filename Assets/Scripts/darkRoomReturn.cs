using UnityEngine;
using UnityEngine.SceneManagement;

public class darkRoomReturn : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "witch")
        {
            Debug.Log("Witch detected. Loading shop...");
            SceneManager.LoadScene("returnShop");
        }
    }

   
}
