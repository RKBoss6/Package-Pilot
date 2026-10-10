using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public List<GameObject> targetBuildings = new List<GameObject>();
    public GameObject targetMarker;
    public Button dropButton;
    public GameObject packagePrefab;
    private float timeWhenLastDropped=0;
    public float maxFuel;
    [HideInInspector]public float fuel;
    public Slider fuelSlider;
    public GameObject player;
    public float activeDropDist;
    public float maxBoost;
    [HideInInspector] public float boostJuice;
    public Slider boostSlider;
    private List<float> buildingAccuracies = new List<float>();
    private List<GameObject> allBuildings;
    private List<GameObject> targetMarkers = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Application.targetFrameRate=45;
        fuel=maxFuel;
        boostJuice=maxBoost;

        allBuildings = GameObject.FindGameObjectsWithTag("Building").ToList<GameObject>();
        for (int i = 0; i <= 4; i++)
        {
            addNewTargetBuilding();

            
        }

        
    }
    void addNewTargetBuilding()
    {
        int ix = Random.Range(0,allBuildings.Count);
        GameObject target=allBuildings[ix];
        targetBuildings.Add(target);
        allBuildings.RemoveAt(ix);
        var obj = Instantiate(targetMarker, new Vector3(target.transform.position.x,target.transform.position.y+60,target.transform.position.z),Quaternion.Euler(0, 0, 0));
        targetMarkers.Add(obj);
    }
    void calculateEndMoney()
    {
        float fuelLeftPercent=fuel/maxFuel;

    }
    // Update is called once per frame
    void Update()
    {
        if(IsNearABuilding(Utils.Vector3To2(player.transform.position),activeDropDist))
        {
            dropButton.interactable=true;

        }
        else
        {
            dropButton.interactable=false;
        }
        fuelSlider.value=fuel/maxFuel;
        boostSlider.value=boostJuice/maxBoost;

    }
    private void scorePackage(GameObject package)
    {
        GameObject target=getClosestBuilding(Utils.Vector3To2(package.transform.position));
        float dist=Vector2.Distance(Utils.Vector3To2(target.transform.position),Utils.Vector3To2(package.transform.position));
        print("SCORE: "+dist);
        buildingAccuracies.Add(dist);
        int idx=targetBuildings.IndexOf(target);
        Destroy(targetMarkers[idx]);
        targetMarkers.RemoveAt(idx);
        targetBuildings.RemoveAt(idx);
        addNewTargetBuilding();

    }
    public void dropPackage(){
        GameObject obj;
        if(Time.time-1.5>timeWhenLastDropped){
            timeWhenLastDropped=Time.time;
            obj=Instantiate(packagePrefab, new Vector3(player.transform.position.x,player.transform.position.y-5,player.transform.position.z),Quaternion.Euler(0, player.transform.eulerAngles.y, 0));
            scorePackage(obj);

        }

    }
    public GameObject getClosestBuilding(Vector2 pos)
    {
        double maxDist=double.PositiveInfinity;
        GameObject finalObj=gameObject;
        foreach (GameObject obj in targetBuildings)
        {
            var dist= Vector2.Distance(pos,Utils.Vector3To2(obj.transform.position));
            if (dist < maxDist)
            {
                maxDist=dist;
                finalObj=obj;
            }
        }
        return finalObj;
    }
    public bool IsNearABuilding(Vector2 currentPosition, float threshold)
    {

        float squaredThreshold = threshold * threshold;

        foreach (GameObject obj in targetBuildings)
        {
            // Always null check in case an object in the list was destroyed
            if (obj == null) continue; 

            // Calculate the vector offset and the squared distance
            Vector2 offset = Utils.Vector3To2(obj.transform.position) - currentPosition;
            float squaredDistance = offset.sqrMagnitude;

            // If it's within the threshold, return true immediately
            if (squaredDistance <= squaredThreshold)
            {
                return true;
            }
        }

        // No objects were close enough
        return false;
    }


}


public class Utils{
    public static Vector2 Vector3To2(Vector3 pos)
    {
        return new Vector2(pos.x,pos.z);
    }
}