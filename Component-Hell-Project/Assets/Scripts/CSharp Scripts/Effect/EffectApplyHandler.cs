using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplyHandler : MonoBehaviour, WeaponDataUpdateListener
{
    public List<EffectTypeWrapper> EffectAppliers;
    private DynamicFloat effectDuration;

    public void OnWeaponDataUpdate(WeaponDataHolder data)
    {
        EffectAppliers = data.EffectAppliers;
        effectDuration = data.effectDuration;
    }

    public void TryApplyEffects(Collider2D other)
    {
        var effectListenerManager = other.GetComponentInChildren<EffectListenerManager>();
        if (!effectListenerManager)
        {
            Debug.Log($"{other.name} doesn't have an effect listener manager");
            return;
        }

        effectListenerManager.ApplyEffects(EffectAppliers);
    }
}
