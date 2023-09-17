using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed = 180;
    [SerializeField] private bool rotateRoot;

    private Transform transformToRotate;

    private void Start()
    {
        transformToRotate = rotateRoot ?transform.root : transform;
    }

    private void Update()
    {
        transformToRotate.Rotate(Vector3.forward, Time.deltaTime * speed); 
    }
}