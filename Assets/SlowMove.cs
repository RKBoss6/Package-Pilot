using UnityEngine;

public class SlowMove : MonoBehaviour
{
    public float startX;
    public float endX;
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position=new Vector3(startX,transform.position.y,transform.position.z);
    }

   
}
