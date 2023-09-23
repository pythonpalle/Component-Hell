using System;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/NearestEnemy")]
public class ChaseNearestEnemyMovementController : MovementControllerBase
{
    private EnemyManager _enemyManager;
    
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        TryFindThisTransform(movementManager);
        
        if (!_enemyManager)
        {
            _enemyManager = EnemyManager.Instance; 
        }

        var pos = thisTransform.position;
        var closestEnemy = _enemyManager.FindClosestEnemy(pos);

        Vector2 direction = closestEnemy ? closestEnemy.transform.position - pos : movementManager.GetDirection();
        
        return direction;
    }
}