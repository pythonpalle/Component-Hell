using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private int spawnBurst = 10;
    [SerializeField] private float spawnOffset = 2f;
    private float timeOfLastSpawn;

    private ObjectPool<Enemy> enemyPool;

    public int spawnedEnemies;

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(CreateEnemy, OnTakeEnemyFromPool, OnReleaseEnemyFromPool);
    }

    private void Start()
    {
        Invoke("SpawnEnemies",0.1f);
    }


    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.SetPool(enemyPool);
        return enemy;
    }
    
    private void OnTakeEnemyFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        spawnedEnemies++;
    }
    
    private void OnReleaseEnemyFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        spawnedEnemies--;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        if (Time.time > timeOfLastSpawn + timeBetweenSpawns)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnBurst; i++)
        {
            SpawnEnemy();
        }
            
        timeOfLastSpawn = Time.time;
    }

    private void SpawnEnemy()
    {
        var enemy = enemyPool.Get();
        Vector3 position = GetRandomSpawnPos();
        enemy.transform.position = position;

    }

    private Vector2 GetRandomSpawnPos()
    {
        float maxX = ScreenManager.Instance.maxX + spawnOffset;
        float maxY = ScreenManager.Instance.maxY + spawnOffset;

        bool outOfScreenX = Random.value > 0.5f;
        bool negative = Random.value > 0.5f;

        float xPos, yPos;

        if (outOfScreenX)
        {
            xPos = negative ? -maxX : maxX;
            yPos = Random.Range(-maxY, maxY);
        }
        else
        {
            yPos = negative ? -maxY : maxY;
            xPos = Random.Range(-maxX, maxX);
        }

        return new Vector2(xPos, yPos);
    }
}
