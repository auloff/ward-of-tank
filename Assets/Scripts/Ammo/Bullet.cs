using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody bulletRigidBody;

    private void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 newMovement = transform.forward * speed * Time.fixedDeltaTime;
        bulletRigidBody.MovePosition(bulletRigidBody.position + newMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            Destroy(gameObject);
    }
}