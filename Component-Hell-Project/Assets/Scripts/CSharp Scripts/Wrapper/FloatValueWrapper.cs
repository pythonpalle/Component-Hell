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
        if (!baseValue)
        {
            return;
        }
        
        if (instantiateFloatValue)
        {
            baseValue = Instantiate(baseValue);
        }

        currentValue = Instantiate(baseValue);

        if (!currentValue)
        {
            Debug.Log($"Missing current value for {gameObject.name}");
        }
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
        
        for (int i = multipliers.Count - 1; i >= 0; i--)
        {
            currentValue.value *= multipliers[i].value;
        }
    }
}
