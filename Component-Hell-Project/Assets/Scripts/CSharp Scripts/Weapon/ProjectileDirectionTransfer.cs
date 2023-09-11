using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDirectionTransfer : MonoBehaviour
{
    //TODO: Gör mer generell genom att skapa direction interface?
    private DirectionComponent _directionComponent;
    
    private void Awake()
    {
        _directionComponent = GetComponent<DirectionComponent>();
    }

    public void TransferDirection(Projectile projectile)
    {
        projectile.DirectionComponent.Value = _directionComponent.Value;
    } 
}
