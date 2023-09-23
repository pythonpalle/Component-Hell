using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementController/PlayerInput")]
public class PlayerInputMovementController : MovementControllerBase
{
    public override Vector2 GetNextDirection(MovementManager movementManager)
    {
        return new Vector2(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
    }
}
