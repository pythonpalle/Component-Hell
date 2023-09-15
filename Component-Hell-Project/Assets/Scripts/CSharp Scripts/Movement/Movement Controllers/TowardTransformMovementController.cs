using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardTransformMovementController : MovementControllerBase
{
    [SerializeField]
    protected Transform targetTransform;

    private Vector2 lastValidDirection = Vector2.right;

    public Transform TargetTransform
    {
        get => targetTransform;
        set => targetTransform = value;
    }

    protected override Vector2 GetNextDirection()
    {
        if (targetTransform)
        {
            lastValidDirection = targetTransform.position - transform.position;
        }
        
        return lastValidDirection;
    }
}
