using System;
using UnityEngine;

public abstract class MovementListener : MonoBehaviour
{
    public abstract void OnMovementChange(Vector2 direction);
}