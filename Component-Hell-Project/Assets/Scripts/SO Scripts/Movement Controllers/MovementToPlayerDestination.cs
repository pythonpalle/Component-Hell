using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/ToPlayerDestination")]
public class MovementToPlayerDestination : MovementControllerBase
{
    private PlayerDirectionSingleton playerDirectionSingleton;
    private PlayerPositionSingleton playerPositionSingleton;

    [SerializeField] private float unitsAheadOfPlayer = 2;
    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        TryFindThisTransform(movementManager);

        if (!playerDirectionSingleton)
            playerDirectionSingleton = PlayerDirectionSingleton.Instance;

        if (!playerPositionSingleton)
            playerPositionSingleton = PlayerPositionSingleton.Instance;
        
        Vector2 playerDest = playerPositionSingleton.Position + playerDirectionSingleton.Direction * unitsAheadOfPlayer;

        return playerDest - (Vector2)thisTransform.position;

    }
}