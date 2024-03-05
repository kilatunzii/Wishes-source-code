using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignTexture : MonoBehaviour
{
    public RenderTexture renderTexture; // Assign this in the inspector
    public Material targetMaterial; // Assign a material in the inspector

    void Start()
    {
        if (targetMaterial != null)
        {
            // Assign the RenderTexture to the material
            targetMaterial.mainTexture = renderTexture;
        }
    }
}
