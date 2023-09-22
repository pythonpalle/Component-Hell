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

    private void TryFindTarget()
    {
        controller.TargetTransform = GameObject.FindWithTag(targetTag).transform;
    }

    public void UpdateTag(string tagName)
    {
        targetTag = tagName;
        TryFindTarget();
    }
}
