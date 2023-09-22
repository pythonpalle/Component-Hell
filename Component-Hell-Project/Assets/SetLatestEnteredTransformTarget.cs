using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLatestEnteredTransformTarget : MonoBehaviour
{
    [SerializeField] private TowardTransformMovementController _towardTransformMovementController;
    
    private Transform baseTransform;

    public void Start()
    {
        baseTransform = _towardTransformMovementController.TargetTransform;
    }

    public void ResetTargetTransform()
    {
        _towardTransformMovementController.TargetTransform = baseTransform;
    }

    public void SetTargetByApplier(EffectApplyHandler applier)
    {
        _towardTransformMovementController.TargetTransform = applier.transform;

    }
}
