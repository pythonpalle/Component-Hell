using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardTransformMovementController : MovementControllerBase
{
    [SerializeField]
    protected Transform targetTransform;

    public Transform TargetTransform
    {
        get => targetTransform;
        set => targetTransform = value;
    }

    protected override void HandleMovement()
    {
        if (!targetTransform)
            return;
        
        var directionTowardPlayer = (targetTransform.position - transform.position);
        ObjectMover.Move(directionTowardPlayer);
    }
}
