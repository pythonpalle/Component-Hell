using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FireTypes/HandlerDirection")]
public class HandlerDirectionFireType : FireType
{
    private Vector2 lastNonZeroDirection = Vector2.right;
    
    protected override Vector2 GetDirection(Weapon owner, int round)
    {
        var ownerDir = owner.Direction;
        if (ownerDir != Vector2.zero)
        {
            lastNonZeroDirection = ownerDir;
        }
        
        return lastNonZeroDirection;
    }
}
