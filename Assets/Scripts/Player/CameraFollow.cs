using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Min(0.01f)]
    [SerializeField]
    private float _cameraSpeed;
    public float cameraSpeed
    {
        get => _cameraSpeed;
        set
        {
            if (value <= 0f) _cameraSpeed = 0.01f;
            else _cameraSpeed = value;
        }
    }

    [SerializeField]
    private Transform _target;
    public Transform target
    {
        get => _target;
        set => _target = value;
    }

    [SerializeField]
    private Vector3 _offset;
    public Vector3 offset
    {
        get => _offset;
        set => _offset = value;
    }

    private void FixedUpdate()
    {
        if (_target == null) return;

        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position + _offset, _cameraSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;
        transform.LookAt(_target);
    }
}