using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovementController : MovementControllerBase
{
    protected override Vector2 GetNextDirection()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
        return direction;
    }
}
