using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private MovementManager _movementManager;

    public void SetNewSpeed()
    {
        _movementManager.DataHolder.moveSpeed.AddMultiplier(name, speedMultiplier);
    }
    
    public void ResetSpeed()
    {
        _movementManager.DataHolder.moveSpeed.RemoveMultiplier(name);
    }
}
