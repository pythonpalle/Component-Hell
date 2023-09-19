using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeEffect : EffectComponent
{
    [SerializeField] private DynamicFloat speedModifier;
    private MovementManager _movementManager;
    
    protected override void Activate()
    {
        _movementManager = MyUtility.TryFindComponentUpwards<MovementManager>(transform);
        if (_movementManager != default)
        {
            _movementManager.DataHolder.moveSpeed.AddMultiplier(name,speedModifier.Value);
        }
    }

    protected override void Deactivate()
    {
        if (_movementManager != default)
        {
            _movementManager.DataHolder.moveSpeed.RemoveMultiplier(name);
        }
    }
} 
