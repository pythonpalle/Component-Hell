using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : GameComponent
{
    protected ObjectMover ObjectMover;

    protected virtual void Start()
    {
        ObjectMover = GetComponentInChildren<ObjectMover>();
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
