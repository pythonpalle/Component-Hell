using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : GameComponent
{
    [SerializeField] private Transform transformToMove;

    private DirectionComponent _directionComponent;
    private SpeedComponent _speedComponent;

    private Vector2Variable directionVar;
    private FloatVariable speedVar;

    public bool useContainer;

    private void OnEnable()
    {
        if (!transformToMove)
            transformToMove = transform;

        // if (useContainer)
        // {
        //     _directionComponent = _metaContainer.MovementContainer.DirectionComponent;
        //     _speedComponent = _metaContainer.MovementContainer.SpeedComponent;
        // }
        
        
            directionVar = _metaContainer.MovementContainer.DirectionVariable;
            speedVar = _metaContainer.MovementContainer.MovementSpeed;
        
    }

    public void Move(Vector3 direction)
    {
        // if (useContainer)
        // {
        //     direction = direction.normalized;
        //     _directionComponent.Value = direction; // kan bli referensfel
        //     transformToMove.position += direction * (Time.deltaTime * _speedComponent.currentValue); // detta är dock fine
        // }
        
        
            direction = direction.normalized;
            directionVar.value = direction;
            transformToMove.position += direction * (Time.deltaTime * speedVar.value); // detta är dock fine
            
            return;
        
        
        
        
    }
}
