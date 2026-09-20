using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 

    private Vector3 offset;

    void Start()
    {
        // calculate the offset so it keeps that exact spacing
        offset = transform.position - player.position;
    }

    // LateUpdate runs after all other updates, which is best for cameras so they don't stutter
    void LateUpdate()
    {
        // check if player exists so the game doesn't crash when we restart or destroy the player
        if (player != null)
        {
            // follow the player
            transform.position = player.position + offset;
        }
    }
}
