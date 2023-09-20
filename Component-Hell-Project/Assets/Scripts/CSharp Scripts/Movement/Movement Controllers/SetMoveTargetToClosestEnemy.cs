using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowardTransformMovementController))]
public class SetMoveTargetToClosestEnemy : MonoBehaviour
{
    private TowardTransformMovementController _controller;
    private EnemyManager _enemyManager;
    private Enemy closest;

    private void Start()
    {
        _enemyManager = EnemyManager.Instance;
        _controller = GetComponent<TowardTransformMovementController>();
        Invoke(nameof(SetClosestEnemyTarget), 0.01f);
    }

    private void FixedUpdate()
    {
        if (!closest || !closest.gameObject.activeSelf)
        {
            SetClosestEnemyTarget();
        }
    }

    private void SetClosestEnemyTarget()
    {
        _controller.TargetTransform = FindClosestEnemy();
    }

    private Transform FindClosestEnemy()
    {
        closest = _enemyManager.FindClosestEnemy(transform.position);
        if (closest)
        {
            return closest.transform;
        }

        return null;
    }
}
