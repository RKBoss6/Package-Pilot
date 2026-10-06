#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EditorAttributes;
using UnityEditor;


[ExecuteInEditMode]
public class ObjectPlaceWizard : MonoBehaviour
{

    [Title("ObjectPlacer Wizard")]


    private string blankFiller;

    [Header("Corners")]

    public Transform TL;
    public Transform TR;
    public Transform BL;
    public Transform BR;
    [Header("Object")]
    [Tooltip("The parent that objects should be spawned under.")]
    public Transform Parent;
    [Tooltip("The object.")]

    public GameObject ObjectPrefab;
    [Tooltip("The amount of objects to spawn.")]

    public int amount;

    
    private List<GameObject> justPlacedObjects = new List<GameObject>();
    [Tooltip("Wether or not to override the tag for objects to be found and deleted.")]

    public bool overrideTag=true;
    [ShowField(nameof(overrideTag))]
    [Tooltip("The tag to override with.")]

    public string tagToOverride;
    private GameObject[] allObjects;

    

    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }


    [Button("Place")]
    void placeObjects(){
        if(justPlacedObjects!=null){
            justPlacedObjects.Clear();
        }
        
        for (int i = 0; i<amount;i++){
            GameObject obj=PrefabUtility.InstantiatePrefab(ObjectPrefab,Parent) as GameObject;
            print("Goop");
            obj.transform.position=new Vector3(Random.Range((float)TL.position.x,(float)TR.position.x),300,Random.Range((float)TR.position.z,(float)BR.position.z));
            obj.transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
            RaycastHit hit;
            if(Physics.Raycast(obj.transform.position,Vector3.down,out hit, 100000)){
                if(hit.collider.GetType()==typeof(TerrainCollider)){
                    Bounds bounds=obj.GetComponent<Collider>().bounds;
                    float yOffset=obj.transform.position.y-(bounds.center.y-0.5f*bounds.size.y);
                    Vector3 newpos=hit.point;
                   // newpos.y-=yOffset;s
                    obj.transform.position=newpos;
                    print(justPlacedObjects);
                    justPlacedObjects.Add(obj);
                }
                
            }
        }
    }





    [Button("Remove Recenty Placed Objects")]

    void removeRecentObjects(){
        foreach(GameObject obj in justPlacedObjects){
            DestroyImmediate(obj);
        }
    }

    

    [Button("Remove All Objects")]
    void removeAllObjects(){
        if(overrideTag){
            allObjects=GameObject.FindGameObjectsWithTag(tagToOverride);
        }else{
            allObjects=GameObject.FindGameObjectsWithTag(ObjectPrefab.tag);
        }   
        foreach(GameObject obj in allObjects){
            DestroyImmediate(obj);
        }
    }
}
#endif