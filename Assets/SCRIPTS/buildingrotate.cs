using EditorAttributes;
using TMPro;
using UnityEngine;

public class buildingrotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    void rotateBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject b in buildings)
        {
            Transform t=b.transform;
            t.eulerAngles = new Vector3(t.eulerAngles.x,Random.Range(0,3)*90,t.eulerAngles.z);
        }
    }
}
