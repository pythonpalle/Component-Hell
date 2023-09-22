using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectListener : MonoBehaviour
{
    public EffectType _effectType;
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;
    public bool IsActive { get; private set; }
    private float timeOfLastActivation;

    private float duration;

    public void Activate(float duration)
    {
        OnActivate?.Invoke();
        IsActive = true;
        timeOfLastActivation = Time.time;
        this.duration = duration;
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
