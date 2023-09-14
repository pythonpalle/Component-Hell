

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct DynamicFloat
{
    [SerializeField] private float value;
    public float Value => value;
    
    [NonSerialized] private List<DynamicFloat> multipliers;


    public void AddMultiplier(DynamicFloat mult)
    {
        if (multipliers == null)
        {
            multipliers = new List<DynamicFloat>();
        }

        if (multipliers.Contains(mult))
        {
            multipliers.Add(mult);
            value *= mult.value;
        }
    }
    
    public void RemoveMultiplier(DynamicFloat mult)
    {
        if (multipliers == null)
        {
            multipliers = new List<DynamicFloat>();
        }

        if (multipliers.Contains(mult))
        {
            multipliers.Remove(mult);
            value /= mult.value;
        }
    }

    public void Add(float adder)
    {
        value += adder;
    }
}