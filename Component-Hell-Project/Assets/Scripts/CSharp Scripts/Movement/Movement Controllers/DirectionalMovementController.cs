using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    public Vector2 direction;

    protected override void HandleMovement()
    {
        ObjectMover.Move(direction);
    }

    private void OnValidate()
    {
        direction.Normalize();
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        Gizmos.DrawLine(pos, pos + (Vector3)direction);
    }
}
