using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : GameComponent
{
    [SerializeField] private Transform transformToMove;
    
    private Vector2Variable directionVar;
    private FloatVariable speedVar;


    private void OnEnable()
    {
        if (!transformToMove)
            transformToMove = transform;
        
        directionVar = _metaContainer.MovementContainer.DirectionVariable;
        speedVar = _metaContainer.MovementContainer.ValueWrapper.CurrentValue;
    }

    public void Move(Vector3 direction)
    {
        direction = direction.normalized;
        directionVar.value = direction;
        transformToMove.position += direction * (Time.deltaTime * speedVar.value);
    }
}
