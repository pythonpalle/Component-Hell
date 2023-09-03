using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    [SerializeField] private Vector2 direction;
    
    protected override void Update()
    {
        base.Update();
        characterMover.Move(direction);
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        Gizmos.DrawLine(pos, pos + (Vector3)direction);
    }
}
