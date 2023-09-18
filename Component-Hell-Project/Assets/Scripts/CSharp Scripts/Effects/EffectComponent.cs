using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAfterSeconds))]
public abstract class EffectComponent : MonoBehaviour
{
    private EffectContainer effectContainer;
    public DynamicFloat effectDuration;

    public void OnInstantiated(EffectContainer effectContainer, DynamicFloat effectTimeValue)
    {
        this.effectContainer = effectContainer;
        effectDuration.AddMultiplier("Instantiator", effectTimeValue.Value);
        
        this.effectContainer.AddEffect(this);
        Activate();
        GetComponent<DestroyAfterSeconds>().SetLifeTime(effectDuration.Value);
    }

    private void OnDestroy()
    {
        Deactivate();
        this.effectContainer.RemoveEffect(this);
    }
    
    protected abstract void Activate();

    protected abstract void Deactivate();
}
