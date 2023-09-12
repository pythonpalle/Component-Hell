using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    public bool useComponent = false;
    private DirectionComponent _directionComponent;
    
    private Vector2Variable directionValue;

    private void Awake()
    {
        if (useComponent) _directionComponent = GetComponent<DirectionComponent>();
        else
        {
            directionValue = _metaContainer.MovementContainer.DirectionVariable;
        }
    }

    protected override void HandleMovement()
    {
        if (useComponent)ObjectMover.Move(_directionComponent.Value);
        else
        {
            ObjectMover.Move(directionValue.value);
        }
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        if (!_directionComponent) return; 
        
        Gizmos.DrawLine(pos, pos + (Vector3)_directionComponent.Value);
    }
}
