using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IHasEnemyPool
{
    private IObjectPool<Enemy> enemyPool;
    [SerializeField] private InvisibilityChecker invisibilityChecker;

    private void OnEnable()
    {
        EnemyManager.Instance.AddEnemy(this);
        invisibilityChecker.OnInvisibleTooLong.AddListener(ReleaseFromPool);
    }
    
    private void OnDisable()
    {
        EnemyManager.Instance.RemoveEnemy(this);
        invisibilityChecker.OnInvisibleTooLong.RemoveListener(ReleaseFromPool);
    }
    

    public void SetPool(ObjectPool<Enemy> enemyPool)
    {
        this.enemyPool = enemyPool;
    }

    public void ReleaseFromPool()
    {
        enemyPool.Release(this);
    }
}

public interface IHasEnemyPool
{
    public void SetPool(ObjectPool<Enemy> pool);
    public void ReleaseFromPool();
}
