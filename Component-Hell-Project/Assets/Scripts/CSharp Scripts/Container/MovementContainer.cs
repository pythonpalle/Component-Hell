using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContainer : Container
{
    // // script komponenter
    // [SerializeField] private DirectionComponent directionComponent;
    // public DirectionComponent DirectionComponent => directionComponent;
    //
    // [SerializeField] private SpeedComponent speedComponent;
    // public SpeedComponent SpeedComponent => speedComponent;


    [Header("Scriptable Objects")]
    // scriptable object komponenter
    [SerializeField] private bool makeInstance;
    
    [SerializeField] private Vector2Variable directionVariable;
    public Vector2Variable DirectionVariable => directionVariable;

    [SerializeField] private FloatVariable movementSpeed;
    public FloatVariable MovementSpeed => movementSpeed;

    private void Awake()
    {
        if (makeInstance)
        {
            directionVariable = Instantiate(directionVariable);
            movementSpeed = Instantiate(movementSpeed);
        }
    }
}
