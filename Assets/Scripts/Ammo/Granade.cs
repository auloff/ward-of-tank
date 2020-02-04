using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Granade : MonoBehaviour
{
    public float force;
    public float explosionDelay;
    public float explosionForce;
    public int explosionDamage;
    public float explosionRadius;
    public AudioSource explosionAudio;

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
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Health targetHealth = targetRigidbody.GetComponent<Health>();

            if (!targetHealth)
                continue;

            targetHealth.TakeDamage(explosionDamage);
        }

        if (explosionAudio != null)
            explosionAudio.Play();

        if (explosionParticle != null)
        {
            explosionParticle.transform.parent = null;
            explosionParticle.Play();

            ParticleSystem.MainModule mainModule = explosionParticle.main;
            Destroy(explosionParticle.gameObject, mainModule.duration);
        }

        Destroy(gameObject);
    }
}
