using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,speed*Time.time,transform.eulerAngles.z);
    }
}
