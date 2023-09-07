using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponStats))]
public class Projectile : MonoBehaviour
{
    // [SerializeField] private SpeedComponent speed;
    // [SerializeField] private DamageComponent damage;
    // [SerializeField] private DirectionComponent direction;
    // [SerializeField] private SizeComponent size;

    [SerializeField] private WeaponStats _stats; 
    
    private void Awake()
    {
        _stats = GetComponentInChildren<WeaponStats>();

        // if (!speed) 
        //     speed = GetComponent<SpeedComponent>();
        //
        // if (!direction) 
        //     direction = GetComponent<DirectionComponent>();
        //
        // if (!size) 
        //     size = GetComponent<SizeComponent>();
    }
    
    public void SetUp(Weapon weapon)
    {
        _stats.OverrideStats(weapon.Stats);
        
        // speed.currentValue = speed.baseValue * weapon.SpeedComponent.currentValue;
        // damage.currentValue = damage.baseValue * weapon.DamageComponent.currentValue;
        // size.currentValue = size.baseValue * weapon.SizeComponent.currentValue;
        //
        // direction.Value = weapon.DirectionComponent.Value;
    }
}
