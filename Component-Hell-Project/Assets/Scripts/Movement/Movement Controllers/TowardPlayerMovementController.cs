using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardPlayerMovementController : MovementControllerBase
{
    private Transform player;

    
    protected override void OnEnable()
    {
        base.OnEnable();
        
        player = GameObject.FindWithTag("Player").transform;
    }
    
    protected override void HandleMovement()
    {
        var directionTowardPlayer = (player.position - transform.position).normalized;
        characterMover.Move(directionTowardPlayer);
    }
}
