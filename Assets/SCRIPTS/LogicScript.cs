using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public List<GameObject> targetBuildings = new List<GameObject>();
    public GameObject targetMarker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<GameObject> allBuildings = GameObject.FindGameObjectsWithTag("Building").ToList<GameObject>();
        for (int i = 0; i <= 4; i++)
        {
            int ix = Random.Range(0,allBuildings.Count);
            targetBuildings.Add(allBuildings[ix]);
            allBuildings.RemoveAt(ix);
        }

        foreach(GameObject target in targetBuildings)
        {
            Instantiate(targetMarker, new Vector3(target.transform.position.x,target.transform.position.y+60,target.transform.position.z),Quaternion.Euler(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dropPackage()
    {
        
    }
}
