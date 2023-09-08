using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEffect : EffectComponent
{
    [SerializeField] private float slowDownMultiplier;
    [SerializeField] private float duration;

    private SpeedComponent _speedComponent;
    
    
    private void OnEnable()
    {
        // hatar detta
        _speedComponent = transform.parent.GetComponentInChildren<SpeedComponent>();
        _speedComponent.currentValue *= slowDownMultiplier;
        
        Destroy(gameObject, duration);
    }

    private void OnDestroy()
    {
        _speedComponent.currentValue /= slowDownMultiplier;
    }
} 
