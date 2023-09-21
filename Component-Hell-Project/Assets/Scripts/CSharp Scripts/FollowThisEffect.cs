using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThisEffect : EffectComponent
{
    [SerializeField] private string deactivationTargetName;
    
    private TowardTransformMovementController towardTransformTargetController;

    protected override void Activate()
    {
        if (!towardTransformTargetController)
            towardTransformTargetController = MyUtility.TryFindComponentUpwards<TowardTransformMovementController>(transform);
        
        if (towardTransformTargetController)
        {
            towardTransformTargetController.TargetTransform = Adder;
        }
    }

    protected override void Deactivate()
    {
        if (towardTransformTargetController)
        {
            towardTransformTargetController.TargetTransform = GameObject.FindWithTag(deactivationTargetName).transform;
        }
    }
}
