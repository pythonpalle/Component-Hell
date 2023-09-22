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

    public void ApplyEffects(List<EffectTypeWrapper> effectAppliers)
    {
        foreach (var applier in effectAppliers)
        {
            ApplyAllOfType(applier);
        } 
    }

    private void ApplyAllOfType(EffectTypeWrapper typeWrapper)
    {
        var type = typeWrapper.Type;

        if (!listenerDictionary.ContainsKey(type))
            return;

        foreach (var listener in listenerDictionary[type])
        {
            listener.OnApplied?.Invoke();
        }
    }
}
