using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealthDataTransfer : MonoBehaviour, IProjectileSpawnListener
{
    private HealthManager _healthManager;
    
    void Awake()
    {
        _healthManager = GetComponent<HealthManager>();
    }

    public void OnProjectileSpawn(WeaponDataHolder data, Vector2 direction)
    {
        _healthManager.IncreaseMaxHealth(data.name, data.penetration.Value, true);
    }
}
