using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovementController : MovementControllerBase
{
    protected override Vector2 GetNextDirection()
    {
        return (_movementDataHolder.moveDirection);
    }
}
