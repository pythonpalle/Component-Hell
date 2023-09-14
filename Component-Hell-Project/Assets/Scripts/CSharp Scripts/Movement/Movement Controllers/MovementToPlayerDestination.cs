using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToPlayerDestination : MovementControllerBase
{
    [SerializeField] private Vector2Variable playerDirection;
    [SerializeField] private float unitsAheadOfPlayer = 5f;
    
    private Transform playerTransform;
    
    protected override void Start()
    {
        base.Start();

        var playerObject = GameObject.FindWithTag("Player");
        if (playerObject)
            playerTransform = playerObject.transform;
    }

    protected override Vector2 GetNextDirection()
    {
        Vector2 playerDir = playerDirection.value;

        var playerTargetPos = playerTransform.transform.position + (Vector3)playerDir * unitsAheadOfPlayer;
         var moveDir = (playerTargetPos - transform.position);

         return moveDir;
    }

}
