using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : ScriptableObject
{
    protected Transform thisTransform;
    
    public abstract Vector2 GetNextDirection(MovementManager movementManager);
    
    protected void TryFindThisTransform(MovementManager movementManager)
    {
        if (thisTransform == null)
            thisTransform = movementManager.transform;
    }
}
