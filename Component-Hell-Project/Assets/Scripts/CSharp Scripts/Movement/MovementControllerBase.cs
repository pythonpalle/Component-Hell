using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementControllerBase : MonoBehaviour
{
    protected ObjectMover ObjectMover;

    protected virtual void OnEnable()
    {
        ObjectMover = GetComponentInChildren<ObjectMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectMover)
            return;
        
        HandleMovement();
    }

    protected abstract void HandleMovement();
}
