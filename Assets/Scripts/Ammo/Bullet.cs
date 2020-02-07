using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Min(0.1f)]
    [SerializeField]
    private float _speed = 0.1f;
    [Min(1)]
    [SerializeField]
    private int _damage = 1;

    private Rigidbody _bulletRigidBody;

    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 newMovement = transform.forward * _speed * Time.fixedDeltaTime;
        _bulletRigidBody.MovePosition(_bulletRigidBody.position + newMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            EnemyController controller = other.GetComponent<EnemyController>();
            if (controller != null)
            {
                controller.EnemyTakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}