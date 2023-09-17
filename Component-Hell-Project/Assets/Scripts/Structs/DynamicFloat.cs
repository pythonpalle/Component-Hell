

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class DynamicFloat
{
    [SerializeField] private float value;
    public float Value => value;
    
    [NonSerialized] private Dictionary<string, float> multipliers;
    [NonSerialized] private Dictionary<string, float> adders;

    private float baseValue;
    private bool hasAssignedBase;


    public void AddMultiplier(string key, float value, bool increaseIfHasValue = false)
    {
        HandleMultipliersInstantiate();
        
        if (multipliers.ContainsKey(key))
        {
            if (increaseIfHasValue)
            {
                multipliers[key] *= value;
            }
            else
            {
                // the value of the key hasn't changed
                if (KeyHasValue(multipliers, key, value))
                {
                    return;
                }
                else
                {
                    multipliers[key] = value;
                }
            }
        }
        else
        {
            multipliers.Add(key, value);
        }
        
        RecalculateCurrentValue();
    }
    
    public void RemoveMultiplier(string key)
    {
        HandleMultipliersInstantiate();

        if (multipliers.ContainsKey(key))
        {
            multipliers.Remove(key);
            RecalculateCurrentValue();
        }
    }
    
    private void HandleMultipliersInstantiate()
    {
        if (multipliers == null)
        {
            multipliers = new Dictionary<string, float>();
            TryAssignBase();
        }
    }

    private static float epsilon = 0.0001f;
    private bool KeyHasValue(Dictionary<string, float> dictionary, string key, float value)
    {
        return Mathf.Abs(dictionary[key] - value) < epsilon;
    }
    
    public void AddAdder(string key, float value, bool increaseIfHasKey = false)
    {
        HandleAddersInstantiate();

        if (adders.ContainsKey(key))
        {
            if (increaseIfHasKey)
            {
                adders[key] += value;
            }
            else
            {
                // the value of the key hasn't changed
                if (KeyHasValue(adders, key, value))
                {
                    return;
                }
                else
                {
                    adders[key] = value;
                }
            }
        }
        else
        {
            adders.Add(key, value);
        }
        
        RecalculateCurrentValue();
    }

    public void RemoveAdder(string key)
    {
        HandleAddersInstantiate();

        if (adders.ContainsKey(key))
        {
            adders.Remove(key);
            RecalculateCurrentValue();
        }
    }

    private void HandleAddersInstantiate()
    {
        if (adders == null)
        {
            adders = new Dictionary<string, float>();
            TryAssignBase();
        }
    }


    private void TryAssignBase()
    {
        if (!hasAssignedBase)
        {
            baseValue = value;
            hasAssignedBase = true;
        }
    }
    
    private void RecalculateCurrentValue()
    {
        value = baseValue;

        if (adders != null)
        {
            foreach (var adder in adders.Values)
            {
                value += adder;
            }
        }

        if (multipliers != null)
        {
            foreach (var multiplier in multipliers.Values)
            {
                value *= multiplier;
            }
        }
    }
}