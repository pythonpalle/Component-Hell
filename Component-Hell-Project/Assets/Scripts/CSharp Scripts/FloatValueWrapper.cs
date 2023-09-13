using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatValueWrapper : MonoBehaviour
{
    [SerializeField] private bool instantiateFloatValue = true;

    [SerializeField] private FloatVariable baseValue;
    
    private FloatVariable currentValue;
    private List<FloatVariable> multipliers = new List<FloatVariable>();

    public FloatVariable CurrentValue => currentValue;

    private void Awake()
    {
        if (instantiateFloatValue)
        {
            baseValue = Instantiate(baseValue);
        }

        currentValue = Instantiate(baseValue);
    }

    public void AddMultiplier(FloatVariable floatVariable)
    {
        if (multipliers.Contains(floatVariable))
        {
            return;
        }
        multipliers.Add(floatVariable);
        UpdateCurrentValue();
    }

    public void RemoveMultiplier(FloatVariable floatVariable)
    {
        multipliers.Remove(floatVariable);
        UpdateCurrentValue();
    }

    private void UpdateCurrentValue()
    {
        currentValue.value = baseValue.value;
        foreach (var multiplier in multipliers)
        {
            currentValue.value *= multiplier.value;
        }
    }
}
