using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : GameComponent
{
    protected ObjectMover ObjectMover;
    protected Vector2Variable directionValue;

    protected virtual void Start()
    {
        ObjectMover = _metaContainer.MovementContainer.ObjectMover;
        directionValue = _metaContainer.MovementContainer.DirectionVariable;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectMover)
        {
            Debug.Log($"Object moves is missing in {gameObject.name}");
            return;
        }
        
        HandleMovement();
    }

    protected abstract void HandleMovement();
}
