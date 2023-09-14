using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : GameComponent
{
    private ObjectMover objectMover;
    protected MovementDataHolder dataHolder;
    
    protected virtual void Start()
    {
        objectMover = GetComponent<ObjectMover>();
        dataHolder = GetComponent<MovementContainer>().DataHolder;
    }

    void Update()
    {
        var direction = GetNextDirection().normalized;
        dataHolder.moveDirection = direction;
        objectMover.Move(direction, dataHolder.moveSpeed.Value);
    }

    protected abstract Vector2 GetNextDirection();
}
