using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionalMovementController))]
public class ReflectOnBoundries : MonoBehaviour
{
    private DirectionalMovementController _controller;
    private Vector2 screenBounds;

    private void OnEnable()
    {
        _controller = GetComponent<DirectionalMovementController>();
        screenBounds = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        var currentDirection = _controller.direction;
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x)
        {
            FlipX(currentDirection);
        } else if (transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            FlipY(currentDirection);
        }
    }

    private void FlipX(Vector2 currentDirection)
    {
        _controller.direction = new Vector2(-currentDirection.x, currentDirection.y);
    }
    
    private void FlipY(Vector2 currentDirection)
    {
        _controller.direction = new Vector2(currentDirection.x, -currentDirection.y);
    }
}
