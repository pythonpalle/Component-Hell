using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeEffect : EffectComponent
{
    [SerializeField] private FloatVariable speedChangeMultiplier;
    private FloatValueWrapper speedWrapper;
    
    public override void OnInstantiated(float effectValue)
    {
        base.OnInstantiated(effectValue);

        speedWrapper = _metaContainer.MovementContainer.ValueWrapper;
        speedWrapper.AddMultiplier(speedChangeMultiplier);
        
        Destroy(gameObject, duration); 
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        speedWrapper.RemoveMultiplier(speedChangeMultiplier);
    } 
} 
