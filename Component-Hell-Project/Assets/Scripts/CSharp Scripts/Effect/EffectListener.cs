using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectListener : MonoBehaviour
{
    private EffectApplyHandler applier;
    public EffectType _effectType;
    
    public UnityEvent<EffectApplyHandler> OnActivate;
    public UnityEvent OnDeactivate;
    public bool IsActive { get; private set; }
    private float timeOfLastActivation;

    private float duration;

    public void Activate(float duration, EffectApplyHandler applier)
    {
        this.applier = applier;
        this.duration = duration;

        OnActivate?.Invoke(applier);
        IsActive = true;
        timeOfLastActivation = Time.time;
    }

    private void Deactivate() 
    {
        OnDeactivate?.Invoke();
        IsActive = false;
    }

    private void LateUpdate()
    {
        UpdateDeactivation();
    }
    
    private void UpdateDeactivation()
    {
        if (IsActive && Time.time >= timeOfLastActivation + duration)
        {
            Deactivate();
        }
    }
}
