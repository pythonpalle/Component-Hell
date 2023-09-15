using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        EnemyManager.Instance.AddEnemy(this);
    }
    
    private void OnDestroy()
    {
        EnemyManager.Instance.RemoveEnemy(this);
    }
}
