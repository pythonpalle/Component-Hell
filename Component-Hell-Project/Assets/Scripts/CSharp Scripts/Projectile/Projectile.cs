using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseAttackStats))]
public class Projectile : GameComponent
{
    [SerializeField] private BaseAttackStats _stats; 
    [SerializeField] private DirectionComponent directionComponent;
    public DirectionComponent DirectionComponent => directionComponent;

    private void Awake()
    {
        _stats = GetComponentInChildren<BaseAttackStats>();
        directionComponent = GetComponentInChildren<DirectionComponent>();
    }
    
    public void SetUp(Weapon weapon)
    {
        _stats.OverrideStats(weapon.Stats);
    }
}
