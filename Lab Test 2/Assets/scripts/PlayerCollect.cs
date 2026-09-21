using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public GameObject winText;
    
    private int score = 0; 
    
    private int scoreToWin; 

    void Start()
    {
        // hide the win text when the game starts
        if (winText != null)
        {
            winText.SetActive(false);
        }
        
        // automatically count every object tagged PICKUP
        scoreToWin = GameObject.FindGameObjectsWithTag("Pickup").Length;
        
        UpdateScoreDisplay();
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the thing we touched is a collectible
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreDisplay();

            // check if we collected the total amount we counted at the start
            if (score >= scoreToWin)
            {
                if (winText != null) 
                {
                    winText.SetActive(true);
                }
                
                // freeze the game YOU WON
                Time.timeScale = 0f;
            }
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
