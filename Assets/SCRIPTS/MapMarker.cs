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
        transform.position=new Vector3(target.position.x,500,target.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,target.eulerAngles.y,transform.eulerAngles.z);
    }
}
