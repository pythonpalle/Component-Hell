using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Transform transformToMove;

    private void Start()
    {
        if (!transformToMove) transformToMove = transform.root;
    }

    public void Move(Vector3 direction, float speed)
    {
        direction = direction.normalized;
        transformToMove.position += direction * (Time.deltaTime * speed);
    }
}
