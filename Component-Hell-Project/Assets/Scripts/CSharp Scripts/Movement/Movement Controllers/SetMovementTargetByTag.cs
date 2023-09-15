using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowardTransformMovementController))]
public class SetMovementTargetByTag : MonoBehaviour
{
    [SerializeField] string targetTag = "Enemy";

    private TowardTransformMovementController controller;

    private void Awake()
    {
        controller = GetComponent<TowardTransformMovementController>();
        TryFindTarget();
    }

    void TryFindTarget()
    {
        if (controller.TargetTransform == null)
        {
            controller.TargetTransform = GameObject.FindWithTag(targetTag).transform;
        }
    }
}
