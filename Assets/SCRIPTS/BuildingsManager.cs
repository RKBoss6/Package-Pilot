using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public LogicScript logic;  
    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic=GameObject.FindGameObjectWithTag("LogicScript").GetComponent<LogicScript>();
        if (logic.targetBuildings.Contains(gameObject))
        {
            // is a target

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
