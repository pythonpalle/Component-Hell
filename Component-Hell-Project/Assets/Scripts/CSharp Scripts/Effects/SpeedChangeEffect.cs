using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeEffect : EffectComponent
{
    [SerializeField] private float speedChangeMultiplier;
    private FloatVariable speedVariable;
    
    public override void OnInstantiated(float effectValue)
    {
        base.OnInstantiated(effectValue);

        // för att undvika zero division
        if (speedChangeMultiplier <= 0)
            speedChangeMultiplier = 0.001f;

        speedVariable = _metaContainer.MovementContainer.MovementSpeed;
        speedVariable.value *= speedChangeMultiplier;
        
        Destroy(gameObject, duration); 
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        // _speedComponent.currentValue /= speedChangeMultiplier;
        speedVariable.value /= speedChangeMultiplier;

    } 
} 
