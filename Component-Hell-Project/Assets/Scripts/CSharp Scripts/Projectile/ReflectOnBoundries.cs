using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectOnBoundries : MonoBehaviour
{
    private Vector2 screenBounds;
    
    [SerializeField] private Transform objectTransform;
    private MovementDataHolder _dataHolder;

    private void Start ()
    {
        _dataHolder = GetComponent<MovementContainer>().DataHolder;

        //TOdo: optimera
        screenBounds = Camera.main.ScreenToWorldPoint
            (new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

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
            FlipX();
        } 
        if (flipY)
        {
            FlipY();

            if (flipX)
            {
                Debug.Log("WOW WE HIT THE CORNER");
            }
        }

        objectTransform.position = newPos;
    }

    private void FlipX()
    {
        var moveDir = _dataHolder.moveDirection;
        _dataHolder.moveDirection= new Vector2(-moveDir.x, moveDir.y);
    }
    
    private void FlipY()
    {
        var moveDir = _dataHolder.moveDirection;
        _dataHolder.moveDirection= new Vector2(moveDir.x, -moveDir.y);
    }
}
