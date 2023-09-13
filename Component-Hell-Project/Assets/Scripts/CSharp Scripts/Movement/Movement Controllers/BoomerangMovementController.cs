using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovementController : MovementControllerBase
{
    [SerializeField] private float timeBetweenTurns = 1f;
    private float timeOfLastTurn;

    protected override void Start()
    {
        base.Start();
        timeOfLastTurn = Time.time;
    }

    protected override void HandleMovement()
    {
        var direction = directionValue.value;
        
        if (Time.time > timeOfLastTurn + timeBetweenTurns)
        {
            direction *= -1;
            timeOfLastTurn = Time.time;
        }
        
        ObjectMover.Move(direction);
    }
}
