using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/ToTargetTransform")]
public class TowardTransformMovementController : MovementControllerBase
{
    private Transform target;
    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        if (!target)
            target = movementManager.GetTarget();

        if (!target)
        {
            return movementManager.GetDirection();
        }
        
        TryFindThisTransform(movementManager);
        return target.position - thisTransform.position;
    }

    
}
