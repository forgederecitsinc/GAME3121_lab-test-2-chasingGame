using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Player")) // check if the object touching us is the player
        {
            Destroy(gameObject); // destory once the player touches me
        }
    }
}
