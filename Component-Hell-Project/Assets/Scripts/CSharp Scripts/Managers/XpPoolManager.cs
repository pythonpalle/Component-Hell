using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class XpPoolManager : MonoBehaviour
{
    [SerializeField] private AddXp addXpPrefab;
    private IObjectPool<AddXp> xpPool;

    private static int maxSpawned = 200;
    private float spawnedXps;

    public static XpPoolManager Instance;

    private void Awake()
    {
        Instance = this;
        
        xpPool = new ObjectPool<AddXp>(CreateXp, OnTakeXpFromPool, OnReleaseXpFromPool, null, true, 25, maxSpawned);
    }

    private AddXp CreateXp()
    {
        var xp = Instantiate(addXpPrefab);
        xp.SetPool(xpPool);
        return xp;
    }
    
    private void OnTakeXpFromPool(AddXp xp)
    {
        xp.gameObject.SetActive(true);
        spawnedXps++;
    }
    
    private void OnReleaseXpFromPool(AddXp xp)
    {
        xp.gameObject.SetActive(false);
        spawnedXps--;
    }

    public void SpawnOrb(Vector3 spawnPosition)
    {
        var orb = xpPool.Get();
        orb.transform.position = spawnPosition;
    }
}
