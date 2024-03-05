using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // get character controller component
        controller = GetComponent<CharacterController>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        // get inputs W,A,S,D and arrow keys
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //forward and backward movement
        Vector3 forwardMovement = transform.forward * vertical * moveSpeed * Time.deltaTime;

        // apply movement
        controller.Move(forwardMovement);

        //turn character
        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);

       
    }
}
