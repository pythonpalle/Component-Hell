using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
   [Header("Direction")]
    [SerializeField] private Vector2Variable directionVariable;
    public Vector2Variable DirectionVariable => directionVariable;

    [Header("Speed")]
    [SerializeField] private FloatVariable movementSpeed;
    public FloatVariable MovementSpeed => movementSpeed;

    private void Awake()
    {
        if (instantiateScriptableVariables)
        {
            directionVariable = Instantiate(directionVariable);
            movementSpeed = Instantiate(movementSpeed);
        }
    }
}
