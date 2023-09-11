using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectOnBoundries : MonoBehaviour
{
    private DirectionComponent direction;
    private Vector2 screenBounds;

    private void OnEnable()
    {
        direction = GetComponentInChildren<DirectionComponent>();
        screenBounds = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void LateUpdate()
    {
        var transformPos = transform.position;
        Vector3 newPos = transformPos;

        bool flipX = false;
        bool flipY = false;

        // right of screen
        if (transformPos.x > screenBounds.x)
        {
            newPos.x = screenBounds.x;
            flipX = true;
        }
        // left of screen
        else if (transformPos.x < -screenBounds.x)
        {
            newPos.x = -screenBounds.x;
            flipX = true;
        }
        
        // top of screen of screen
        if (transformPos.y > screenBounds.y)
        {
            newPos.y = screenBounds.y;
            flipY = true;
        }
        // bottom of screen of screen
        else if (transformPos.y < -screenBounds.y)
        {
            newPos.y = -screenBounds.y;
            flipY = true;
        }
        
        if (flipX)
        {
            FlipX(direction.Value);
        } 
        if (flipY)
        {
            FlipY(direction.Value);
        }

        if (flipX && flipY)
        {
            Debug.Log("WOW WE HIT THE CORNER");
        }

        transform.position = newPos;
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
