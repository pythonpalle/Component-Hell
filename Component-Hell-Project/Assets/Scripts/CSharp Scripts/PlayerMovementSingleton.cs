using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSingleton : MovementListener
{
    public static PlayerMovementSingleton Instance { get; private set; }
    public Vector2 Direction;
    public Vector2 Position;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public override void OnMovementChange(Vector2 direction)
    {
        Direction = direction;
    }

    private void Update()
    {
        Position = transform.position;
    }
}
