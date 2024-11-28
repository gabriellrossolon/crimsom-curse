using UnityEngine;
using UnityEngine.AI;

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public float detectionRange = 10f;
    public float wanderRadius = 15f;
    public float distanceFromPlayer = 1f;

    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            Vector3 directionToPlayer = (transform.position - player.position).normalized;
            Vector3 targetPosition = player.position + directionToPlayer * distanceFromPlayer;
            agent.SetDestination(targetPosition);
        }
        else
        {
            if (!agent.hasPath)
            {
                Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
                randomDirection += transform.position;
                if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                }
            }
        }
    }
}
