using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Vector3> destinations;
    Vector3 currentDestination;
    int currentDestinationIndex;
    float distanceToDestination;
    public Animator enemyAnimator;
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentDestinationIndex = 0;
        currentDestination = destinations[currentDestinationIndex];
        agent.SetDestination(currentDestination);
        enemyAnimator.Play("Walking");
    }
    void Update()
    {
        distanceToDestination = Vector3.Distance(transform.position, currentDestination);
        if (distanceToDestination < 0.2){
            currentDestinationIndex += 1;
            if (currentDestinationIndex >= destinations.Count){
                currentDestinationIndex = 0;
            }
            currentDestination = destinations[currentDestinationIndex];
            agent.SetDestination(currentDestination);
        }
    }
}
