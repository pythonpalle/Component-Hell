using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionComponent))]
public class DirectionalMovementController : MovementControllerBase
{
    private DirectionComponent _directionComponent;

    private void Awake()
    {
        _directionComponent = GetComponent<DirectionComponent>();
    }

    protected override void HandleMovement()
    {
        ObjectMover.Move(_directionComponent.Value);
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        if (!_directionComponent) return;
        
        Gizmos.DrawLine(pos, pos + (Vector3)_directionComponent.Value);
    }
}
