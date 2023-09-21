using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private DynamicFloat effectTime;

    [SerializeField] private List<EffectComponent> activeEffects = new List<EffectComponent>();
    [SerializeField] private List<EffectAdder> effectAdders = new List<EffectAdder>();
    

    public void AddMultiplier(string name, float value)
    {
        effectTime.AddMultiplier(name, value);
    }

    public void AddEffect(EffectComponent newEffect)
    {
        activeEffects.Add(newEffect);
    }

    public void RemoveEffect(EffectComponent effectComponent)
    {
        if (activeEffects.Contains(effectComponent))
            activeEffects.Remove(effectComponent);
    }

    public bool HasEffect(EffectComponent effectPrefab, out EffectComponent effectComponent)
    {
        effectComponent = null;
        
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            if (activeEffects[i].GetType() == effectPrefab.GetType())
            {
                effectComponent = activeEffects[i];
                return true;
            }
        }

        return false;
    }

    public void TransformChildrenChanged()
    {
        foreach (var adder in transform.parent.GetComponentsInChildren<EffectAdder>())
        {
            if (!effectAdders.Contains(adder))
            {
                effectAdders.Add(adder);
            }
        }
    }

    public void TryApplyEffects(Collider2D other)
    {
        var otherEffectContainer = other.GetComponentInChildren<EffectManager>();
        if (!otherEffectContainer)
            return;

        foreach (var adder in effectAdders)
        {
            if (otherEffectContainer.HasEffect(adder.EffectToAdd, out var effectComponent))
            {
                if (!effectComponent.gameObject.activeSelf)
                {
                    effectComponent.gameObject.SetActive(true);
                    effectComponent.SetAdder(adder);
                    effectComponent.Reactivate();
                }
                continue;
            }

            if (adder)
            {
                adder.AddEffect(otherEffectContainer, effectTime);
            }
        }
    }

    public void RemoveAllEffects()
    {
        for (int i = activeEffects.Count-1; i >= 0; i--)
        {
            activeEffects[i].HandleDeactivation();
        }
    }
}