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
    [SerializeField] private DirectionComponent direction;
    [SerializeField] private Cooldown cooldown;
    
    [Space]    
    [SerializeField] private SpeedComponent speed;
    [SerializeField] private DamageComponent damage;

    public SpeedComponent SpeedComponent => speed;
    public DamageComponent DamageComponent => damage;
    public DirectionComponent DirectionComponent => direction;

    [Header("Events")] 
    public UnityEvent OnProjectileFired;

    private void Awake()
    {
        if (!fireType) 
            fireType = GetComponent<WeaponFireType>();

        if (!speed) 
            speed = GetComponent<SpeedComponent>();
        
        if (!direction) 
            direction = GetComponent<DirectionComponent>();
        
        if (!cooldown) 
            cooldown = GetComponent<Cooldown>();
    }
    

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
            OnProjectileFired?.Invoke(); 

            fireType.Fire(projectilePrefab, this);
            cooldown.Reset();
        }
    }
}
