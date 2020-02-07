using UnityEngine;
using System;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class PoolInfo
    {
        public GameObject objectToPool;
        public int poolSize;
    }

    [SerializeField]
    private PoolInfo[] _poolsInfo = null;
    public PoolInfo[] poolsInfo
    {
        get => _poolsInfo;
    }

    public static ObjectPool instance { get; private set; }

    private Dictionary<string, Queue<GameObject>> _pools;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        _pools = new Dictionary<string, Queue<GameObject>>();
        foreach (PoolInfo poolInfo in _poolsInfo)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolInfo.poolSize; i++)
            {
                GameObject obj = Instantiate(poolInfo.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _pools.Add(poolInfo.objectToPool.name, objectPool);
        }
    }

    public GameObject GetFromPoolByName(string objName)
    {
        if (!_pools.ContainsKey(objName.Replace("(Clone)", string.Empty))) throw new ObjectPoolException();

        GameObject temp = null;
        if (_pools[objName].Count > 0)
        {
            temp = _pools[objName].Dequeue();
        }
        else
        {
            foreach (PoolInfo poolInfo in _poolsInfo)
            {
                if (poolInfo.objectToPool.name != objName) continue;

                temp = Instantiate(poolInfo.objectToPool);
                poolInfo.poolSize++;
            }
        }
        return temp;
    }

    public void PutToPoolByName(GameObject obj)
    {
        string name = obj.name.Replace("(Clone)", string.Empty);
        if (!_pools.ContainsKey(name)) throw new ObjectPoolException();

        obj.SetActive(false);
        _pools[name].Enqueue(obj);
    }
}