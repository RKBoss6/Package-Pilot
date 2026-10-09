
using UnityEngine;

public class CarSurfaceAligner : MonoBehaviour
{
    public float rayLength = 3f;
    public float rayStartHeight = 1.5f;
    public float rotationSpeed = 8f;
    public float alignmentStrength = 1f;

    public Transform frontLeft;
    public Transform frontRight;
    public Transform rearLeft;
    public Transform rearRight;

    public LayerMask groundLayers = Physics.DefaultRaycastLayers;

    void LateUpdate()
    {
        if (!frontLeft || !frontRight || !rearLeft || !rearRight)
            return;

        Vector3[] points = new Vector3[4];
        Transform[] wheels = { frontLeft, frontRight, rearLeft, rearRight };

        int count = 0;

        foreach (Transform wheel in wheels)
        {
            Vector3 origin = wheel.position + Vector3.up * rayStartHeight;

            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit,
                rayLength + rayStartHeight, groundLayers,
                QueryTriggerInteraction.Ignore))
            {
                points[count++] = hit.point;
            }
        }

        if (count < 3)
            return;

        Vector3 normal = Vector3.zero;

        for (int i = 1; i < count - 1; i++)
        {
            normal += Vector3.Cross(
                points[i] - points[0],
                points[i + 1] - points[0]
            );
        }

        if (normal.sqrMagnitude < 0.0001f)
            return;

        normal.Normalize();

        if (Vector3.Dot(normal, Vector3.up) < 0f)
            normal = -normal;

        Vector3 forward = Vector3.ProjectOnPlane(transform.forward, normal);

        if (forward.sqrMagnitude < 0.0001f)
            return;

        Quaternion target = Quaternion.LookRotation(forward, normal);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            target,
            rotationSpeed * alignmentStrength * Time.deltaTime
        );
    }
}
