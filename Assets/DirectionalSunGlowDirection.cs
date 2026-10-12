using UnityEngine;

[ExecuteAlways]
public sealed class DirectionalSunGlowDirection : MonoBehaviour
{
    [SerializeField] private Light sunLight;

    private static readonly int SunDirectionId =
        Shader.PropertyToID("_SunDirection");

    private void OnEnable()
    {
        UpdateSunDirection();
    }

    private void LateUpdate()
    {
        UpdateSunDirection();
    }

    private void UpdateSunDirection()
    {
        if (sunLight == null || sunLight.type != LightType.Directional)
            return;

        Shader.SetGlobalVector(
            SunDirectionId,
            -sunLight.transform.forward
        );
    }
}
