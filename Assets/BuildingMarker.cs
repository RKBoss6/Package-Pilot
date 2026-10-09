using System;
using UnityEngine;

public class BuildingMarkerScript : MonoBehaviour
{
    private Transform player;
    public SpriteRenderer arrowRenderer;
    public float distanceMin;
    public float distanceMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist=Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(player.position.x,player.position.z));
        float clampedDist = Math.Clamp(dist,distanceMin,distanceMax);
        arrowRenderer.color=new Color(arrowRenderer.color.r,arrowRenderer.color.g,arrowRenderer.color.b,
        (clampedDist-distanceMin)/(distanceMax-distanceMin));
    }
}
