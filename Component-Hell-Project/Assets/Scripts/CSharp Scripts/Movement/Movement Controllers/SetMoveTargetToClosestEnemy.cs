using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowardTransformMovementController))]
public class SetMoveTargetToClosestEnemy : MonoBehaviour
{
    private TowardTransformMovementController _controller;

    private void Start()
    {
        _controller = GetComponent<TowardTransformMovementController>();
        Invoke(nameof(SetClosestEnemyTarget), 0.01f);
    }

    private void SetClosestEnemyTarget()
    {
        _controller.TargetTransform = FindClosestEnemy();
    }

    private Transform FindClosestEnemy()
    {
        var enemy = EnemyManager.Instance.FindClosestEnemy(transform.position);
        if (enemy)
        {
            return enemy.transform;
        }

        return null;
    }
}
