using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Transform transformToMove;
    

    public void Move(Vector3 direction, float speed)
    {
        direction = direction.normalized;
        transformToMove.position += direction * (Time.deltaTime * speed);
    }
}
