using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<Enemy> Enemies { get;  set; } = new List<Enemy>();
    public int Count;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    
    public void RemoveEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }

    private void Update()
    {
        Count = Enemies.Count;
    }

    public Enemy FindClosestEnemy(Vector2 fromPos)
    {
        var closestDis = float.MaxValue;
        Enemy closestEnemy = null;

        for (int i = 0; i < Enemies.Count; i++)
        {
            float dis = SquareDistance(fromPos, Enemies[i].transform.position);
            if (dis < closestDis)
            {
                closestDis = dis;
                closestEnemy = Enemies[i];
            }
        }

        return closestEnemy;
    }

    private float SquareDistance(Vector2 p1, Vector2 p2)
    {
        float dx = (p2.x - p1.x);
        float dy = (p2.y - p1.y);

        return dx * dx + dy * dy;
    }
}
