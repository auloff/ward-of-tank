using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    public float speed 
    {
        get
        {
            if (agent == null) return 0f;

            return agent.speed;
        }
        set
        {
            if (value < 0) agent.speed = 0f;
            else agent.speed = value;
        } 
    }

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }
}