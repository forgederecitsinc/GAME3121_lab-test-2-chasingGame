using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    
    // set a default offset for the camera (x, y, z)
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    
    // speed for the smooth dynamic follow
    public float smoothSpeed = 5f;

    void Start()
    {
        // lock onto the player immediately as soon as the level begins
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // figure out where the camera wants to go
            Vector3 targetPosition = player.position + offset;
            
            // smoothly move there so the movement feels dynamic and not stiff
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            
            // force the camera lens to look directly at the player, keeping them in the center
            transform.LookAt(player);
        }
    }
}
