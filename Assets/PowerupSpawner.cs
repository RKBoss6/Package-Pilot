using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    
    public Vector3 boundsSize = new Vector3(10f, 2f, 10f);
    public GameObject powerupPrefab;
    public int quantity;

    private void OnDrawGizmosSelected()
    {

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.15f);
        Gizmos.DrawCube(Vector3.zero, boundsSize);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, boundsSize);
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(-boundsSize.x / 2f, boundsSize.x / 2f),
            Random.Range(-boundsSize.y / 2f, boundsSize.y / 2f),
            Random.Range(-boundsSize.z / 2f, boundsSize.z / 2f)
        );

        return transform.TransformPoint(randomPoint);
    }

    public void Start()
    {
        for (int i = 0; i < quantity; i++)
        {
            Instantiate(powerupPrefab,GetRandomPosition(),Quaternion.Euler(Vector3.zero));
        }
    }
}
