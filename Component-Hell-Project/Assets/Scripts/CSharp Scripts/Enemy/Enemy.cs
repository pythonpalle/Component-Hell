using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IHasEnemyPool
{
    private IObjectPool<Enemy> enemyPool;

    public void SetPool(ObjectPool<Enemy> enemyPool)
    {
        this.enemyPool = enemyPool;
        EnemyManager.Instance.AddEnemy(this);
    }

    public void ReleaseFromPool()
    {
        enemyPool.Release(this);
        EnemyManager.Instance.RemoveEnemy(this);
    }
}

public interface IHasEnemyPool
{
    public void SetPool(ObjectPool<Enemy> pool);
    public void ReleaseFromPool();
}
