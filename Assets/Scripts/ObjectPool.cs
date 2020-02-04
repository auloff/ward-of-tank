using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private ObjectPool instance;
    private Dictionary<string, Queue<GameObject>> pools;

    public ObjectPool Instance
    {
        get
        {
            if (instance == null)
                instance = this;

            return instance;
        }
    }

    [Serializable]
    public class PoolInfo
    {
        public string tagName;
        public GameObject objectToPool;
        public int poolSize;
    }

    public PoolInfo[] poolsInfo;

    private void Awake()
    {
        pools = new Dictionary<string, Queue<GameObject>>();
        foreach (PoolInfo poolInfo in poolsInfo)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolInfo.poolSize; i++)
            {
                GameObject obj = Instantiate(poolInfo.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            pools.Add(poolInfo.tagName, objectPool);
        }
    }
}
