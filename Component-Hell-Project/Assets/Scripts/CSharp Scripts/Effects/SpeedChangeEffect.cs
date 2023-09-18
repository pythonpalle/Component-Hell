using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeEffect : EffectComponent
{
    [SerializeField] private DynamicFloat speedModifier;
    
    protected override void Activate()
    {
        transform.parent.parent.GetComponentInChildren<MovementManager>().DataHolder.moveSpeed.AddMultiplier(name,speedModifier.Value);
    }

    protected override void Deactivate()
    {
        transform.parent.parent.GetComponentInChildren<MovementManager>().DataHolder.moveSpeed.RemoveMultiplier(name);
    }
} 
