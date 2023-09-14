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

    protected override Vector2 GetNextDirection()
    {
        var direction = dataHolder.moveDirection;
        
        if (Time.time > timeOfLastTurn + timeBetweenTurns)
        {
            direction *= -1;
            timeOfLastTurn = Time.time;
        }
        
        return direction;
    }
}
