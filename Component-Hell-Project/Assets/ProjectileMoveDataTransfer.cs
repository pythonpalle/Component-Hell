using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveDataTransfer : MonoBehaviour, IProjectileSpawnListener
{
    private MovementManager _movementManager;
    private void Awake()
    {
        _movementManager = GetComponent<MovementManager>();
    }

    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 direction)
    {
        _movementManager.DataHolder.moveSpeed.AddMultiplier(data.name, data.attackSpeed.Value);
        _movementManager.DataHolder.moveDirection = direction;
    }
}
