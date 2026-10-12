using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem powerupParticles;
    private static readonly int EmissionColorID = Shader.PropertyToID("_EmissionColor");
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void triggerPowerupParticle(PowerupTypeDefinition powerup)
    {
        Material particleMaterial;
        ParticleSystemRenderer psRenderer = powerupParticles.GetComponent<ParticleSystemRenderer>();
        
        // Using .material automatically creates a runtime instance copy 
        // so you don't permanently modify your asset file in the project folder.
        particleMaterial = psRenderer.material;
        
        particleMaterial.SetColor(EmissionColorID, powerup.hdrParticleColor);

        powerupParticles.transform.position=powerup.obj.transform.position;
        powerupParticles.Stop();
        powerupParticles.Play();


    }

    
}
