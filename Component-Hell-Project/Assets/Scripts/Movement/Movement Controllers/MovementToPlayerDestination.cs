using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPlayerDestination : MovementControllerBase
{
    private Transform player;

    protected override void OnEnable()
    {
        base.OnEnable();
        player = GameObject.FindWithTag("Player").transform;
    }

    protected override void HandleMovement()
    {
        //Vector2 playerDir = player.Direction;
        //
        // var dir = (player.transform.position + (Vector3)playerDir * 10 - transform.position).normalized;
        //
        // characterMover.Move(dir);
    }

}
