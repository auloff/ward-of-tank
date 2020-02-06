using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Min(0.01f)]
    [SerializeField]
    private float _movementSpeed;
    public float movementSpeed
    {
        set
        {
            if (value < 0.01f) _movementSpeed = 0.01f;
            else _movementSpeed = value;
        }
        get => _movementSpeed;
    }
    
    [Min(0.01f)]
    [SerializeField]
    private float _turnSpeed;
    public float turnSpeed
    {
        set
        {
            if (value < 0.01f) _turnSpeed = 0.01f;
            else _turnSpeed = value;
        }
        get => _turnSpeed;
    }

    private Rigidbody _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (vertical != 0)
        {
            Vector3 newMovement = transform.forward * vertical * _movementSpeed * Time.fixedDeltaTime;
            _playerRigidbody.MovePosition(_playerRigidbody.position + newMovement);
        }
        if (horizontal != 0)
        {
            Quaternion newRotation = Quaternion.Euler(0f, horizontal * _turnSpeed, 0f);
            _playerRigidbody.MoveRotation(_playerRigidbody.rotation * newRotation);
        }
    }
}