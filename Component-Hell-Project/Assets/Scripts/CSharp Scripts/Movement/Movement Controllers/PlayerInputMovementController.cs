using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovementController : MovementControllerBase
{
    public Vector2Variable playerDirection;
    
    protected override void HandleMovement()
    {
        Vector2 direction = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
        ObjectMover.Move(direction);

        playerDirection.value = direction;
    }
}
