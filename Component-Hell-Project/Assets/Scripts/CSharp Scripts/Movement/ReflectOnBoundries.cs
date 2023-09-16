using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectOnBoundries : MonoBehaviour
{
    private Vector2 screenBounds;
    
    [SerializeField] private Transform objectTransform;
    private MovementDataHolder _dataHolder;

    private ScreenManager _screenManager;

    private void Start ()
    {
        _dataHolder = GetComponent<MovementManager>().DataHolder;
        _screenManager = ScreenManager.Instance;

        if (!objectTransform) objectTransform = transform.root;

    }

    void LateUpdate()
    {
        var transformPos = objectTransform.position;
        Vector3 newPos = transformPos;

        bool flipX = false;
        bool flipY = false;


        // right of screen
        if (transformPos.x > _screenManager.maxX)
        {
            newPos.x = _screenManager.maxX;
            flipX = true;
        }
        // left of screen
        else if (transformPos.x < _screenManager.minX)
        {
            newPos.x = _screenManager.minX;
            flipX = true;
        }
        
        // top of screen of screen
        if (transformPos.y > _screenManager.maxY)
        {
            newPos.y = _screenManager.maxY;
            flipY = true;
        }
        // bottom of screen of screen
        else if (transformPos.y < _screenManager.minY)
        {
            newPos.y = _screenManager.minY;
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
