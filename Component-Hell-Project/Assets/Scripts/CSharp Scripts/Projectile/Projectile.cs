using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseAttackStats))]
[RequireComponent(typeof(DirectionComponent))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private BaseAttackStats _stats; 
    [SerializeField] private DirectionComponent directionComponent;
    public DirectionComponent DirectionComponent => directionComponent;

    private void Awake()
    {
        _stats = GetComponentInChildren<BaseAttackStats>();
        directionComponent = GetComponent<DirectionComponent>();
    }
    
    public void SetUp(Weapon weapon)
    {
        _stats.OverrideStats(weapon.Stats);
    }
}
