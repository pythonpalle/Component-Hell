using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectComponent : MonoBehaviour
{
    private EffectManager _effectManager;
    public DynamicFloat effectDuration;

    public void OnInstantiated(EffectManager effectManager, DynamicFloat effectTimeValue)
    {
        _effectManager = effectManager;
        effectDuration.AddMultiplier("Instantiator", effectTimeValue.Value);
        
        _effectManager.AddEffect(this);
        Activate();
        Invoke(nameof(HandleDeactivation), effectDuration.Value);
    }

    public void Reactivate()
    {
        Activate();
        Invoke(nameof(HandleDeactivation), effectDuration.Value);
    }
    
    public void HandleDeactivation()
    {
        Deactivate();
        gameObject.SetActive(false);
    }
    
    protected abstract void Activate();

    protected abstract void Deactivate();
}
