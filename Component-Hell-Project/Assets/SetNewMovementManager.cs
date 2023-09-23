using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewMovementManager : MonoBehaviour
{
    [SerializeField]private MovementManager _movementManager; 
    [SerializeField]private MovementControllerBase newController; 
    
    private MovementControllerBase lastController;

    public void StoreLastController()
    {
        lastController = _movementManager.GetController();
    }

    public void SetNewController()
    {
        _movementManager.SetMoveController(newController);
    }

    public void RestoreLastController()
    {
        _movementManager.SetMoveController(lastController);
    }
}
