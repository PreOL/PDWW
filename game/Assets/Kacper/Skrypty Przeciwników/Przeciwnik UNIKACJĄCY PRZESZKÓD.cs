using UnityEngine;
using UnityEngine.AI;

public class ObstacleAvoidingEnemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Automatycznie omija przeszkody
        }
    }
}
