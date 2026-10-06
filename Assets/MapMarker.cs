using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=target.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,target.eulerAngles.y,transform.eulerAngles.z);
    }
}
