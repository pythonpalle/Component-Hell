using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    [SerializeField] private Vector2 direction;

    protected override void HandleMovement()
    {
        characterMover.Move(direction);
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
