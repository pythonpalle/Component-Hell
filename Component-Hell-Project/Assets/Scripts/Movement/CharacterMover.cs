using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private Transform rootTransform;
    
    [SerializeField]
    private float speed = 0f;

    private void Awake()
    {
        rootTransform = transform.root;
    }

    public void Move(Vector3 direction)
    {
        rootTransform.position += direction * Time.deltaTime * speed;
    }
}
