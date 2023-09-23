using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/ToPlayerPosition")]
public class MovementToPlayerPosition : MovementControllerBase
{
    private PlayerPositionSingleton playerPositionSingleton;

    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        TryFindThisTransform(movementManager);
        

        if (!playerPositionSingleton)
            playerPositionSingleton = PlayerPositionSingleton.Instance;
        
        Vector2 playerPos = playerPositionSingleton.Position;

        return (playerPos - (Vector2)thisTransform.position);

    }
}