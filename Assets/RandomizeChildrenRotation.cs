using EditorAttributes;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomizeChildrenRotation : MonoBehaviour
{
    public bool alignTo90=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    void randomize()
    {
        foreach (Transform child in transform)
        {
            if (alignTo90)
            {
                child.eulerAngles=new Vector3(child.eulerAngles.x,Random.Range(1f,4f)*90,child.eulerAngles.z);
            }
            else
            {
                child.eulerAngles=new Vector3(child.eulerAngles.x,Random.Range(0,360),child.eulerAngles.z);

            }
        }
    }
}
