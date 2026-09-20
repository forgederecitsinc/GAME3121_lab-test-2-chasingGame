using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public so I can change speed in the inspector
    public float speed = 10f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // y is 0 because we don't want it to fly
        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // push the ball
        rb.AddForce(movement * speed);
    }
}
