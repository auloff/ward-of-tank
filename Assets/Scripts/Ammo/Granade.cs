using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Granade : MonoBehaviour
{
    [Min(0.1f)]
    [SerializeField]
    private float force = 0.1f;
    [Min(1)]
    [SerializeField]
    private int explosionDamage = 1;
    [Min(0.1f)]
    [SerializeField]
    private float explosionDelay = 0.1f;
    [Min(0.1f)]
    [SerializeField]
    private float explosionRadius = 0.1f;

    private ParticleSystem explosionParticle;
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
        explosionParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        bulletRigidBody.AddForce(transform.forward * force, ForceMode.Impulse);
        StartCoroutine(MakeBoom());
    }

    private IEnumerator MakeBoom()
    {
        yield return new WaitForSeconds(explosionDelay);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyController targetController = colliders[i].GetComponent<EnemyController>();

            if (targetController == null)
                continue;

            targetController.EnemyTakeDamage(explosionDamage);
        }

        if (explosionParticle != null)
        {
            explosionParticle.transform.parent = null;
            explosionParticle.Play();

            ParticleSystem.MainModule mainModule = explosionParticle.main;
            Destroy(explosionParticle.gameObject, mainModule.duration);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
