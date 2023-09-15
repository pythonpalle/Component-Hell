using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CooldownData")]
public class CooldownDataHolder : ScriptableObject
{
    [Tooltip("Cooldown time between bursts of shots")]
    public DynamicFloat burstCooldown;
    
    [Tooltip("Cooldown time between shots within a burst")]
    public DynamicFloat shotCooldown;
}
