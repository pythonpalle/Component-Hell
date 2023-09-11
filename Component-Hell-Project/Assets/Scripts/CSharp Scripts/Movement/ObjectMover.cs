using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : GameComponent
{
    [SerializeField] private Transform transformToMove;

    private DirectionComponent _directionComponent;
    private SpeedComponent _speedComponent;

    private void OnEnable()
    {
        if (!transformToMove)
            transformToMove = transform;

        _directionComponent = _metaContainer.MovementContainer.DirectionComponent;
        _speedComponent = _metaContainer.MovementContainer.SpeedComponent;
    }

    public void Move(Vector3 direction)
    {
        direction = direction.normalized;
        _directionComponent.Value = direction; // kan bli referensfel
        transformToMove.position += direction * (Time.deltaTime * _speedComponent.currentValue); // detta är dock fine
    }
}
