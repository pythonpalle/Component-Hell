using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private float timeBetweenSpawns = 1f;
    private float timeOfLastSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOfLastSpawn + timeBetweenSpawns)
        {
            SpawnEnemy();
            timeOfLastSpawn = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
    }
}
