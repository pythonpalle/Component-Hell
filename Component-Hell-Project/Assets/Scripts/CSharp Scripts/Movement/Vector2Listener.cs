using System;
using UnityEngine;

public abstract class Vector2Listener : MonoBehaviour, IVector2ChangeListener
{
    public abstract void OnVector2Change(Vector2 direction);
}