using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponData")]
public class WeaponDataHolder : ScriptableObject
{
    [Header("Attack")]
    public DynamicFloat attackDamage;
    public DynamicFloat attackSpeed;
    public DynamicFloat attackSize;
    
    [Space]
    
    public DynamicFloat penetration;
    public DynamicFloat amount;
    public DynamicFloat lifeTime;
    
    [Header("Effect")]
    public DynamicFloat effectDuration;
    
    [Header("Cooldown")]
    [Tooltip("Cooldown time between bursts of shots")]
    public DynamicFloat burstCooldown;
    
    [Tooltip("Cooldown time between shots within a burst")]
    public DynamicFloat shotCooldown;
}
