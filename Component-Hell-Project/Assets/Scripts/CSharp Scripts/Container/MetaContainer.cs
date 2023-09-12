using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaContainer : Container
{
    [SerializeField] private MovementContainer _movementContainer;
    public MovementContainer MovementContainer => _movementContainer;
    
    [SerializeField] private HealthContainer healthContainer;
    public HealthContainer HealthContainer => healthContainer;
    
    
    [SerializeField] private CollisionContainer collisionContainer;
    public CollisionContainer CollisionContainer => collisionContainer;
    
    [SerializeField] private EffectContainer effectContainer;
    public EffectContainer EffectContainer => effectContainer;

    [SerializeField] private CooldownContainer _cooldownContainer;
    public CooldownContainer CooldownContainer => _cooldownContainer;

    [SerializeField] private DamageContainer _damageContainer;

    public DamageContainer DamageContainer => _damageContainer;
}
