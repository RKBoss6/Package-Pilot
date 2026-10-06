using UnityEngine;
using UnityEngine.Rendering;

public class UrpCameraNoFog : MonoBehaviour
{
    private Camera targetCamera;
    private bool originalFogState;

    void Awake()
    {
        targetCamera = GetComponent<Camera>();
    }

    void OnEnable()
    {
        // Subscribe to the render pipeline camera events
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }

    void OnDisable()
    {
        // Always unsubscribe to prevent memory leaks
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        // Check if the current camera being rendered is this specific camera
        if (camera == targetCamera)
        {
            originalFogState = RenderSettings.fog;
            RenderSettings.fog = false; // Turn off fog for this camera frame
        }
    }

    void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        // Restore the original fog state for other cameras
        if (camera == targetCamera)
        {
            RenderSettings.fog = originalFogState;
        }
    }
}
