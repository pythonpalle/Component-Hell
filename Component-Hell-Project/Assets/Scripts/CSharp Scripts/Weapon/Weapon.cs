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
    
    [Header("Data")]
    [SerializeField] private WeaponDataHolder weaponData;
    
    [Header("Components")]
    [SerializeField] private FireHandler fireHandler;
    [SerializeField] private WeaponController controller;

    private Cooldown _cooldown;
    
    

    [Header("Events")] 
    public UnityEvent OnPrepareFire;
    public UnityEvent<Projectile> OnProjectileSpawned;
    

    public void TryAttack()
    {
        Attack();
    }
    
    private bool CanAttack()
    {
        return true;
    }

    private void Attack()
    {
        fireHandler.TryFire(projectilePrefab, weaponData);
    }

    public void UpdateData(WeaponDataHolder fromData)
    {
        string owner = fromData.name;
        
        weaponData.attackDamage.AddMultiplier(owner, fromData.attackDamage.Value);
        weaponData.attackSpeed.AddMultiplier(owner, fromData.attackSpeed.Value);
        weaponData.attackSize.AddMultiplier(owner, fromData.attackSize.Value);
        weaponData.effectDuration.AddMultiplier(owner, fromData.effectDuration.Value);
        weaponData.lifeTime.AddMultiplier(owner, fromData.lifeTime.Value);
        
        weaponData.burstCooldown.AddMultiplier(owner, fromData.burstCooldown.Value);
        weaponData.shotCooldown.AddMultiplier(owner, fromData.shotCooldown.Value);
        
        weaponData.amount.AddAdder(owner, fromData.amount.Value);
        weaponData.penetration.AddAdder(owner, fromData.penetration.Value);
    }
}
