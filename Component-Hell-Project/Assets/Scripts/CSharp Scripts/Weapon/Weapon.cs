using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Weapon : GameComponent
{
    [Header("Prefabs")]
    [SerializeField] private Projectile projectilePrefab;
    
    [Header("Weapon Components")]
    [SerializeField] private WeaponFireType fireType;

    [SerializeField] private BaseAttackStats _stats;
    public BaseAttackStats Stats => _stats;
    
    [SerializeField] private WeaponController controller;

    private Cooldown _cooldown;


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

        _cooldown = _metaContainer.CooldownContainer.Cooldown;
    }

    public bool CanAttack()
    {
        bool wantsToShoot = !controller || controller.WantsToShoot();
        if (!wantsToShoot) return false;

        bool hasCooledDown = _cooldown.HasCooledDown();

        return hasCooledDown;
    }

    public void Attack(WeaponHandler handler)
    {
        OnPrepareFire?.Invoke();
        fireType.Fire(projectilePrefab, this);
        
        _cooldown.Reset();
    }
}
