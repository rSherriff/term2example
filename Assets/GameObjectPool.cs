using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    public IObjectPool<GameObject> pool;

    void OnDisable()
    {
        // Return to the pool
        pool.Release(this.gameObject);
    }
}

public class GameObjectPool
{
    GameObject go;
    IObjectPool<GameObject> m_Pool;
    public bool collectionChecks = true;
    public int maxPoolSize = 10;

    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                m_Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
            }
            return m_Pool;
        }
    }

    public GameObjectPool(GameObject go, int maxPoolSize)
    {
        this.go = go;
        this.maxPoolSize = maxPoolSize;
    }

    GameObject CreatePooledItem()
    {
        var newgo = GameObject.Instantiate(go);

        var returnToPool = newgo.AddComponent<ReturnToPool>();
        returnToPool.pool = Pool;

        return newgo;
    }

    // Called when an item is returned to the pool using Release
    void OnReturnedToPool(GameObject go)
    {
        go.SetActive(false);
    }

    // Called when an item is taken from the pool using Get
    void OnTakeFromPool(GameObject go)
    {
        go.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyPoolObject(GameObject go)
    {
        Object.Destroy(go);
    }
}

