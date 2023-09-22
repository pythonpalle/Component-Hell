using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectListenerManager : MonoBehaviour
{
    [SerializeField] private List<EffectListener> _effectListeners = new List<EffectListener>();
    private Dictionary<EffectType, List<EffectListener>> listenerDictionary = new Dictionary<EffectType, List<EffectListener>>();

    // private float effectDuration = 1;
    // private float timeOfLastActivation;
    // private bool isActivated;
    //
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
    

    public void ApplyEffects(List<EffectType> effectAppliers, float duration)
    {
        foreach (var applier in effectAppliers)
        {
            ApplyAllOfType(applier, duration);
        }
    }
    

    private void ApplyAllOfType(EffectType type, float duration)
    {
        if (!listenerDictionary.ContainsKey(type))
            return;

        foreach (var listener in listenerDictionary[type])
        {
            if (!listener.IsActive)
            {
                listener.Activate(duration);
            }
            
        }
    }

    // private void LateUpdate()
    // {
    //     if (!isActivated) return;
    //     
    //     UpdateDeactivation();
    // }

    // private void UpdateDeactivation()
    // {
    //     if (Time.time >= timeOfLastActivation + effectDuration)
    //     {
    //         isActivated = false;
    //         HandleDeactivations();
    //         Debug.Log("Deactivate all stuffs");
    //     }
    // }
    //
    // private void HandleDeactivations()
    // {
    //     foreach (var listener in _effectListeners)
    //     {
    //         listener.Deactivate(); 
    //     }
    // }
}
