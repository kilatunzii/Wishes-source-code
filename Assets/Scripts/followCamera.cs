using UnityEngine;

public class followCamera : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Input.mousePosition;
        tempPos.z = 10f;
        this.transform.position = Camera.main.ScreenToWorldPoint(tempPos);
    }
}
