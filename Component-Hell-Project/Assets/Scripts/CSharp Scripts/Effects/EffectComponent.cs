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
        this._effectManager = effectManager;
        effectDuration.AddMultiplier("Instantiator", effectTimeValue.Value);
        
        this._effectManager.AddEffect(this);
        Activate();
        //GetComponent<DestroyAfterSeconds>().SetLifeTime(effectDuration.Value);
        Invoke(nameof(HandleDeactivation), effectDuration.Value);
    }

    public void Reactivate()
    {
        Activate();
        //GetComponent<DestroyAfterSeconds>().SetLifeTime(effectDuration.Value);
        Invoke(nameof(HandleDeactivation), effectDuration.Value);
    }

    // private void OnDestroy()
    // {
    //     Deactivate();
    //     this._effectManager.RemoveEffect(this);
    // }

    public void HandleDeactivation()
    {
        Deactivate();
        gameObject.SetActive(false);
    }
    
    protected abstract void Activate();

    protected abstract void Deactivate();
}
