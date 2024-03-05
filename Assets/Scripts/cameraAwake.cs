using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAwake : MonoBehaviour
{
    private static bool cameraExists = false;

    void Awake()
    {
        if (!cameraExists)
        {
            DontDestroyOnLoad(gameObject);
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject); // If another instance is found, destroy this one
        }
    }
}
