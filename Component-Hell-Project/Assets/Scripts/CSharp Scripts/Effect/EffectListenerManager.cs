using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectListenerManager : MonoBehaviour
{
    [SerializeField] private List<EffectListener> _effectListeners = new List<EffectListener>();
    private Dictionary<EffectType, List<EffectListener>> listenerDictionary = new Dictionary<EffectType, List<EffectListener>>();
    
    private void Start()
    {
        InitializeListenerDictionary();
    }

    private void InitializeListenerDictionary()
    {
        foreach (var listener in _effectListeners)
        {
            if (!listenerDictionary.ContainsKey(listener._effectType))
            {
                listenerDictionary.Add(listener._effectType, new List<EffectListener>{listener});
            }
            else
            {
                listenerDictionary[listener._effectType].Add(listener);
            }
        }
    }

    public void ApplyEffects(EffectApplyHandler applier, List<EffectType> effectTypes, float duration)
    {
        foreach (var type in effectTypes)
        {
            ApplyAllOfType(applier, type, duration);
        }
    }

    private void ApplyAllOfType(EffectApplyHandler applier, EffectType type, float duration)
    {
        if (!listenerDictionary.ContainsKey(type))
            return;

        foreach (var listener in listenerDictionary[type])
        {
            if (!listener.IsActive)
            {
                listener.Activate(duration, applier);
            }
            
        }
    }
}
