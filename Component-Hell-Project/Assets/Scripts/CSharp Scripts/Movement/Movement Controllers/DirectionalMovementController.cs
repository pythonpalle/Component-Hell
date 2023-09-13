using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleMovement()
    {
        ObjectMover.Move(directionValue.value);
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        
        Gizmos.DrawLine(pos, pos + (Vector3)directionValue.value);
    }
}
