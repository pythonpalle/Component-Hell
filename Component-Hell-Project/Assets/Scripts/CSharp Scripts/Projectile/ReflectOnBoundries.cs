using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionComponent))]
public class ReflectOnBoundries : MonoBehaviour
{
    private DirectionComponent direction;
    private Vector2 screenBounds;

    private void OnEnable()
    {
        direction = GetComponent<DirectionComponent>();
        screenBounds = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        var currentDirection = direction.Value;
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
        direction.Value = new Vector2(-currentDirection.x, currentDirection.y);
    }
    
    private void FlipY(Vector2 currentDirection)
    {
        direction.Value = new Vector2(currentDirection.x, -currentDirection.y);
    }
}
