using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedComponent))]
[RequireComponent(typeof(DirectionComponent))]
public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Transform transformToMove;

    private SpeedComponent speedComponent;
    private DirectionComponent directionComponent;

    private void Awake()
    {
        speedComponent = GetComponent<SpeedComponent>();
        directionComponent = GetComponent<DirectionComponent>();
    }

    private void OnEnable()
    {
        if (!transformToMove)
            transformToMove = transform;
    }

    public void Move(Vector3 direction)
    {
        direction = direction.normalized;
        directionComponent.Value = direction;
        transformToMove.position += direction * (Time.deltaTime * speedComponent.currentValue);
    }
}
