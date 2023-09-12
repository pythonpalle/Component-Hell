using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomiseDirection : GameComponent
{
    private Vector2Variable _directionComponent;
    private Random _random;

    private void OnEnable()
    {
        _directionComponent = _metaContainer.MovementContainer.DirectionVariable;
        _random = new Random();
    }

    public void Randomise()
    {
        var newDirection = new Vector2
        {
            x = (float) _random.NextDouble()*2-1,
            y = (float) _random.NextDouble()*2-1, 
        }.normalized;

        _directionComponent.value = newDirection;
    }
}
