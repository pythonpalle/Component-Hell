using System;
using System.Collections;
using UnityEngine;

public abstract class UpgradeObject : ScriptableObject
{
    [SerializeField] private string description = "Applies upgrade to a game object";
    public String Description => description;
    public abstract void Apply(Transform owner);
}