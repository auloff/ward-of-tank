using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed;   
    public Transform target;
    public Vector3 offset; 
    private void FixedUpdate() {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, cameraSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;

        transform.LookAt(target);
    }
}
