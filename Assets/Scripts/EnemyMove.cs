using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;

    private Transform _target;
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(_target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            BaseStats stats = collision.collider.GetComponent<BaseStats>();
            stats.TakeDamage(2);
        }
    }
}