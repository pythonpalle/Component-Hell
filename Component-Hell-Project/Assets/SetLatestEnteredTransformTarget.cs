using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLatestEnteredTransformTarget : MonoBehaviour
{
    [SerializeField] private MovementManager _movementManager;
    
    private Transform baseTransform;

    public void Start()
    {
        baseTransform = _movementManager.GetTarget();
    }

    public void ResetTargetTransform()
    {
        _movementManager.SetTargetTransform(baseTransform);
    }

    public void SetTargetByApplier(EffectApplyHandler applier)
    {
        _movementManager.SetTargetTransform(applier.transform);
    }
}
