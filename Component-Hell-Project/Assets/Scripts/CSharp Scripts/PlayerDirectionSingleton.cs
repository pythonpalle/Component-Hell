using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionSingleton : Vector2Listener
{
    public static PlayerDirectionSingleton Instance { get; private set; }
    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public override void OnVector2Change(Vector2 direction)
    {
        Direction = direction;
    }
}