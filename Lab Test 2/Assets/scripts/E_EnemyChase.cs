using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player; 

    private NavMeshAgent agent;

    void Start()
    {
        // get the agent from the enemy
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // check if the player still exists
        if (player != null)
        {
            // set the agent's target destination to wherever the player is
            agent.SetDestination(player.position); 
        }
    }
}
