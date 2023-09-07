using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionComponent))]
public class ProjectileBehaviours : MonoBehaviour
{
    private DirectionComponent _directionComponent;
    
    private void Awake()
    {
        _directionComponent = GetComponent<DirectionComponent>();
    }

    public void OnProjectileSpawned(Projectile projectile)
    {
        projectile.DirectionComponent.Value = _directionComponent.Value;
    }
}
