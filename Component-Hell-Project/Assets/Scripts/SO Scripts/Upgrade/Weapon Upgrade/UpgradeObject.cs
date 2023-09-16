using System;
using System.Collections;
using UnityEngine;

public abstract class UpgradeObject : ScriptableObject
{
    public abstract void Apply(Transform owner);
}