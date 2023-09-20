using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [Header("Projectile Prefab")]
    [SerializeField] private Projectile projectilePrefab;
    
    [Header("Components")]
    [SerializeField] private FireHandler fireHandler;
    [SerializeField] private WeaponDataContainer _weaponDataContainer;
    [SerializeField] private UpgradeManager upgradeManager;
    
    public WeaponDataContainer WeaponDataContainer => _weaponDataContainer;

    public Vector2 Direction { get; private set; }

    public void TryAttack()
    {
        fireHandler.TryFire(projectilePrefab, this);
    }

    public void UpdateDirection(Vector2 direction)
    {
        this.Direction = direction;
    }

    public UpgradeManager GetUpgradeManager()
    {
        return upgradeManager;
    }
}