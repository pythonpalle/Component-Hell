using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovementController : MovementControllerBase
{
    [SerializeField] private float timeBetweenTurns = 1f;
    private float timeOfLastTurn;

    private DirectionComponent directionComponent;

    protected override void OnEnable()
    {
        base.OnEnable();
        directionComponent = GetComponentInChildren<DirectionComponent>();
        timeOfLastTurn = Time.time;
    }

    protected override void HandleMovement()
    {
        var direction = directionComponent.Value;
        
        if (Time.time > timeOfLastTurn + timeBetweenTurns)
        {
            direction *= -1;
            timeOfLastTurn = Time.time;
        }
        
        ObjectMover.Move(direction);
    }
}
