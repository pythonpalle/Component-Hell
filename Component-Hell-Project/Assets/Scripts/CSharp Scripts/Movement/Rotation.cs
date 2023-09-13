using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : GameComponent
{
    [SerializeField] private float speed = 40;

    private Transform transformToRotate;

    private void Start()
    {
        transformToRotate = transform.root;
    }

    private void Update()
    {
        transformToRotate.Rotate(Vector3.forward, Time.deltaTime * speed); 
    }
}
