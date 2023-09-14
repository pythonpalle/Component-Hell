using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/MovementDataHolder")]
public class MovementDataHolder : ScriptableObject
{
    public Vector2 moveDirection;
    public DynamicFloat moveSpeed = new DynamicFloat(); 
}
