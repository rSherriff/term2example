using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    public static BulletManager Instance
    { 
        get 
        { 
            return instance; 
        } 
    }


    public enum bulletType
    {
        PLAYER,
        ENEMY,
    };

    public GameObject playerBullet;
    public GameObject enemyBullet;
    private List<(bulletType, GameObject)> bulletTypes;

    private Dictionary<bulletType, GameObjectPool> pools;
    public Dictionary<bulletType, GameObjectPool> Pools
    {
        get
        {
            if (pools == null)
            {
                pools = new Dictionary<bulletType, GameObjectPool>();
            }
            return pools;
        }
    }

    public int maxPoolSize;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    { 
        Pools.Add(bulletType.PLAYER, new GameObjectPool(playerBullet, maxPoolSize));
        Pools.Add(bulletType.ENEMY, new GameObjectPool(enemyBullet, maxPoolSize));
    }

    public Bullet GetBullet(bulletType type)
    {
        switch(type)
        {
            case bulletType.PLAYER:
                return Pools[bulletType.PLAYER].Pool.Get().GetComponent<Bullet>();

            case bulletType.ENEMY:
                return Pools[bulletType.ENEMY].Pool.Get().GetComponent<Bullet>();

            default: return null;
        }

    }

    //void OnGUI()
    //{
    //    GUILayout.Label("Pool size: " + Pools[0].Pool.CountInactive);
    //    if (GUILayout.Button("Create Bullets"))
    //    {
    //        var amount = UnityEngine.Random.Range(1, 20);
    //        Debug.Log("Attempting to create " + amount + " bullets.");
    //        for (int i = 0; i < amount; ++i)
    //        {
    //            var go = Pools[0].Pool.Get();
    //            go.GetComponent<Bullet>().Setup(Vector3.up, 0, 2, 1);
    //            go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
    //        }
    //    }
    //}
}


