using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleScript : MonoBehaviour
{
    #region Variables
    private NavMeshAgent navMeshAgent;
    public float wanderRadius = 10f;
    public GameObject[] PersonTypes;
    private GameObject activePerson;
   
    #endregion

    #region Functions

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed=Random.Range(2.5f, 3.2f);

    }

    void Start()
    {
        navMeshAgent.enabled = true; // Ensure agent is active

        foreach (GameObject g in PersonTypes)
            g.SetActive(false);

        navMeshAgent.avoidancePriority = Random.Range(0, 75);
        activePerson = PersonTypes[Random.Range(0, PersonTypes.Length)];
        activePerson.SetActive(true);
        navMeshAgent.SetDestination(GetRandomNavMeshPoint(transform.position, wanderRadius));

    }
    void Update()
    {
        // Check if the agent has reached or is very close to its current destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 3)
        {
            // Set a new random destination
            Vector3 newTarget = GetRandomNavMeshPoint(transform.position, wanderRadius);
            navMeshAgent.SetDestination(newTarget);
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
        return GetRandomNavMeshPoint(center, radius);
    }
}
#endregion