using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Min(0.01f)]
    [SerializeField]
    private float _cameraSpeed;
    public float cameraSpeed
    {
        set
        {
            if (value < 0.01f) _cameraSpeed = 0.01f;
            else _cameraSpeed = value;
        }
        get => _cameraSpeed;
    }

    [SerializeField]
    private Transform _target;
    public Transform target
    {
        set => _target = value;
        get => _target;
    }

    [SerializeField]
    private Vector3 _offset;
    public Vector3 offset
    {
        set => _offset = value;
        get => _offset;
    }

    private void FixedUpdate()
    {
        if (_target == null) return;

        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position + _offset, _cameraSpeed * Time.fixedDeltaTime);
        transform.position = newPosition;
        transform.LookAt(_target);
    }
}