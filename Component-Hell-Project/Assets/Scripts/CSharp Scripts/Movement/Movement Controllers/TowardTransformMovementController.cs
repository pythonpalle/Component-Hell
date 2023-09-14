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

    protected override Vector2 GetNextDirection()
    {
        var directionTowardPlayer = (targetTransform.position - transform.position);
        return (directionTowardPlayer);
    }
}
