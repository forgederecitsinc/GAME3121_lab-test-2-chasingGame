using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; 
    private Rigidbody rb;
    
    private Transform cam; // hold cam's transform

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        
        // find the camera transform so we know which way we are looking
        cam = Camera.main.transform; 
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A and D
        float moveZ = Input.GetAxis("Vertical");   // W and S

        // figure out which way is forward and right from the camera's perspective
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        // flatten the vectors so we don't accidentally push the ball into the floor or sky
        camForward.y = 0f;
        camRight.y = 0f;
        
        // keep the speed consistent
        camForward.Normalize();
        camRight.Normalize();

        // mix the camera directions with our key inputs
        Vector3 movement = (camForward * moveZ) + (camRight * moveX);

        // move player
        rb.AddForce(movement * speed);
    }
}
