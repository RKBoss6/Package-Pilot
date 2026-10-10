using UnityEngine;

public class PopInAnimation : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LeanTween.scale(gameObject,transform.localScale*3f,0.5f).setEaseOutCirc().setDelay(0.5f)
        .setOnComplete(() => LeanTween.scale(gameObject,transform.localScale/3f,0.5f).setEaseOutCirc());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
