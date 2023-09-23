using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/Boomerang")]
public class BoomerangMovementController : MovementControllerBase
{
    [SerializeField] private float timeBetweenTurns = 1f;
    private float timeOfLastTurn = 0.5f;
    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        var direction = movementManager.GetDirection();
        
        if (Time.time > timeOfLastTurn + timeBetweenTurns)
        {
            direction *= -1;
            timeOfLastTurn = Time.time;
        }
        
        return direction;
    }

    private void OnEnable()
    {
        timeOfLastTurn = Time.time - timeBetweenTurns * 0.5f;
    }
}