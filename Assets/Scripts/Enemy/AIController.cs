using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]
    private int _maxEnemiesCount = 1;
    public int maxEnemiesCount
    {
        get => _maxEnemiesCount;
        set
        {
            if (value <= 0) _maxEnemiesCount = 1;
            else if (value > 10) _maxEnemiesCount = 10;
            else _maxEnemiesCount = value;
        }
    }
    [Min(0.1f)]
    [SerializeField]
    private float _delay = 0.1f;
    public float delay
    {
        get => _delay;
        set
        {
            if (value <= 0f) _delay = 0.1f;
            else _delay = value;
        }
    }
    [SerializeField]
    private Transform spawn = null;

    private float _timeToDelay;
    private int _currentEnemiesCount = 0;
    private List<Transform> _points;
    private GameObject _target;

    void Start()
    {
        _timeToDelay = Time.time;
        _points = new List<Transform>();
        _target = FindObjectOfType<PlayerMovement>().gameObject;
        for (int i = 0; i < spawn.childCount; i++)
        {
            _points.Add(spawn.GetChild(i));
        }
    }

    void Update()
    {
        if (_currentEnemiesCount < _maxEnemiesCount && spawn != null)
        {
            if (Time.time - _timeToDelay > _delay)
            {
                SpawnEnemy();
                _timeToDelay = Time.time;
            }
        }
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, ObjectPool.instance.poolsInfo.Length);
        string enemyTag = ObjectPool.instance.poolsInfo[randomEnemy].objectToPool.name;
        GameObject enemy = ObjectPool.instance.GetFromPoolByName(enemyTag);

        int randomPoint = Random.Range(0, _points.Count);
        enemy.transform.position = _points[randomPoint].position;
        enemy.SetActive(true);

        EnemyController tempController = enemy.GetComponent<EnemyController>();
        tempController.homePoint = _points[randomPoint];
        tempController.playerTarget = _target.transform;
        tempController.GoToPool += () => { _currentEnemiesCount--; };

        _currentEnemiesCount++;
    }
}
