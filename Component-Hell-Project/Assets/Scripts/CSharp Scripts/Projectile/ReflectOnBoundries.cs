using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectOnBoundries : GameComponent
{
    //private DirectionComponent direction;
    private Vector2Variable direction;
    private Vector2 screenBounds;
    private Transform objectTransform;

    public override void Setup (MetaContainer container)
    {
        base.Setup(container);
        
        //direction = _metaContainer.MovementContainer.DirectionComponent;
        direction = _metaContainer.MovementContainer.DirectionVariable;
        
        //TOdo: optimera
        screenBounds = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        objectTransform = _metaContainer.transform;
    }

    void LateUpdate()
    {
        var transformPos = objectTransform.position;
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
            FlipX(direction.value);
        } 
        if (flipY)
        {
            FlipY(direction.value);
        }

        if (flipX && flipY)
        {
            Debug.Log("WOW WE HIT THE CORNER");
        }

        objectTransform.position = newPos;
    }

    private void FlipX(Vector2 currentDirection)
    {
        direction.value = new Vector2(-currentDirection.x, currentDirection.y);
    }
    
    private void FlipY(Vector2 currentDirection)
    {
        direction.value = new Vector2(currentDirection.x, -currentDirection.y);
    }
}
