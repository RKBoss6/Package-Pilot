using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleScript : MonoBehaviour
{
    #region Variables
    private NavMeshAgent navMeshAgent;
    public float wanderRadius = 10f;
    public float speedMin=2.5f;
    public float speedMax=3.2f;
    public GameObject[] PersonTypes;
    private GameObject activePerson;
    
   
    #endregion

    #region Functions

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        navMeshAgent.enabled = true; // Ensure agent is active
        navMeshAgent.speed=Random.Range(speedMin, speedMax);

        foreach (GameObject g in PersonTypes)
            g.SetActive(false);

        navMeshAgent.avoidancePriority = Random.Range(0, 75);
        activePerson = PersonTypes[Random.Range(0, PersonTypes.Length)];
        activePerson.SetActive(true);
        // Debug.Log(
        //     name +
        //     " | onNavMesh: " + navMeshAgent.isOnNavMesh +
        //     " | position: " + transform.position +
        //     " | agentPosition: " + navMeshAgent.nextPosition,gameObject
        // );
        navMeshAgent.areaMask=NavMesh.AllAreas;
        ResetTime();
    }


    void ResetTime()
    {
        Vector3 target = GetRandomNavMeshPoint(transform.position, wanderRadius);
        bool success = navMeshAgent.SetDestination(target);

        // Debug.Log(
        //     name +
        //     " | target: " + target +
        //     " | SetDestination: " + success +
        //     " | onNavMesh: " + navMeshAgent.isOnNavMesh+"hasPath: "+navMeshAgent.hasPath+" status: "+navMeshAgent.path.status 
        // ,gameObject);
    }
    void Update()
    {
        // Check if the agent has reached or is very close to its current destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 3)
        {
            // Set a new random destination
            Vector3 target = GetRandomNavMeshPoint(transform.position, wanderRadius);
            bool success = navMeshAgent.SetDestination(target);

            // Debug.Log(
            //     name +
            //     " | target: " + target +
            //     " | SetDestination: " + success +
            //     " | onNavMesh: " + navMeshAgent.isOnNavMesh
            // ,gameObject);
            
        }
    }
    private Vector3 GetRandomNavMeshPoint(Vector3 center, float radius)
    {
        // 1. Pick a random point inside a sphere around the center position
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;

        NavMeshHit hit;
        // 2. Sample the position to snap it to the nearest valid spot on the NavMesh
        // '1' represents the NavMesh.AllAreas mask
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            return hit.position;
        }

        // Fallback: If it fails to find a point, return the current position
        return transform.position;
    }
}
#endregion

