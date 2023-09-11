using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomiseDirection : MonoBehaviour
{
    private DirectionComponent _directionComponent;
    private Random _random;

    private void Awake()
    {
        _directionComponent = GetComponent<DirectionComponent>();
        _random = new Random();
    }

    public void Randomise()
    {
        var newDirection = new Vector2
        {
            x = (float) _random.NextDouble()*2-1,
            y = (float) _random.NextDouble()*2-1, 
        }.normalized;

        _directionComponent.Value = newDirection;
        
        Debug.Log("New direction: " + newDirection);
        Debug.Log("New value: " + _directionComponent.Value);
    }
}
