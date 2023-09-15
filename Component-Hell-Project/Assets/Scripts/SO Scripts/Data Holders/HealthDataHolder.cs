using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/HealthDataHolder")]
public class HealthDataHolder : ScriptableObject
{
    public float health;
    public DynamicFloat maxHealth;
    public DynamicFloat armour;
    public DynamicFloat regeneration;
}
