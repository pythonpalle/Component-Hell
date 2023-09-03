using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public abstract class MovementControllerBase : MonoBehaviour
{
    protected CharacterMover characterMover;

    protected virtual void OnEnable()
    {
        characterMover = GetComponent<CharacterMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!characterMover)
            return;
        
        HandleMovement();
    }

    protected abstract void HandleMovement();
}
