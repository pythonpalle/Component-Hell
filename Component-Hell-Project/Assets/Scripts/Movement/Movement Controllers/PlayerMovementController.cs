using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementControllerBase
{
    protected override void Update()
    {
        base.Update();
        
        Vector2 direction = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
        characterMover.Move(direction);
    }
}
