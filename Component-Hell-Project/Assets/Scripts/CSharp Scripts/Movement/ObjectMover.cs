using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeedComponent))]
public class ObjectMover : MonoBehaviour
{
    private Transform rootTransform;

    private SpeedComponent speedComponent;

    private void Awake()
    {
        rootTransform = transform.root;

        speedComponent = GetComponent<SpeedComponent>();
    }

    public void Move(Vector3 direction)
    {
        rootTransform.position += direction * (Time.deltaTime * speedComponent.currentValue);
    }
}
