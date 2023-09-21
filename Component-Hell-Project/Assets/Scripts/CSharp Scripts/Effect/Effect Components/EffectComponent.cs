using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EffectComponent : MonoBehaviour
{
    public UnityEvent OnActivasion;
    public UnityEvent OnDeacivation;
    
    private EffectManager _effectManager;
    public DynamicFloat effectDuration;
    protected Transform Adder { get; set; }


    public void OnInstantiated(EffectManager effectManager, DynamicFloat effectTimeValue, Transform adder)
    {
        Adder = adder;
        
        _effectManager = effectManager;
        effectDuration.AddMultiplier("Instantiator", effectTimeValue.Value);
        _effectManager.AddEffect(this);

        HandleActivation();
    }

    private void HandleActivation()
    {
        Activate();
        OnActivasion?.Invoke();
        Invoke(nameof(HandleDeactivation), effectDuration.Value);
    }

    public void Reactivate()
    {
        HandleActivation();
    }
    
    public void HandleDeactivation()
    {
        Deactivate();
        OnDeacivation?.Invoke();
        gameObject.SetActive(false);
    }
    
    protected abstract void Activate();

    protected abstract void Deactivate();

    public void SetAdder(EffectAdder adder)
    {
        if (adder) Adder = adder.transform;
    }
}
