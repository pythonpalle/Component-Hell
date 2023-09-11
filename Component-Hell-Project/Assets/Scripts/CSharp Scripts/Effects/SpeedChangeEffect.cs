using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeEffect : EffectComponent
{
    [SerializeField] private float speedChangeMultiplier;
    private SpeedComponent _speedComponent;
    
    
    public override void OnInstantiated(float effectValue)
    {
        base.OnInstantiated(effectValue);
        
        // hatar detta
        _speedComponent = _metaContainer.MovementContainer.SpeedComponent;
        
        // för att undvika zero division
        if (speedChangeMultiplier <= 0)
            speedChangeMultiplier = 0.001f;
        
        _speedComponent.currentValue *= speedChangeMultiplier;
        
        Destroy(gameObject, duration); 
    }

    private void OnDestroy()
    {
        _speedComponent.currentValue /= speedChangeMultiplier;
    }
} 
