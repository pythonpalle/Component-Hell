using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : MonoBehaviour
{
    [SerializeField] private DynamicFloat effectTime;

    public List<EffectComponent> activeEffects = new List<EffectComponent>();

    public void AddMultiplier(string name, float value)
    {
        effectTime.AddMultiplier(name, value);
    }
}