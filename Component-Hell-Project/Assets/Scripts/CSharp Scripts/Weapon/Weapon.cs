using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Projectile projectilePrefab;
    
    [Header("Weapon Components")]
    [SerializeField] private WeaponFireType fireType;

    [SerializeField] private BaseAttackStats _stats;
    public BaseAttackStats Stats => _stats;
    
    [SerializeField] private WeaponController controller;


    [Header("Events")] 
    public UnityEvent OnPrepareFire;
    public UnityEvent<Projectile> OnProjectileSpawned;

    private void Awake()
    {
        if (!fireType) 
            fireType = GetComponent<WeaponFireType>();

        if (!_stats)
        {
            _stats = GetComponentInChildren<BaseAttackStats>();
        }
    }

    public void TryAttack(WeaponHandler handler)
    {
        bool wantsToShoot = !controller || controller.WantsToShoot();
        if (!wantsToShoot) return;
        
        bool hasCooledDown =!_stats || _stats.Cooldown.hasCooledDown;
        
        if (hasCooledDown)
        {
            // override stats from the weapon handler
            _stats.OverrideStats(handler.Stats);
            
            OnPrepareFire?.Invoke();
            fireType.Fire(projectilePrefab, this);
            
            _stats.Cooldown.Reset();
        }
    }
}
