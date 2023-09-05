using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPlayerDestination : MovementControllerBase
{
    [SerializeField] private Vector2Variable playerDirection;
    [SerializeField] private float unitsAheadOfPlayer = 5f;
    
    private Transform player;

    protected override void OnEnable()
    {
        base.OnEnable();
        player = GameObject.FindWithTag("Player").transform;
    }

    protected override void HandleMovement()
    {
        Vector2 playerDir = playerDirection.value;
        
        var playerTargetPos = player.transform.position + (Vector3)playerDir * unitsAheadOfPlayer;
         var moveDir = (playerTargetPos - transform.position).normalized;
        
         ObjectMover.Move(moveDir);
    }

}
