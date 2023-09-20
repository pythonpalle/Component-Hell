using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveDataTransfer : MonoBehaviour, WeaponDataUpdateListener, IMovementListener
{
    private MovementManager _movementManager;
    private WeaponDataHolder _dataHolder;
    private void Awake()
    {
        _movementManager = GetComponent<MovementManager>();
    }

    public void OnMovementChange(Vector2 direction)
    {
        _movementManager.DataHolder.moveSpeed.AddMultiplier(_dataHolder.name, _dataHolder.attackSpeed.Value);
        _movementManager.DataHolder.moveDirection = direction;
    }

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        _dataHolder = data;
    }
}
