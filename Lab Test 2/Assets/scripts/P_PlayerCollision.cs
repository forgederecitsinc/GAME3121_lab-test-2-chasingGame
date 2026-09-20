using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverText;

    void OnCollisionEnter(Collision collision)
    {
        // check if we hit the enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // enable the GAME OVER text object
            gameOverText.SetActive(true);

            // end the game
            Time.timeScale = 0f;
        }
    }
}
