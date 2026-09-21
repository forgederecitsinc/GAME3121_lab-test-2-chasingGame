using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; 
    private Rigidbody rb;
    private Transform cam; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        cam = Camera.main.transform; 
    }

    void FixedUpdate()
    {
        // GetAxisRaw removes the artificial input lag, snapping instantly to -1, 0, or 1
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveZ = Input.GetAxisRaw("Vertical");   

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0f;
        camRight.y = 0f;
        
        camForward.Normalize();
        camRight.Normalize();

        Vector3 movement = (camForward * moveZ) + (camRight * moveX);

        // calculate the exact speed we want
        Vector3 targetVelocity = movement * speed;
        
        // keep the existing Y velocity so gravity still works
        targetVelocity.y = rb.linearVelocity.y;
        
        // directly override the physics velocity for instant starts and stops
        rb.linearVelocity = targetVelocity;
    }
}
