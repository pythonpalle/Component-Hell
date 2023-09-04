using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPlayerDestination : MovementControllerBase
{
    protected override void HandleMovement()
    {
        var player = FindObjectOfType<PlayerInputMovementController>();
        Vector2 playerDir = player.Direction;

        var dir = (player.transform.position + (Vector3)playerDir * 10 - transform.position).normalized;
        
        characterMover.Move(dir);
    }

}
