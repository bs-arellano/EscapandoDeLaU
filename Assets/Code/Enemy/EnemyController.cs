using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public EnemyFieldOfView enemyFOV;
    public List<Vector3> destinations;
    public Vector3 currentDestination;
    public int currentDestinationIndex;
    public float distanceToDestination;
    public Animator enemyAnimator;
    public bool persiguiendo;
    public AudioClip footstep;
    public AudioSource audioSource;
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyFOV = GetComponent<EnemyFieldOfView>();
        audioSource = GetComponent<AudioSource>();
        currentDestinationIndex = 0;
        currentDestination = destinations[currentDestinationIndex];
        agent.SetDestination(currentDestination);
        enemyAnimator.Play("Walking");
        persiguiendo = false;
        StartCoroutine(playFootsteps());
    }
    void Update()
    {
        //Ve al jugador y lo persigue
        if (enemyFOV.canSeePlayer)
        {
            persiguiendo = true;
            currentDestination = enemyFOV.playerReference.transform.position;
            agent.SetDestination(currentDestination);
            agent.speed = 3f;
            enemyAnimator.Play("Running");
        }
        distanceToDestination = Vector3.Distance(transform.position, currentDestination);
        //Esta persiguiendo al jugador y lo pierde de vista
        if (persiguiendo && !enemyFOV.canSeePlayer && distanceToDestination < 2)
        {
            persiguiendo = false;
            agent.speed = 2f;
            //Cambia su destino al previo
            currentDestination = destinations[currentDestinationIndex];
            agent.SetDestination(currentDestination);
            enemyAnimator.Play("Walking");
        }
        //Si no esta persiguiendo hace su ronda
        if (!persiguiendo)
        {
            if (distanceToDestination < 0.2)
            {
                currentDestinationIndex += 1;
                if (currentDestinationIndex >= destinations.Count)
                {
                    currentDestinationIndex = 0;
                }
                currentDestination = destinations[currentDestinationIndex];
                agent.SetDestination(currentDestination);
            }
        }
    }

    IEnumerator playFootsteps(){
        audioSource.clip = footstep;
        while (true){
            float stepDelay = persiguiendo ? 0.2f : 0.6f;
            audioSource.Play();
            yield return new WaitForSeconds(stepDelay);
        }
    }
}
