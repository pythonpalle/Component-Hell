using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowardTransformMovementController))]
public class SetPlayerMovementTarget : MonoBehaviour
{
    void OnEnable()
    {
        var controller = GetComponent<TowardTransformMovementController>();
        if (controller == null)
            return;
        
        controller.TargetTransform = GameObject.FindWithTag("Player").transform;
    } 
}
