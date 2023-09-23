using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/Directional")]
public class DirectionalMovementController : MovementControllerBase
{
    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        return movementManager.GetDirection();
    }
}
