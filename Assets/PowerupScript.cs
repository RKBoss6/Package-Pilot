using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public PowerupTypeDefinition[] powerups;
    private PowerupTypeDefinition thisPowerup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles=new Vector3(transform.eulerAngles.x,Random.Range(0,360),transform.eulerAngles.z);
        // assign one
        foreach (PowerupTypeDefinition po in powerups){
            po.obj.SetActive(false);
        }
        thisPowerup=powerups[Random.Range(0, powerups.Length)];
        thisPowerup.obj.SetActive(true);
    }

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCollider")
        {
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().startPowerup(thisPowerup);
            Destroy(gameObject);
            //LeanTween.scale(gameObject,Vector3.zero,0.19f).setEaseInQuad();
            
        }
    }
}

[System.Serializable]
public struct PowerupTypeDefinition
{
    

    public PowerupType type;
    public GameObject obj;
    [ColorUsage(true, true)]
    public Color hdrParticleColor;


}

public enum PowerupType
{
    Boost,
    FuelFreeze
}