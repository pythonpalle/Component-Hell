using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowardTransformMovementController))]
public class SetMovementTargetByTag : MonoBehaviour
{
    public string tag = "Enemy";

    private TowardTransformMovementController controller;

    private void Awake()
    {
        controller = GetComponent<TowardTransformMovementController>();
    }

    
    private void Update()
    {
        TryFindTarget(); 
    }

    void TryFindTarget()
    {
        if (controller.TargetTransform == null)
        {
            controller.TargetTransform = GameObject.FindWithTag(tag).transform;
        }
    }
}
