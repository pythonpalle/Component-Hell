using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionComponent: MonoBehaviour
{
    public Vector2 Value;

    private void OnValidate()
    {
        Value.Normalize();
    }
}
