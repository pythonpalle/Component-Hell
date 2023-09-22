using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLatestEnteredTransformTarget : MonoBehaviour
{
    [SerializeField] private TowardTransformMovementController _towardTransformMovementController;
    
    private Transform baseTransform;
    private Collider2D latestCollider;

    public void Start()
    {
        baseTransform = _towardTransformMovementController.TargetTransform;
    }

    public void OnLatestStoredCollider(Collider2D latest)
    {
        latestCollider = latest;
    }

    public void SetTargetToLatestStored()
    {
        _towardTransformMovementController.TargetTransform = latestCollider.transform;
    }
    
    public void ResetTargetTransform()
    {
        _towardTransformMovementController.TargetTransform = baseTransform;
    }
}
