using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomiseDirection : MonoBehaviour
{
    private Random _random;

    private void OnEnable()
    {
        _random = new Random();
    }

    public void Randomise(MovementDataHolder moveData)
    {
        var newDirection = new Vector2
        {
            x = (float) _random.NextDouble()*2-1,
            y = (float) _random.NextDouble()*2-1, 
        }.normalized;

        moveData.moveDirection = newDirection;
    }
}
