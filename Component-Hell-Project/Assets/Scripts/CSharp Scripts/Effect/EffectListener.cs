using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectListener : MonoBehaviour
{
    public EffectType _effectType;
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    public void Activate()
    {
        OnActivate?.Invoke();
    }

    public void Deactivate()
    {
        OnDeactivate?.Invoke();
    }
}
