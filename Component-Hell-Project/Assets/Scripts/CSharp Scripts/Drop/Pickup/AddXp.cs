using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class AddXp : MonoBehaviour
{
    [SerializeField] private float xpToAdd = 1f;
    [SerializeField] private float lifeTime = 20f;
    private float timeOfSpawn;
    private IObjectPool<AddXp> xpPool;

    public void Add()
    {
        XpManager.Instance.AddXP(xpToAdd);
    }

    private void OnEnable()
    {
        timeOfSpawn = Time.time;
    }

    private void Update()
    {
        if (Time.time > timeOfSpawn + lifeTime)
        {
            // TODO: some flicker animation to show that it is despawning
            ReleaseFromPool();
        }
    }

    public void SetPool(IObjectPool<AddXp> xpPool)
    {
        this.xpPool = xpPool;
    }
    
    public void ReleaseFromPool()
    {
        xpPool.Release(this);
    }
}
