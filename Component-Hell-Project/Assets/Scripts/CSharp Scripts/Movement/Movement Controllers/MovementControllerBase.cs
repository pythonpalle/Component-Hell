using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : MonoBehaviour
{
    private ObjectMover objectMover;
    private MovementManager MovementManager;
    protected MovementDataHolder _movementDataHolder;
    
    protected virtual void Start()
    {
        objectMover = GetComponent<ObjectMover>();
        MovementManager = GetComponent<MovementManager>();
        _movementDataHolder = MovementManager.DataHolder;
    }

    void Update()
    {
        var direction = GetNextDirection().normalized;
        objectMover.Move(direction, _movementDataHolder.moveSpeed.Value);
        MovementManager.UpdateMovement(direction);
    }

    protected abstract Vector2 GetNextDirection();
}
