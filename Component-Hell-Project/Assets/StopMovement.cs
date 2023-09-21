using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    private MovementManager movementManager;
    
    // Start is called before the first frame update
    void Start()
    {
        movementManager = GetComponent<MovementManager>();
    }

    public void StopMove()
    {
        movementManager.DataHolder.moveSpeed.AddMultiplier("Stop", 0);
    }
}
