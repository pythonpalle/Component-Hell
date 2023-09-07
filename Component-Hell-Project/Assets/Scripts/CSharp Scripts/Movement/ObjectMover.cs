using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedComponent))]
[RequireComponent(typeof(DirectionComponent))]
public class ObjectMover : MonoBehaviour
{
    private Transform rootTransform;

    private SpeedComponent speedComponent;
    private DirectionComponent directionComponent;

    private void Awake()
    {
        rootTransform = transform.root;

        speedComponent = GetComponent<SpeedComponent>();
        directionComponent = GetComponent<DirectionComponent>();
    }

    public void Move(Vector3 direction)
    {
        directionComponent.Value = direction;
        rootTransform.position += direction * (Time.deltaTime * speedComponent.currentValue);
    }
}
