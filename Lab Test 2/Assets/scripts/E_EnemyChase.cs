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
        agent = GetComponent<NavMeshAgent>();
        
        // force the ai to ram into the player
        agent.stoppingDistance = 0f;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); 
        }
    }
}
