using System;
using System.Collections;
using UnityEngine;

public abstract class UpgradeObject : ScriptableObject
{
    public string description = "Applies upgrade to a game object";
    public abstract void Apply(Transform owner);
}