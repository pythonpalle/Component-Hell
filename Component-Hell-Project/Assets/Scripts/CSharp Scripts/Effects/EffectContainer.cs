using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : MonoBehaviour
{
    [SerializeField] private DynamicFloat effectTime;
    public DynamicFloat EffectTime => effectTime;

    public List<EffectComponent> activeEffects = new List<EffectComponent>();

    public void AddMultiplier(string name, float value)
    {
        effectTime.AddMultiplier(name, value);
    }

    public void AddEffect(EffectComponent newEffect)
    {
        activeEffects.Add(newEffect);
        Debug.Log($"{name} recieved the effect {newEffect.name}!");
    }

    public void RemoveEffect(EffectComponent effectComponent)
    {
        activeEffects.Remove(effectComponent);
    }

    public bool HasEffect(EffectComponent effectPrefab)
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            if (activeEffects[i].GetType() == effectPrefab.GetType())
            {
                return true;
            }
        }

        return false;
    }
}