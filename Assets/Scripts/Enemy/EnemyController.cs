using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [Min(0.1f)]
    [SerializeField]
    private float _runAwayDelay = 2f;

    private Transform _playerTarget;
    public Transform playerTarget 
    { 
        get => _playerTarget;
        set
        {
            _playerTarget = value;
            _currentDestination = _playerTarget;
        }
    }
    public Transform homePoint { get; set; }

    [SerializeField]
    private bool _isStay;
    public bool isStay
    {
        get => _isStay;
        set => _isStay = value;
    }

    public event Action GoToPool;

    private EnemyMove _enemyMove;
    private EnemyStats _stats;
    private Transform _currentDestination;
    private void Awake()
    {
        _enemyMove = GetComponent<EnemyMove>();
        _stats = GetComponent<EnemyStats>();
    }

    void FixedUpdate()
    {
        if (!isStay)
        {
            _enemyMove.MoveToTarget(_currentDestination);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(_playerTarget.tag))
        {
            BaseStats playerStats = collision.collider.GetComponent<BaseStats>();
            playerStats.TakeDamage(_stats.damage);
            StartCoroutine(RunAway());
        }
    }

    private IEnumerator RunAway()
    {
        _currentDestination = homePoint;
        yield return new WaitForSeconds(_runAwayDelay);
        _currentDestination = _playerTarget;
    }

    public void EnemyTakeDamage(int damage)
    {
        _stats.TakeDamage(damage);

        if (_stats.heatlh <= 0)
        {
            ObjectPool.instance.PutToPoolByName(this.gameObject);
            GoToPool?.Invoke();
        }
    }
}