
using UnityEngine;

public class renderTextureManager : MonoBehaviour
{
   
    public static renderTextureManager Instance { get; private set; }
    public RenderTexture RDrawing;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure it persists across scene loads
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensures that only one instance exists
        }
    }
}
