using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageDataTransfer : MonoBehaviour, IProjectileSpawnListener
{
    private ColliderDamageHandler _damageHandler;
    
    private void Awake()
    {
        _damageHandler = GetComponent<ColliderDamageHandler>();
    }

    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 _)
    {
        _damageHandler.damageValue.AddMultiplier(data.name, data.attackDamage.Value);
    }
}
