using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaContainer : MonoBehaviour
{
    [SerializeField] private MovementManager movementManager;
    public MovementManager MovementManager => movementManager;
    
    [SerializeField] private HealthManager healthManager;
    public HealthManager HealthManager => healthManager;
    
    
    [SerializeField] private CollisionContainer collisionContainer;
    public CollisionContainer CollisionContainer => collisionContainer;
    
    [SerializeField] private EffectContainer effectContainer;
    public EffectContainer EffectContainer => effectContainer;

    [SerializeField] private CooldownContainer _cooldownContainer;
    public CooldownContainer CooldownContainer => _cooldownContainer;

   
}
