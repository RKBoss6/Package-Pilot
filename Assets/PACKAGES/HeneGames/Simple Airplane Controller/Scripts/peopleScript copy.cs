using UnityEngine;
using UnityEngine.AI;

public class PeopleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("The character Prefab to spawn (Make sure the NavMeshAgent is on the root object!).")]
    public GameObject characterPrefab;
    
    [Tooltip("How many characters to spawn.")]
    public int spawnCount = 5;
    
    [Tooltip("The maximum distance from the center of this Spawner to look for a spawn point.")]
    public float spawnRadius = 20f;

    void Start()
    {
        SpawnCharacters();
    }

    public void SpawnCharacters()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(characterPrefab, GetSafeRandomNavMeshPosition(transform.position,spawnRadius),Quaternion.Euler(Vector3.zero));
        }
    }
  

   public Vector3 GetSafeRandomNavMeshPosition(Vector3 centerPoint, float radius, NavMeshAgent agent = null)
{
    // 1. Pick a random raw direction
    Vector3 randomDirection = Random.insideUnitSphere * radius;
    randomDirection += centerPoint;

    NavMeshHit hit;

    // 2. Locate the closest valid spot on the NavMesh
    if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
    {
        Vector3 resultPoint = hit.position;

        // 3. FIX: If the point is on an outer edge, push it inward
        // We look at the direction the agent traveled to get to this point
        Vector3 directionFromCenter = (resultPoint - centerPoint).normalized;
        
        // Determine the safe buffer distance (use agent radius, or default to 1 unit)
        float agentRadius = (agent != null) ? agent.radius : 1.0f;
        
        // Push the target point back toward the center map origin by the agent's width
        resultPoint -= directionFromCenter * (agentRadius * 1.2f); 

        return resultPoint;
    }

    return centerPoint;
}

}
