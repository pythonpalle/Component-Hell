using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDataTransfer : GameComponent
{
    //TODO: Gör mer generell genom att skapa direction interface?
    // private DirectionComponent _directionComponent;
    //
    //
    // private void Awake()
    // {
    //     _directionComponent = GetComponent<DirectionComponent>();
    // }

    public void TransferDirection(GameComponent projectile)
    {
        //projectile.DirectionComponent.Value = _directionComponent.Value;

        projectile.MetaContainer.MovementContainer.DirectionVariable.value =
            _metaContainer.MovementContainer.DirectionComponent.Value; 
    } 
}
