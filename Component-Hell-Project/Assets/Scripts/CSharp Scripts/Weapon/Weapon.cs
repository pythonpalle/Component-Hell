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

    [SerializeField] private WeaponStats _stats;
    public WeaponStats Stats => _stats;
    
    [SerializeField] private DirectionComponent direction;
    // [SerializeField] private Cooldown cooldown;
    //
    // [Space]    
    // [SerializeField] private SpeedComponent speed;
    // [SerializeField] private DamageComponent damage;
    // [SerializeField] private SizeComponent size;

    // public SpeedComponent SpeedComponent => speed;
    // public DamageComponent DamageComponent => damage;
    // public DirectionComponent DirectionComponent => direction;
    //
    // public SizeComponent SizeComponent => size;


    [Header("Events")] 
    public UnityEvent OnProjectileFired;

    private void Awake()
    {
        if (!fireType) 
            fireType = GetComponent<WeaponFireType>();

        if (!_stats)
        {
            _stats = GetComponentInChildren<WeaponStats>();
        }

        // if (!speed) 
        //     speed = GetComponent<SpeedComponent>();
        //
        // if (!direction) 
        //     direction = GetComponent<DirectionComponent>();
        //
        // if (!size) 
        //     size = GetComponent<SizeComponent>();
        //
        // if (!cooldown) 
        //     cooldown = GetComponent<Cooldown>();
    }
    

    public void Setup(WeaponHandler handler)
    {
        _stats.OverrideStats(handler.Stats);
        
        // speed.currentValue = speed.baseValue * handler.Stats.SpeedComponent.currentValue;
        // damage.currentValue = damage.baseValue * handler.Stats.DamageComponent.currentValue; 
        // size.currentValue = size.baseValue * handler.Stats.SizeComponent.currentValue; 
    }

    public void TryAttack()
    {
        bool hasCooledDown = _stats.Cooldown.hasCooledDown;
        
        if (hasCooledDown)
        {
            OnProjectileFired?.Invoke(); 

            fireType.Fire(projectilePrefab, this);
            _stats.Cooldown.Reset();
        }
    }
}
