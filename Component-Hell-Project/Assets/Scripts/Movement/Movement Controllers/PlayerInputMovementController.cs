using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovementController : MovementControllerBase
{
    public Vector2 Direction;
    
    protected override void HandleMovement()
    {
        Vector2 direction = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
        characterMover.Move(direction);

        Direction = direction;
    }
}
