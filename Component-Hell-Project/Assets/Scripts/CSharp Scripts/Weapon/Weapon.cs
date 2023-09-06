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
    [SerializeField] private WeaponController controller;
    [SerializeField] private DirectionComponent direction;
    [SerializeField] private Cooldown cooldown;
    
    [Space]    
    [SerializeField] private SpeedComponent speed;
    [SerializeField] private DamageComponent damage;

    public SpeedComponent SpeedComponent => speed;
    public DamageComponent DamageComponent => damage;


    private void Awake()
    {
        if (!fireType) 
            fireType = GetComponent<WeaponFireType>();
        
        if (!controller) 
            controller = GetComponent<WeaponController>();
        
        if (!speed) 
            speed = GetComponent<SpeedComponent>();
        
        if (!direction) 
            direction = GetComponent<DirectionComponent>();
        
        if (!cooldown) 
            cooldown = GetComponent<Cooldown>();
    }

    // private void Update()
    // {
    //     HandleShooting();
    // }

    public void Setup(SpeedComponent speedComponent, DamageComponent damageComponent)
    {
        speed.currentValue = speed.baseValue * speedComponent.currentValue;
        damage.currentValue = damage.baseValue * damageComponent.currentValue;
    }

    public void TryAttack()
    {
        bool hasCooledDown = !cooldown || cooldown.hasCooledDown;
        
        if (hasCooledDown)
        {
            fireType.Fire(projectilePrefab, this);
            cooldown.Reset();
        }
    }

    // private void HandleShooting()
    // {
    //     bool wantsToShoot = !controller || controller.WantsToShoot();
    //     bool hasCooledDown = !cooldown || cooldown.hasCooledDown;
    //     
    //     if (wantsToShoot && hasCooledDown)
    //     {
    //         fireType.Fire(projectilePrefab);
    //         cooldown.Reset();
    //     }
    // }

    void SetupProjectiles(List<Projectile> projectiles)
    {
        foreach (var projectile in projectiles)
        {
            
        }
    }
}
