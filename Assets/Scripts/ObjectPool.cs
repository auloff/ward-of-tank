using UnityEngine;
using System;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct PoolInfo
    {
        public GameObject objectToPool;
        public string tagName;
        public int poolSize;
    }
    
    public PoolInfo[] poolsInfo;

    private ObjectPool _instance;
    public ObjectPool instance
    {
        get
        {
            if (_instance == null)
                _instance = this;

            return _instance;
        }
    }

    private Dictionary<string, Queue<GameObject>> _pools;

    private void Awake()
    {
        _pools = new Dictionary<string, Queue<GameObject>>();
        foreach (PoolInfo poolInfo in poolsInfo)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolInfo.poolSize; i++)
            {
                GameObject obj = Instantiate(poolInfo.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _pools.Add(poolInfo.tagName, objectPool);
        }
    }
}