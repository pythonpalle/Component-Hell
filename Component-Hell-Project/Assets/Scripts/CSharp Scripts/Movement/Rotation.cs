using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float speed = 40;
    
    private void Update()
    {
        transform.root.Rotate(Vector3.forward, Time.deltaTime * speed); 
    }
}
